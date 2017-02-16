using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;

namespace KGSurvey
{
    public partial class KGSurvey_Mark : Form
    {
        Document doc = null;
        Database db = null;
        Editor ed = null;

        List<PointXYZCode> ptCodeList = null;
        Dictionary<Point3d, List<ObjectId>> ptStrList = null;

        String strText = "측점정보";

        public KGSurvey_Mark()
        {
            InitializeComponent();
        }

        public void SetInfo(Document _doc, List<PointXYZCode> _ptCodeList)
        {
            doc = _doc;
            db = doc.Database;
            ed = doc.Editor;

            ptCodeList = _ptCodeList;

            //List<String> strList = GetCurrentLayerList(doc, db);

            //for (int i = 0; i < strList.Count; i++)
            //{
            //    lstLayer.Items.Add(strList[i]);
            //}
        }

        private void btnAdjust_Click(object sender, EventArgs e)
        {
            // Check된게 없으면 그냥 Return한다.
            if (!GetChecked())
            {
                MessageBox.Show("선택된 표기정보가 없습니다.");
            }

            // 레이어 생성
            ObjectId oLayId = LayerUtil.CreateLayer(doc, db, tbLayerName.Text, 0);
            // 측점 표기 적용
            if (ptStrList == null)
                ptStrList = new Dictionary<Point3d, List<ObjectId>>();
            else
            {
                DeletePoints();
                ptStrList = new Dictionary<Point3d, List<ObjectId>>();
            }

            using (DocumentLock docLoc = doc.LockDocument())
            {
                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    db.Clayer = oLayId;      
      
                    BlockTable bt = tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                    BlockTableRecord btr = tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                    for (int i = 0; i < ptCodeList.Count; i++)
                    {
                        // XData 설정
                        RegAppTable rat = tr.GetObject(db.RegAppTableId, OpenMode.ForRead, false) as RegAppTable;

                        if (rat.Has(strText) == false)
                        {
                            rat.UpgradeOpen();
                            RegAppTableRecord ratr = new RegAppTableRecord();
                            ratr.Name = strText;
                            rat.Add(ratr);
                            tr.AddNewlyCreatedDBObject(ratr, true);
                        }

                        List<ObjectId> objList = new List<ObjectId>();
                        Double dx, dy;
                        Double dHeight = Convert.ToDouble(tbTxtHeight.Text);
                        String strTxt;

                        if (chkNum.Checked)
                        {
                            dx = 0;
                            dy = 3.8;
                            strTxt = (i + 1).ToString();

                            DBText txt = AddDBText(i, ref btr, strTxt, dx, dy, dHeight);
                            tr.AddNewlyCreatedDBObject(txt, true);

                            objList.Add(txt.Id);
                        }
                        if (chkCode.Checked)
                        {
                            dx = 0;
                            dy = 2.4;
                            strTxt = ptCodeList[i].strCode;

                            DBText txt = AddDBText(i, ref btr, strTxt, dx, dy, dHeight);
                            tr.AddNewlyCreatedDBObject(txt, true);

                            objList.Add(txt.Id);
                        }
                        if (chkX.Checked)
                        {
                            Double dNum = ptCodeList[i].pt.X;
                            String strNum = Math.Round(dNum, Convert.ToInt32(numericNum.Value)).ToString();

                            dx = 2.18;
                            dy = 1;
                            strTxt = strNum;

                            DBText txt = AddDBText(i, ref btr, strTxt, dx, dy, dHeight);
                            tr.AddNewlyCreatedDBObject(txt, true);

                            objList.Add(txt.Id);
                        }
                        if (chkY.Checked)
                        {
                            Double dNum = ptCodeList[i].pt.Y;
                            String strNum = Math.Round(dNum, Convert.ToInt32(numericNum.Value)).ToString();

                            dx = 2.18;
                            dy = -0.7;
                            strTxt = strNum;

                            DBText txt = AddDBText(i, ref btr, strTxt, dx, dy, dHeight);
                            tr.AddNewlyCreatedDBObject(txt, true);

                            objList.Add(txt.Id);
                        }
                        if (chkZ.Checked)
                        {
                            Double dNum = ptCodeList[i].pt.Z;
                            String strNum = Math.Round(dNum, Convert.ToInt32(numericNum.Value)).ToString();

                            dx = 2.18;
                            dy = -2.5;
                            strTxt = strNum;

                            DBText txt = AddDBText(i, ref btr, strTxt, dx, dy, dHeight);
                            tr.AddNewlyCreatedDBObject(txt, true);

                            objList.Add(txt.Id);
                        }

                        ptStrList.Add(ptCodeList[i].pt, objList);
                    }

                    ed.Regen();
                    tr.Commit();
                }
            }

            //this.Close();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            // 전체 적용 해제
            if (ptStrList == null) return;

            // 전체 텍스트 삭제
            DeletePoints();
        }

        private void DeletePoints()
        {
            using (DocumentLock docLoc = doc.LockDocument())
            {
                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    for (int i = 0; i < ptStrList.Count; i++)
                    {
                        List<ObjectId> objList = ptStrList[ptCodeList[i].pt];

                        foreach (ObjectId objId in objList)
                        {
                            try
                            {
                                DBText txt = tr.GetObject(objId, OpenMode.ForWrite) as DBText;
                                txt.Erase();
                            }
                            catch
                            {
                            }
                        }

                        ptStrList[ptCodeList[i].pt].Clear();
                    }

                    ptStrList.Clear();
                    ptStrList = null;

                    ed.Regen();
                    tr.Commit();
                }
            }
        }

        private void rbtAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtAll.Checked == true)
            {
                btnSelAll.Enabled = false;
                btnSelNone.Enabled = false;
                lstLayer.Enabled = false;
            }
        }

        private void rbtByLayer_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtByLayer.Checked == true)
            {
                btnSelAll.Enabled = true;
                btnSelNone.Enabled = true;
                lstLayer.Enabled = true;
            }
        }

        private bool GetChecked()
        {
            bool[] bArry = new bool[5];

            bArry[0] = chkX.Checked;
            bArry[1] = chkY.Checked;
            bArry[2] = chkZ.Checked;
            bArry[3] = chkNum.Checked;
            bArry[4] = chkCode.Checked;

            for (int i = 0; i < bArry.Length; i++)
            {
                if (bArry[i] == true)
                    return true;
            }
            return false;
        }

        private Point3d GetPosition(Point3d ptPos, double dx, double dy)
        {
            return new Point3d(ptPos.X + dx, ptPos.Y + dy, 0);
        }

        private DBText AddDBText(int i, ref BlockTableRecord btr, String strTxt, 
            double dx, double dy, double dHeight, 
            AttachmentPoint Attachment = AttachmentPoint.BaseLeft)
        {
            ResultBuffer rb = new ResultBuffer(
                new TypedValue(1001, strText),
                new TypedValue(1000, "타입"));

            DBText txt = new DBText();
            txt.TextString = strTxt;
            txt.Height = dHeight;
            txt.Position = GetPosition(ptCodeList[i].pt, dx, dy);
            txt.Justify = Attachment;

            btr.AppendEntity(txt);
            txt.XData = rb;
            rb.Dispose();

            return txt;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
