using System;
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
    public partial class KGSurvey : Form
    {
        Document doc = null;
        Database db = null;
        Editor ed = null;

        List<PointXYZCode> ptCodeList = null;

        Dictionary<String, List<Point3d>> strPtList = new Dictionary<string, List<Point3d>>();
        List<String> strKeyList = new List<String>();

        Dictionary<String, String> strLayNameCodeList = new Dictionary<String, String>();

        State state = new State();
        Triangulation tri = null;

        // 
        KGSurvey_DataList frmDataList = new KGSurvey_DataList();
        //KGSurvey_Mark frmMark = null;

        public KGSurvey()
        {
            InitializeComponent();
        }

        private void KGSurvey_Load(object sender, EventArgs e)
        {
            doc = Application.DocumentManager.MdiActiveDocument;
            db = doc.Database;
            ed = doc.Editor;

            db.ObjectErased += db_ObjectErased;
            db.ObjectAppended += db_ObjectAppended;
            db.ObjectModified += db_ObjectModified;

            // 툴팁 설정
            SetToolTips();

            GetDwgObject();
        }

        private void GetDwgObject()
        {
            // 도면의 정점 정보를 얻는다.
            PromptSelectionResult psr = ed.SelectAll();
            if (psr.Status != PromptStatus.OK)
                return;

            ObjectIdCollection oIdColl = new ObjectIdCollection(psr.Value.GetObjectIds());

            if (oIdColl.Count == 0)
                return;

            using (DocumentLock docLock = doc.LockDocument())
            {
                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    if (ptCodeList == null)
                        ptCodeList = new List<PointXYZCode>();

                    foreach (ObjectId oId in oIdColl)
                    {
                        DBObject dbObj = tr.GetObject(oId, OpenMode.ForRead);

                        if (dbObj.GetType() == typeof(DBPoint))
                        {
                            // 점이라면,  
                            DBPoint dbPt = dbObj as DBPoint;

                            String[] strValue = dbPt.Layer.Split('_');
                            ptCodeList.Add(new PointXYZCode(dbPt.Position, strValue[1]));

                            state.bLoaded = true;
                        }
                        else if (dbObj.GetType() == typeof(Line))
                        {
                            // 현황선이라면, 
                            state.bLinked = true;
                        }
                        else if (dbObj.GetType() == typeof(Polyline3d))
                        {
                            // 삼각망이라면, 
                            state.bTriangle = true;
                        }
                        else if (dbObj.GetType() == typeof(Polyline))
                        {
                            // 등고선이라면, 
                            state.bContour = true;
                        }
                        else if (dbObj.GetType() == typeof(DBText))
                        {
                            int a;
                            a = 1;
                        }
                    }
                }
            }

            // ptCodeList로 SetPtCodeInfo()와 같은 작업을 한다.
            SetPtCodeInfo();
        }

        // Object 수정 이벤트
        void db_ObjectModified(object sender, ObjectEventArgs e)
        {
        }

        // autocad .net objectappended
        // Object 추가 이벤트
        void db_ObjectAppended(object sender, ObjectEventArgs e)
        {
            DBObject dbObj = e.DBObject;

            ResultBuffer rb = dbObj.XData;
            if (rb != null)
            {
                // XData가 없으면, 내가 추가한 것이다.
            }
            else
            {
                if (dbObj.GetType() == typeof(DBPoint))
                {
                    if (ptCodeList == null)
                        ptCodeList = new List<PointXYZCode>();

                    // PtCodeList에 추가
                    DBPoint dbPt = dbObj as DBPoint;
                    String[] strValue = dbPt.Layer.Split('_');
                    // 레이어가 없는 레이어 strLayNameCodeList 예외 처리

                    if (strLayNameCodeList.ContainsKey(strValue[1]) == false)
                    {
                        MessageBox.Show("{0}은 코드가 존재하지 않는 레이어입니다. 레이어를 확인해주시기 바랍니다.", strValue[1]);
                        return;
                    }
                    String strCode = strLayNameCodeList[strValue[1]];
                    ptCodeList.Add(new PointXYZCode(dbPt.Position, strCode));

                    strPtList[strCode].Add(dbPt.Position);
                }
                else if (dbObj.GetType() == typeof(Line))
                {
                }
            }
        }

        // Object 삭제 이벤트
        void db_ObjectErased(object sender, ObjectErasedEventArgs e)
        {
            DBObject dbObj = e.DBObject;

            if (dbObj.GetType() == typeof(DBPoint))
            {
                DBPoint dbPt = dbObj as DBPoint;

                using (DocumentLock docLock = doc.LockDocument())
                {
                    using (Transaction tr = db.TransactionManager.StartTransaction())
                    {
                        int Idx = ptCodeList.FindIndex(x => (x.pt == dbPt.Position));
                        ptCodeList.RemoveAt(Idx);

                        foreach (String strLayerName in strKeyList)
                        {
                            Idx = strPtList[strLayerName].FindIndex(x => (x == dbPt.Position));
                            if (Idx >= 0)
                            {
                                strPtList[strLayerName].RemoveAt(Idx);
                                break;
                            }
                        }

                        //// 점이 삭제되었다면, 
                        //for (int i = 0; i < ptCodeList.Count; i++)
                        //{
                        //    if (ptCodeList[i].pt == dbPt.Position)
                        //    {
                        //        ptCodeList.RemoveAt(i);
                        //        break;
                        //    }
                        //}

                        //for (int i = 0; i < strKeyList.Count; i++)
                        //{
                        //    for (int j = 0; j < strPtList[strKeyList[i]].Count; j++)
                        //    {
                        //        if (strPtList[strKeyList[i]][j] == dbPt.Position)
                        //        {
                        //            strPtList[strKeyList[i]].RemoveAt(j);
                        //            break;
                        //        }
                        //    }
                        //}
                        //tr.Commit();
                    }
                }
            }
            else if (dbObj.GetType() == typeof(Line))
            {
                // 현황선이 삭제되었다면, 
            }
            else if (dbObj.GetType() == typeof(Polyline3d))
            {
                // 삼각망이 삭제되었다면, 
            }
            else if (dbObj.GetType() == typeof(Polyline))
            {
                // 등고선이 삭제되었다면, 
            }

        }

        private void SetToolTips()
        {
            int nNum = 20;
            ToolTip[] tips = new ToolTip[nNum];
            for (int i = 0; i < nNum; i++)
            {
                tips[i] = new ToolTip();
            }

            // 측점 파일 열기
            tips[0].SetToolTip(btnOpen, "측점 파일을 불러옵니다. (*.csv)");

            // 같은 코드 연결
            tips[1].SetToolTip(btnSameCode, "같은 코드를 현황선으로 연결합니다.");

            // 연속 코드 연결
            tips[2].SetToolTip(btnContiCode, "연속된 코드를 현황선으로 연결합니다.");

            // 현황선 삭제
            tips[3].SetToolTip(btnLDel, "현황선을 삭제합니다.");

            // 정보 보기
            tips[4].SetToolTip(btnShowInfo, "선택한 객체의 정보를 보여줍니다.");

            // 측점 리스트
            tips[5].SetToolTip(btnPtList, "현재 도면의 측점 리스트를 보여줍니다.");

            // 측점 표기
            tips[6].SetToolTip(btnPtInfo, "측점에 정보를 표시합니다.");

            // 삼각망 생성
            tips[7].SetToolTip(btnTri, "삼각망을 생성합니다.");

            // 삼각망 삭제
            tips[8].SetToolTip(btnTriDel, "삼각망을 삭제합니다.");

            // 등고선 생성
            tips[9].SetToolTip(btnContour, "등고선을 생성합니다.");

            // 등고선 삭제
            tips[10].SetToolTip(btnContourDel, "등고선을 삭제합니다.");

            // 지반고 추출
            tips[11].SetToolTip(btnKnowZ, "지반고를 추출합니다.");

            // 방위각으로 측점 추가
            tips[12].SetToolTip(btnAddPt, "방위각으로 측점을 추가합니다.");

            // 레이어 병합
            tips[13].SetToolTip(btnLayMerge, "레이어를 병합합니다.");
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            String strFilePath = "";

            // 파일 다이얼로그로 파일을 불러온다. 
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "CSV File(*.csv)|*.csv|Excel File(*.xlsx)|*.xlsx|모든파일(*.*)|*.*";
            openDlg.Title = "파일을 선택해주세요.";

            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                strFilePath = openDlg.FileName;
            }
            else return;

            ptCodeList = ExportUtil.GetFileName(strFilePath);

            // 정보 설정
            SetPtCodeInfo();

            // 레이어를 생성하고, 점만 출력한다.
            using (DocumentLock docLock = doc.LockDocument())
            {
                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    BlockTableRecord btr = (BlockTableRecord)tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite);

                    for (int i = 0; i < strKeyList.Count; i++)
                    {
                        // Code별로 Layer를 생성한다.
                        LayerTable lt = (LayerTable)tr.GetObject(db.LayerTableId, OpenMode.ForRead);
                        String strLayName = "Layer_" + strKeyList[i];
                        Utils.GetRegexLayerName(ref strLayName);

                        if (lt.Has(strLayName) == false)
                        {
                            LayerTableRecord ltr = new LayerTableRecord();
                            ltr.Name = strLayName;

                            short Idx = 0;
                            if (i > 255)
                            {
                                int div = i / 256;
                                int n = i - 256 * div;
                                Idx = (short)n;
                            }
                            else
                            {
                                Idx = (short)i;
                            }

                            ltr.Color = Autodesk.AutoCAD.Colors.Color.FromColorIndex(
                                Autodesk.AutoCAD.Colors.ColorMethod.ByBlock, Idx);

                            lt.UpgradeOpen();
                            ObjectId objId = lt.Add(ltr);
                            tr.AddNewlyCreatedDBObject(ltr, true);

                            db.Clayer = objId;
                        }
                        else
                        {
                            db.Clayer = lt[strLayName];
                        }

                        // 일단 모든 점을 그린다.
                        // XData 설정
                        RegAppTable rat = tr.GetObject(db.RegAppTableId, OpenMode.ForRead, false) as RegAppTable;

                        if (rat.Has(XDataType.strPoint) == false)
                        {
                            rat.UpgradeOpen();
                            RegAppTableRecord ratr = new RegAppTableRecord();
                            ratr.Name = XDataType.strPoint;
                            rat.Add(ratr);
                            tr.AddNewlyCreatedDBObject(ratr, true);
                        }

                        List<Point3d> ptList = strPtList[strKeyList[i]];
                        foreach (Point3d pt in ptList)
                        {
                            ResultBuffer rb = new ResultBuffer(
                                new TypedValue(1001, XDataType.strPoint),
                                new TypedValue(1000, "타입"));

                            DBPoint dbPoint = new DBPoint(pt);

                            btr.AppendEntity(dbPoint);
                            dbPoint.XData = rb;
                            rb.Dispose();
                            tr.AddNewlyCreatedDBObject(dbPoint, true);
                        }
                    }

                    tr.Commit();
                }
            }

            ZoomUtil.ZoomExtend();

            state.bLoaded = true;
        }

        /// <summary>
        /// ptCodeList의 정보를 strPtList, strKeyList에 설정한다.
        /// </summary>
        private void SetPtCodeInfo()
        {
            if (ptCodeList == null) return;
            // 정보를 설정한다.
            for (int i = 0; i < ptCodeList.Count; i++)
            {
                if (strPtList.ContainsKey(ptCodeList[i].strCode) == false)
                {
                    strPtList.Add(ptCodeList[i].strCode, new List<Point3d>());
                    strKeyList.Add(ptCodeList[i].strCode);
                }

                strPtList[ptCodeList[i].strCode].Add(ptCodeList[i].pt);
            }

            if (strLayNameCodeList == null)
                strLayNameCodeList = new Dictionary<String, String>();

            for (int i = 0; i < strKeyList.Count; i++)
            {
                String strLayName = strKeyList[i];
                Utils.GetRegexLayerName(ref strLayName);
                strLayNameCodeList.Add(strLayName, strKeyList[i]);
            }
        }

        private void UpdatePtCodeInfo()
        {

        }

        private void btnSameCode_Click(object sender, EventArgs e)
        {
            // null이 아닐 경우 출력한다.
            if (state.bLoaded != true)
            {
                MessageBox.Show("측점 파일을 불러와주세요.");
                return;
            }
            if (state.bLinked == true)
            {
                MessageBox.Show("이미 현황선이 존재합니다.");
                return;
            }

            using (DocumentLock docLock = doc.LockDocument())
            {
                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    BlockTable acBlkTbl;
                    acBlkTbl = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
                    BlockTableRecord btr;
                    btr = (BlockTableRecord)tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite);

                    LayerTable lt = (LayerTable)tr.GetObject(db.LayerTableId, OpenMode.ForRead);

                    for (int i = 0; i < strKeyList.Count; i++)
                    {
                        // Code별로 Layer를 가져온다.
                        String strLayName = "Layer_" + strKeyList[i];
                        Utils.GetRegexLayerName(ref strLayName);
                        if (lt.Has(strLayName) == true)
                        {
                            db.Clayer = lt[strLayName];
                        }

                        // 폴리라인을 그린다. 개수가 1개 이상인 경우 가능
                        List<Point3d> ptList = strPtList[strKeyList[i]];

                        if (ptList.Count > 1)
                        {
                            // XData 설정
                            RegAppTable rat = tr.GetObject(db.RegAppTableId, OpenMode.ForRead, false) as RegAppTable;

                            if (rat.Has(XDataType.strLine) == false)
                            {
                                rat.UpgradeOpen();
                                RegAppTableRecord ratr = new RegAppTableRecord();
                                ratr.Name = XDataType.strLine;
                                rat.Add(ratr);
                                tr.AddNewlyCreatedDBObject(ratr, true);
                            }

                            //if (chkOnePL.Checked == true)
                            //{
                            //    // 연결된 선
                            //    using (Polyline3d pline = new Polyline3d())
                            //    {
                            //        ResultBuffer rb = new ResultBuffer(
                            //            new TypedValue(1001, strLineType),
                            //            new TypedValue(1000, "타입"));

                            //        btr.AppendEntity(pline);
                            //        for (int j = 0; j < ptList.Count; j++)
                            //        {
                            //            using (PolylineVertex3d poly3dvertex = new PolylineVertex3d(ptList[j]))
                            //                pline.AppendVertex(poly3dvertex);
                            //        }

                            //        pline.XData = rb;
                            //        rb.Dispose();
                            //        tr.AddNewlyCreatedDBObject(pline, true);
                            //    }
                            //}
                            //else
                            //{
                            for (int j = 0; j < ptList.Count - 1; j++)
                            {
                                ResultBuffer rb = new ResultBuffer(
                                    new TypedValue(1001, XDataType.strLine),
                                    new TypedValue(1000, "타입"));

                                Line line = new Line(ptList[j], ptList[j + 1]);

                                line.XData = rb;
                                rb.Dispose();
                                btr.AppendEntity(line);
                                tr.AddNewlyCreatedDBObject(line, true);
                            }
                            //}
                        }

                    }

                    ed.Regen();
                    tr.Commit();
                }
            }

            state.bLinked = true;
        }

        private void btnContiCode_Click(object sender, EventArgs e)
        {
            // null이 아닐 경우 출력한다.
            if (state.bLoaded != true)
            {
                MessageBox.Show("측점 파일을 불러와주세요.");
                return;
            }
            if (state.bLinked == true)
            {
                MessageBox.Show("이미 현황선이 존재합니다.");
                return;
            }

            using (DocumentLock docLock = doc.LockDocument())
            {
                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    BlockTable acBlkTbl;
                    acBlkTbl = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
                    BlockTableRecord btr;
                    btr = (BlockTableRecord)tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite);

                    LayerTable lt = (LayerTable)tr.GetObject(db.LayerTableId, OpenMode.ForRead);

                    // XData 설정
                    RegAppTable rat = tr.GetObject(db.RegAppTableId, OpenMode.ForRead, false) as RegAppTable;

                    if (rat.Has(XDataType.strLine) == false)
                    {
                        rat.UpgradeOpen();
                        RegAppTableRecord ratr = new RegAppTableRecord();
                        ratr.Name = XDataType.strLine;
                        rat.Add(ratr);
                        tr.AddNewlyCreatedDBObject(ratr, true);
                    }

                    for (int i = 0; i < ptCodeList.Count - 1; i++)
                    {
                        if (ptCodeList[i].strCode == ptCodeList[i + 1].strCode)
                        {
                            ResultBuffer rb = new ResultBuffer(
                                new TypedValue(1001, XDataType.strLine),
                                new TypedValue(1000, "타입"));

                            // Code별로 Layer를 가져온다.
                            String strLayName = "Layer_" + ptCodeList[i].strCode;
                            Utils.GetRegexLayerName(ref strLayName);
                            if (lt.Has(strLayName) == true)
                            {
                                db.Clayer = lt[strLayName];
                            }

                            Line line = new Line(ptCodeList[i].pt, ptCodeList[i + 1].pt);

                            line.XData = rb;
                            rb.Dispose();
                            btr.AppendEntity(line);
                            tr.AddNewlyCreatedDBObject(line, true);
                        }
                    }

                    ed.Regen();
                    tr.Commit();
                }
            }

            state.bLinked = true;
        }

        private void btnLDel_Click(object sender, EventArgs e)
        {
            if (state.bLinked != true)
            {
                MessageBox.Show("현재 현황선이 없습니다.");
                return;
            }

            // 전체 선택
            TypedValue[] tv = new TypedValue[1] { 
                        new TypedValue((int)DxfCode.Start, "line,Polyline")};

            SelectionFilter sf = new SelectionFilter(tv);
            PromptSelectionResult psr = ed.SelectAll(sf);

            // Line 혹은 Polyline3d 중 XData가 
            if (psr.Status != PromptStatus.OK) return;

            ObjectId[] IdColl = psr.Value.GetObjectIds();

            using (DocumentLock docLock = doc.LockDocument())
            {
                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    for (int i = 0; i < IdColl.Length; i++)
                    {
                        Entity ent = tr.GetObject(IdColl[i], OpenMode.ForWrite) as Entity;

                        ResultBuffer rb = ent.XData;

                        if (rb != null)
                        {
                            foreach (TypedValue tv2 in rb)
                            {
                                String strTypeCode = tv2.TypeCode.ToString();
                                String strValue = tv2.Value.ToString();
                                if (strTypeCode == "1001" && strValue == XDataType.strLine)
                                {
                                    // 삭제하고, 
                                    ent.Erase();
                                }
                            }
                        }

                    }

                    ed.Regen();
                    tr.Commit();
                }
            }

            state.bLinked = false;
        }

        private void btnShowInfo_Click(object sender, EventArgs e)
        {
            // null이 아닐 경우 출력한다.
            if (state.bLoaded != true)
            {
                MessageBox.Show("측점 파일을 불러와주세요.");
                return;
            }

            // AutoCad Focus
            Autodesk.AutoCAD.Internal.Utils.SetFocusToDwgView();

            // 선택 후 
            // 그 엔티티의 정보를 출력해준다.
            ObjectId oEntId = SelectUtil.SelectOnePolyline(ed, "",
                "point,line,polyline", "객체 하나를 선택해주세요.");

            if (oEntId == ObjectId.Null) return;
            // 점인지 선인지 
            using (DocumentLock docLock = doc.LockDocument())
            {
                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    Entity ent = tr.GetObject(oEntId, OpenMode.ForWrite) as Entity;

                    ResultBuffer rb = ent.XData;

                    if (rb != null)
                    {
                        foreach (TypedValue tv2 in rb)
                        {
                            String strTypeCode = tv2.TypeCode.ToString();
                            String strValue = tv2.Value.ToString();
                            if (strTypeCode == "1001")
                            {
                                if (strValue == XDataType.strLine)
                                {
                                    //MessageBox.Show("라인입니다.");
                                    Line line = ent as Line;

                                    KGSurvey_LineInfo frmLine = new KGSurvey_LineInfo();
                                    frmLine.SetInfo(doc, line);

                                    frmLine.Show();
                                }
                                else if (strValue == XDataType.strPoint)
                                {
                                    //MessageBox.Show("점입니다.");
                                    DBPoint dbPoint = ent as DBPoint;

                                    int nIdx = -1;
                                    for (int i = 0; i < ptCodeList.Count; i++)
                                    {
                                        if (ptCodeList[i].pt == dbPoint.Position)
                                        {
                                            nIdx = i + 1;
                                            break;
                                        }
                                    }

                                    // ptCodeList에도 갱신해준다. 
                                    KGSurvey_PointInfo frmPoint = new KGSurvey_PointInfo();
                                    frmPoint.SetInfo(doc, dbPoint, nIdx);

                                    frmPoint.Show();
                                }
                            }
                        }
                    }

                    ed.Regen();
                    tr.Commit();
                }
            }

        }

        private void btnPtList_Click(object sender, EventArgs e)
        {
            // null이 아닐 경우 출력한다.
            if (state.bLoaded != true)
            {
                MessageBox.Show("측점 파일을 불러와주세요.");
                return;
            }

            frmDataList.SetPtList(ptCodeList);
            frmDataList.Show();

            // List<bChecked>의 정보를 받는다.

            // KGSurvey_DataList에 Data입력
            //// 정보를 설정한다.
            //for (int i = 0; i < ptCodeList.Count; i++)
            //{
            //    if (strPtList.ContainsKey(ptCodeList[i].strCode) == false)
            //    {
            //        strPtList.Add(ptCodeList[i].strCode, new List<Point3d>());
            //        strKeyList.Add(ptCodeList[i].strCode);
            //    }

            //    strPtList[ptCodeList[i].strCode].Add(ptCodeList[i].pt);

            //    //// lstPoint에 뿌려준다. 
            //    //int nNum = i + 1;
            //    //ListViewItem Item = new ListViewItem(nNum.ToString());
            //    //Item.SubItems.Add(ptCodeList[i].pt.X.ToString());
            //    //Item.SubItems.Add(ptCodeList[i].pt.Y.ToString());
            //    //Item.SubItems.Add(ptCodeList[i].pt.Z.ToString());
            //    //Item.SubItems.Add(ptCodeList[i].strCode);

            //    //lstPoint.Items.Add(Item);
            //}
        }

        private void btnPtInfo_Click(object sender, EventArgs e)
        {
            // null이 아닐 경우 출력한다.
            if (state.bLoaded != true)
            {
                MessageBox.Show("측점 파일을 불러와주세요.");
                return;
            }

            // KGSurvey_Mark로 측점을 표시한다.
            if (ptCodeList == null) return;

            //if (frmMark == null)
            //{
            KGSurvey_Mark frmMark = new KGSurvey_Mark();
            frmMark.SetInfo(doc, ptCodeList);
            //}

            frmMark.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTri_Click(object sender, EventArgs e)
        {
            // null이 아닐 경우 출력한다.
            if (state.bLoaded != true)
            {
                MessageBox.Show("측점 파일을 불러와주세요.");
                return;
            }

            // 삼각망 생성
            List<Point3d> ptList = new List<Point3d>();
            for (int i = 0; i < ptCodeList.Count; i++)
            {
                ptList.Add(ptCodeList[i].pt);
            }

            // 점 정렬
            Utils.ArrayPointList(ref ptList);

            List<Line> lineList = new List<Line>();

            if (tri == null)
                tri = new Triangulation(doc);
            tri.MakeTriangle(ptList, lineList, "삼각망레이어");

            state.bTriangle = true;
        }

        private void btnTriDel_Click(object sender, EventArgs e)
        {
            // 전체 엔티티 중에 Polyline3D를 삭제한다.
            ObjectIdCollection oIdColl = SelectUtil.SelectAll(ed, "", "*POLY*");
            if (oIdColl.Count == 0) return;

            using (DocumentLock docLock = doc.LockDocument())
            {
                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    foreach (ObjectId Id in oIdColl)
                    {
                        DBObject dbObj = tr.GetObject(Id, OpenMode.ForWrite) as DBObject;

                        if (dbObj.GetType() == typeof(Polyline3d))
                        {
                            Polyline3d poly3d = dbObj as Polyline3d;

                            poly3d.Erase();
                        }
                    }

                    ed.Regen();
                    tr.Commit();
                }
            }

            // 등고선이 있다면, 등고선을 삭제한다.

            state.bTriangle = false;
        }

        private void btnContour_Click(object sender, EventArgs e)
        {
            // null이 아닐 경우 출력한다.
            if (state.bLoaded != true)
            {
                MessageBox.Show("측점 파일을 불러와주세요.");
                return;
            }
            if (state.bTriangle != true)
            {
                MessageBox.Show("먼저 삼각망을 생성해주세요.");
                return;
            }

            // 등고선 생성
            KGSurvey_Contour contour = new KGSurvey_Contour(doc, "등고선레이어");
            contour.Show();

            if (contour.bContour == true)
                state.bContour = true;
        }

        private void btnContourDel_Click(object sender, EventArgs e)
        {
            // 전체 엔티티 중에 Polyline을 삭제한다.
            ObjectIdCollection oIdColl = SelectUtil.SelectAll(ed, "", "*POLY*");
            if (oIdColl.Count == 0) return;

            using (DocumentLock docLock = doc.LockDocument())
            {
                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    foreach (ObjectId Id in oIdColl)
                    {
                        DBObject dbObj = tr.GetObject(Id, OpenMode.ForWrite) as DBObject;

                        if (dbObj.GetType() == typeof(Polyline))
                        {
                            Polyline poly = dbObj as Polyline;

                            poly.Erase();
                        }
                    }

                    ed.Regen();
                    tr.Commit();
                }
            }

            state.bContour = false;
        }

        private void KGSurvey_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Escape:
                    this.Close();
                    break;
                case 'o':
                case 'O':
                    // 측점 파일 열기
                    break;
            }
        }

        private void btnKnowZ_Click(object sender, EventArgs e)
        {
            // null이 아닐 경우 출력한다.
            if (state.bLoaded != true)
            {
                MessageBox.Show("측점 파일을 불러와주세요.");
                return;
            }
            if (state.bTriangle != true)
            {
                MessageBox.Show("먼저 삼각망을 생성해주세요.");
                return;
            }

            PromptPointResult ppr = ed.GetPoint("삼각망의 점을 선택해주세요.");
            if (ppr.Status != PromptStatus.OK)
                return;

            // tri의 삼각망을 가져온다.



        }

        private void btnAddPt_Click(object sender, EventArgs e)
        {

        }

        private void btnLayMerge_Click(object sender, EventArgs e)
        {
            KGSurvey_LayerManage frmLayer = new KGSurvey_LayerManage(doc);
            frmLayer.Show();
        }

    }
}
