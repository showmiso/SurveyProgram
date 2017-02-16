using System;
using System.Collections.Generic;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;

namespace KGSurvey
{
    public class ConvexHull
    {
        private List<Point3d> ptList = null;
        private List<Point3d> convexList = null;

        private double cross(Point3d O, Point3d A, Point3d B)
        {
            return (A.X - O.X) * (B.Y - O.Y) - (A.Y - O.Y) * (B.X - O.X);
        }

        private Point3d[] CopyOfRange(Point3d[] src, int start, int end)
        {
            int len = end - start;
            Point3d[] dest = new Point3d[len];
            Array.Copy(src, start, dest, 0, len);
            return dest;
        }

        //public   List<Point3d> ComputeConvexHull(List<Point3d> _ptList)
        //{

        //    convexList = new List<Point3d>();

        //    if (_ptList == null)
        //        return null;
        //    ptList = _ptList;

        //    Point3d vFirstPnt = _ptList[0];
        //    Point3d vNowPnt = vFirstPnt;
        //    bool flag = true;

        //    for (int i = 0; i < ptList.Count; i++)
        //    {
        //        double minAngle = -1, minY = 0;
        //        Point3d vMatchPnt = new Point3d();

        //        foreach (Point3d vPnt in ptList)
        //        {
        //            Vector2d oVect = new Point2d(vNowPnt.X, vNowPnt.Y).GetVectorTo(new Point2d(vPnt.X, vPnt.Y));
        //            if ((oVect.X == 0 && oVect.Y == 0) || convexList.Contains(vPnt)) continue;
        //            double dAngle = oVect.Angle;

        //            if ((flag && vNowPnt.Y <= vPnt.Y) || (!flag && vNowPnt.Y >= vPnt.Y))
        //            {
        //                if (minAngle == -1 || dAngle < minAngle || (dAngle == minAngle && oVect.Y < minY))
        //                {
        //                    vMatchPnt = vPnt;
        //                    minAngle = dAngle;
        //                    minY = oVect.Y;
        //                }
        //            }
        //        }


        //        if (vMatchPnt == new Point3d())
        //        {
        //            flag = false;
        //            i --;
        //            continue;
        //        }

        //        if (vMatchPnt == vFirstPnt)
        //        {
        //            convexList.Insert(0, vMatchPnt);
        //            break;
        //        }

        //        convexList.Add(vMatchPnt);
        //        vNowPnt = vMatchPnt;
        //    }

        //    return convexList;
        //}

        public List<Point3d> ComputeConvexHull(List<Point3d> _ptList)
        {
            if (_ptList == null)
                return null;
            ptList = _ptList;

            int k = 0;
            // 안될 것 같은데...
            Point3d[] ptArr = new Point3d[2 * ptList.Count];

            // Build Lower Hull
            for (int i = 0; i < ptList.Count; ++i)
            {
                while (k >= 2 && cross(ptArr[k - 2], ptArr[k - 1], ptList[i]) <= 0)
                    k--;
                ptArr[k++] = ptList[i];
            }

            // Build Upper Hull
            for (int i = ptList.Count - 2, t = k + 1; i >= 0; i--)
            {
                while (k >= t && cross(ptArr[k - 2], ptArr[k - 1], ptList[i]) <= 0)
                    k--;
                ptArr[k++] = ptList[i];
            }

            if (k > 1)
                ptArr = CopyOfRange(ptArr, 0, k - 1);

            if (convexList == null)
                convexList = new List<Point3d>();

            Point3d pt;
            for (int i = 0; i < k - 1; i++)
            {
                pt = new Point3d(ptArr[i].X, ptArr[i].Y, ptArr[i].Z);
                convexList.Add(pt);
            }

            return convexList;
        }
    }
}
