using System;
using System.Collections.Generic;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;

namespace KGSurvey
{
    public class Triangulation
    {
        private Document doc = null;
        private Database db = null;
        private Editor ed = null;

        private List<Point3d> ptList = null;
        private List<Line> brkLList = null;

        private List<Point3d> convexList = null;
        private List<Point3d> steinerList = null;

        private List<MyTriangle> triList = null;

        public Triangulation(Document _doc)
        {
            doc = _doc;
            db = doc.Database;
            ed = doc.Editor;    
        }

        public void MakeTriangle(List<Point3d> _ptList, List<Line> _lineList, String strLayerName)
        {
            // 
            ObjectId oLayId = LayerUtil.CreateLayer(doc, db, strLayerName, 9);

            if (oLayId != ObjectId.Null)
            {
                using (DocumentLock docLock = doc.LockDocument())
                {
                    db.Clayer = oLayId;
                }
            }

            ptList = _ptList;
            brkLList = _lineList;

            Compute();

            Process();

            Render();
        }

        private void Compute()
        {
            ConvexHull convex = new ConvexHull();
            convexList = convex.ComputeConvexHull(ptList);

            if (convexList == null)
                return;

            // 만약 외부점과 steiner점이 중복되도 된다면, 필요없는 부분이다.
            if (steinerList == null)
                steinerList = new List<Point3d>(ptList);

            // convexLists와 steinerList를 분리한다.
            int idx;

            for (int i = 0; i < convexList.Count; i++)
            {
                idx = steinerList.BinarySearch(0, steinerList.Count, convexList[i], new Utils.Sort3DPoint());
                if (idx >= 0 && idx < steinerList.Count)
                    steinerList.RemoveAt(idx);
                else
                {
                }
            }
        }

        private void Process()
        {
            if (convexList == null)
                return;

            // convexList, steinerList, brkLList 정보를 넘기고, 
            List<MyPoint> points = new List<MyPoint>();
            List<MyPoint> steinerpoint = null;
            List<MyPoint> breaklinepoint = null;
            // 
            foreach (Point3d pt in convexList)
                points.Add(new MyPoint(pt));

            if (steinerList != null)
            {
                steinerpoint = new List<MyPoint>();
                foreach (Point3d pt in steinerList)
                    steinerpoint.Add(new MyPoint(pt));
            }

            if (brkLList != null)
            {
                breaklinepoint = new List<MyPoint>();
                foreach (Line line in brkLList)
                {
                    breaklinepoint.Add(new MyPoint(line.StartPoint));
                    breaklinepoint.Add(new MyPoint(line.EndPoint));
                }
            }

            TriangulationProcess process = new TriangulationProcess(points, steinerpoint, breaklinepoint, true);
            triList = process.GetTriangles();

            // Z값 설정
            // 전체 점을 돌면서, x, y가 같은 점을 찾고, z값을 넣는다.
            List<Point3d> ptZList = new List<Point3d>();
            Point3d point;
            for (int i = 0; i < ptList.Count; i++)
            {
                point = new Point3d(ptList[i].X, ptList[i].Y, 0.0);
                ptZList.Add(point);
            }

            List<MyTriangle> triZList = new List<MyTriangle>();

            int idx1 = 0, idx2 = 0, idx3 = 0;
            Point3d pt1, pt2, pt3;

            foreach (MyTriangle tri in triList)
            {
                idx1 = ptZList.BinarySearch(0, ptZList.Count, tri.pt1, new Utils.Sort3DPoint());
                idx2 = ptZList.BinarySearch(0, ptZList.Count, tri.pt2, new Utils.Sort3DPoint());
                idx3 = ptZList.BinarySearch(0, ptZList.Count, tri.pt3, new Utils.Sort3DPoint());

                pt1 = new Point3d(ptList[idx1].X, ptList[idx1].Y, ptList[idx1].Z);
                pt2 = new Point3d(ptList[idx2].X, ptList[idx2].Y, ptList[idx2].Z);
                pt3 = new Point3d(ptList[idx3].X, ptList[idx3].Y, ptList[idx3].Z);

                triZList.Add(new MyTriangle(pt1, pt2, pt3));
            }

            triList = triZList;

            // Clear 
            if (ptList != null)
            {
                ptList.Clear();
                ptList = null;
            }
            if (convexList != null)
            {
                convexList.Clear();
                convexList = null;
            }
            if (steinerList != null)
            {
                steinerList.Clear();
                steinerList = null;
            }
            if (brkLList != null)
            {
                brkLList.Clear();
                brkLList = null;
            }
        }

        private void Render()
        {
            if (triList == null)
                return;

            // 삭제
            using (DocumentLock docLock = doc.LockDocument())
            {
                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    BlockTableRecord btr = tr.GetObject(db.CurrentSpaceId, OpenMode.ForWrite) as BlockTableRecord;

                    // 삼각망 레이어에 그린다.
                    foreach (MyTriangle tri in triList)
                    {
                        Polyline3d poly = new Polyline3d(
                            Poly3dType.SimplePoly,
                            new Point3dCollection(new[] { 
                            new Point3d(tri.pt1.X, tri.pt1.Y, tri.pt1.Z), 
                            new Point3d(tri.pt2.X, tri.pt2.Y, tri.pt2.Z), 
                            new Point3d(tri.pt3.X, tri.pt3.Y, tri.pt3.Z) }),
                            false);
                        
                        // 여기 XData 설정

                        poly.Closed = true;
                        btr.AppendEntity(poly);
                        tr.AddNewlyCreatedDBObject(poly, true);
                    }

                    ed.Regen();
                    tr.Commit();
                }
            }

            triList.Clear();
            triList = null;
        }

        public void DeleteTriangle()
        {
            // 삼각망 삭제
        }

    }
}
