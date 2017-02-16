using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;

namespace KGSurvey
{
    public static class XDataType
    {
        public static String strPoint   = "측점";
        public static String strLine    = "현황선";
        public static String strTri     = "삼각망";
        public static String strContour = "등고선";
    }

    public class Utils
    {
        public const double eps = 1e-5;

        // 두 점이 같은지 판단하는 함수
        public static bool IsSamePoint(Point3d p1, Point3d p2)
        {
            return IsSamePoint(p1.X, p1.Y, p2.X, p2.Y);
        }

        public static bool IsSamePoint(MyPoint p1, MyPoint p2)
        {
            return IsSamePoint(p1.X, p1.Y, p2.X, p2.Y);
        }

        public static bool IsSamePoint(double x1, double y1, double x2, double y2)
        {
            if ((Math.Abs(x1 - x2) <= eps) && ((Math.Abs(y1 - y2) <= eps)))
                return true;

            return false;
        }

        // 점 정렬
        public static void ArrayPointList(ref List<Point3d> ptList)
        {
            if (ptList == null) return;

            Point3dCollection pts = new Point3dCollection();
            foreach (Point3d pt in ptList)
                pts.Add(pt);

            Point3d[] raw3dpt = new Point3d[ptList.Count];
            pts.CopyTo(raw3dpt, 0);
            Array.Sort(raw3dpt, new Sort3DPoint());

            Point3dCollection Sortedpts = new Point3dCollection(raw3dpt);

            ptList.Clear();
            ptList = null;

            ptList = new List<Point3d>();

            for (int i = 0; i < Sortedpts.Count; i++)
                ptList.Add(Sortedpts[i]);
        }

        // 점 정렬 함수
        internal class Sort3DPoint : IComparer<Point3d>
        {
            public int Compare(Point3d a, Point3d b)
            {
                if ((a.X == b.X) && (a.Y == b.Y))
                    return 0;

                if ((a.X < b.X) || ((a.X == b.X) && (a.Y < b.Y)))
                    return -1;

                return 1;
            }
        }

        public static void GetRegexLayerName(ref String strLayerName)
        {
            // 레이어 이름에서 특수문자 제거한다.
            strLayerName = strLayerName.Replace(".", "_").Trim();
            strLayerName = Regex.Replace(strLayerName, @"[^a-zA-Z0-9가-힣_-]", "", RegexOptions.Singleline);
            //strLayerName = strLayerName.Replace(@"\", "").Trim();
            //strLayerName = strLayerName.Replace("%", "").Trim();
        }

        // 폴리라인으로 Point3dCollection 만들기
        public static Point3dCollection PolyToPoint3dCollection(Polyline pline)
        {
            Point3dCollection ptColl = new Point3dCollection();
            for (int i = 0; i < pline.NumberOfVertices; i++)
            {
                Point3d pt = pline.GetPoint3dAt(i);
                ptColl.Add(pt);
            }

            if (ptColl[0] == ptColl[ptColl.Count - 1])
            {
                ptColl.RemoveAt(ptColl.Count - 1);
            }
            else
            {
                //ptColl.Add(ptColl[0]); 
            }
              
            return ptColl;
        }

        // 폴리라인으로 Point3dCollection 만들기
        public static Point2dCollection PolyToPoint2dCollection(Polyline pline)
        {
            Point2dCollection ptColl = new Point2dCollection();
            for (int i = 0; i < pline.NumberOfVertices; i++)
            {
                Point2d pt = pline.GetPoint2dAt(i);
                ptColl.Add(pt);
            }

            if (ptColl[0] == ptColl[ptColl.Count - 1])
            {
                ptColl.RemoveAt(ptColl.Count - 1);
            }
            else
            {
                //ptColl.Add(ptColl[0]); 
            }

            return ptColl;
        }

        public static Point3dCollection Point3dToPoint2d(Point2dCollection pt2dColl)
        {
            Point3dCollection pt3dColl = new Point3dCollection();

            for (int i = 0; i < pt2dColl.Count; i++)
            {
                pt3dColl.Add(new Point3d(pt2dColl[i].X, pt2dColl[i].Y, 0));
            }
            
            return pt3dColl;
        }

        // 정점 확인용 함수
        // Point3dCollection으로 List<Point3d>
        public static List<Point3d> CollToList(Point3dCollection ptColl)
        {
            List<Point3d> ptList = new List<Point3d>();

            foreach (Point3d pt in ptColl)
            {
                ptList.Add(pt);
            }

            return ptList;
        }

    }
}
