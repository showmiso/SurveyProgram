using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;

using Application = Autodesk.AutoCAD.ApplicationServices.Application;

namespace KGSurvey
{
    public partial class KGSurvey_LayerManage : Form
    {
        private Document doc = null;
        private Database db = null;
        private Editor ed = null;

        // Layer Name, Color
        Dictionary<String, Autodesk.AutoCAD.Colors.Color> layerList
            = new Dictionary<String, Autodesk.AutoCAD.Colors.Color>();
        List<String> layerNameList = new List<String>();

        public KGSurvey_LayerManage(Document _doc)
        {
            InitializeComponent();

            doc = _doc;
            db = doc.Database;
            ed = doc.Editor;

            // 
            InitComboBox();

            InitLayerList();

            // 툴팁 설정
            SetToolTips();

        }

        private void SetToolTips()
        {
            int nNum = 5;
            ToolTip[] tips = new ToolTip[nNum];
            for (int i = 0; i < nNum; i++)
            {
                tips[i] = new ToolTip();
            }

            // 
            tips[0].SetToolTip(chkDel, "복사 또는 병합된 레이어를 삭제합니다.");

            // 복사
            tips[1].SetToolTip(btnCopy, "선택된 레이어의 객체를 대상 레이어로 복사합니다.");

            // 병합
            //tips[2].SetToolTip(btnMerge, "선택된 레이어의 객체를 대상 레이어로 이동합니다.");

            // 콤보 박스
            tips[3].SetToolTip(cboList, "대상 레이어를 선택합니다.");
        }

        private void InitComboBox()
        {
            String strText = Directory.GetCurrentDirectory() + "\\LayerTemplate.txt";

            using (StreamReader sr = new StreamReader(strText))
            {
                String strLine = "";
                while ((strLine = sr.ReadLine()) != null)
                {
                    cboList.Items.Add(strLine);
                }
            }
            cboList.Text = cboList.Items[0].ToString();
        }

        private void InitLayerList()
        {
            layerList.Clear();
            layerNameList.Clear();

            // 현재 레이어 목록을 가져온다.
            // 색을 이름에 칠해준다.
            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                LayerTable lt = tr.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;

                foreach (ObjectId Id in lt)
                {
                    LayerTableRecord ltr = tr.GetObject(Id, OpenMode.ForRead) as LayerTableRecord;

                    layerList.Add(ltr.Name, ltr.Color);
                    layerNameList.Add(ltr.Name);
                }
            }

            layerNameList.Sort();

            lstLayer.Items.Clear();
            //cboList.Items.Clear();

            // ListView를 생성한다. ComboBox도 갱신한다.
            for (int i = 0; i < layerNameList.Count; i++)
            {
                String strName = layerNameList[i];

                if (strName != "0")
                {
                    ListViewItem lvt = new ListViewItem("");
                    lvt.SubItems.Add(strName);

                    Autodesk.AutoCAD.Colors.Color color = layerList[strName];
                    lvt.SubItems[0].BackColor = color.ColorValue;

                    lstLayer.Items.Add(lvt);
                }

                //cboList.Items.Add(strName);
            }

            //cboList.Text = layerNameList[0];

            layerNameList.Clear();
        }
        
        private void btnCopy_Click(object sender, EventArgs e)
        {
            List<String> chkList = new List<String>();
            // CheckBoxList에서 선택된 Item 수를 확인한다.
            for (int i = 0; i < lstLayer.Items.Count; i++)
            {
                ListViewItem lvt = lstLayer.Items[i];
                if (lvt.Checked == true)
                {
                    chkList.Add(lvt.SubItems[1].Text);
                }
            }

            String strDstName = cboList.Text;

            if (chkList.Count < 1)
            {
                // 선택된 레이어가 1개 이상이어야 병합할 수 있다.
                return;
            }
            else if (chkList.Count == 1)
            {
                if (chkList[0] == strDstName)
                {
                    return;
                }
                // 병합 진행
            }

            // CheckBoxList에서 선택된 레이어를 
            // Combobox에서 선택된 레이어로 복사한다.
            CopyLayer(chkList, strDstName);

            // 병합이 끝나면, 
            // CheckBoxList의 현재 Layer 목록을 갱신한다.
            InitLayerList();
        }

        /// <summary>
        /// 레이어 이름 목록 srcList의 객체를 strDst 레이어로 복사한다.
        /// </summary>
        /// <param name="srcList"></param>
        /// <param name="strDst"></param>
        private void CopyLayer(List<String> srcList, String strDst)
        {
            using (DocumentLock docLoc = doc.LockDocument())
            {
                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    BlockTableRecord btr = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;
                    LayerTable lt = tr.GetObject(db.LayerTableId, OpenMode.ForWrite) as LayerTable;
                    
                    // 레이어가 있는지 확인하고, 
                    // 현재 레이어로 설정
                    ObjectId oDstId = LayerUtil.CreateLayer(doc, db, strDst, 7);
                    db.Clayer = oDstId;

                    foreach (String strSrc in srcList)
                    {
                        // strSrc 레이어가 가지고 있는 객체 목록 가져오기
                        ObjectIdCollection idColl = LayerUtil.GetAllEntityByLayerName(doc, strSrc);

                        foreach (ObjectId id in idColl)
                        {
                            Entity ent = tr.GetObject(id, OpenMode.ForWrite) as Entity;

                            // ent.Clone()을 strDst레이어로 복사한다.
                            Entity entClone = ent.Clone() as Entity;
                            entClone.LayerId = oDstId;

                            btr.AppendEntity(entClone);
                            tr.AddNewlyCreatedDBObject(entClone, true);

                            if (chkDel.Checked == true)
                            {
                                ent.Erase();
                            }
                        }

                        if (chkDel.Checked == true)
                        {
                            if (strSrc != strDst)
                            {
                                ObjectId oSrcId = lt[strSrc];
                                LayerTableRecord ltr = tr.GetObject(oSrcId, OpenMode.ForWrite) as LayerTableRecord;
                                ltr.Erase();
                            }
                        }
                    }

                    ed.Regen();
                    tr.Commit();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
