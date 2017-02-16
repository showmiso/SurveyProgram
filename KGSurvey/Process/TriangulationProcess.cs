using System;
using System.Collections.Generic;

using Autodesk.AutoCAD.Geometry;

using Poly2Tri;

namespace KGSurvey
{
    // 삼각형
    public class MyTriangle
    {
        public Point3d pt1, pt2, pt3;

        public MyTriangle() { }
        public MyTriangle(Point3d _pt1, Point3d _pt2, Point3d _pt3)
        {
            pt1 = _pt1; pt2 = _pt2; pt3 = _pt3;
        }
    };

    // 점
    public class MyPoint
    {
        public double X, Y, Z;
        public MyPoint() { }
        public MyPoint(Point3d pt) { X = pt.X; Y = pt.Y; Z = pt.Z; }
        public MyPoint(double _X, double _Y, double _Z) { X = _X; Y = _Y; Z = _Z; }
    };

    public class TriangulationProcess
    {
        public TimeSpan LastTriangulationDuration { get; private set; }
        public Exception LastTriangulationException { get; private set; }
        public Polygon polygon { get; private set; }

        // 생성자
        public TriangulationProcess(List<MyPoint> _points, List<MyPoint> _steinerpoints, List<MyPoint> _breaklinepoints, bool bMode)
        {
            List<PolygonPoint> points = null;
            List<PolygonPoint> steinerpoints = null;
            List<PolygonPoint> breaklinepoints = null;

            if (bMode == true)
            {
                IntoInfomation(_points, ref points);

                IntoInfomation(_steinerpoints, ref steinerpoints);

                IntoInfomation(_breaklinepoints, ref breaklinepoints);
            }
            else
            {
                IntoInfomation(_points, ref points, false, false);

                IntoInfomation(_steinerpoints, ref steinerpoints, false, false);

                IntoInfomation(_breaklinepoints, ref breaklinepoints, false, false);
            }

            polygon = new Polygon(points, steinerpoints, breaklinepoints);

            // 삼각망 생성 함수 호출
            Triangulate();
        }

        private bool IntoInfomation(List<MyPoint> MyPtList, ref List<PolygonPoint> PolyPtList, bool xflip = false, bool yflip = true)
        {
            if (MyPtList != null)
            {
                PolyPtList = new List<PolygonPoint>();
                foreach (MyPoint pt in MyPtList)
                    //PolyPtList.Add(new PolygonPoint(pt.X, pt.Y));
                    PolyPtList.Add(new PolygonPoint((xflip ? -1 : +1) * pt.X, (yflip ? -1 : +1) * pt.Y));
                return true;
            }
            else return false;
        }

        private void Triangulate()
        {
            var start = DateTime.Now;

            try
            {
                LastTriangulationException = null;

                // Triangulate 호출
                P2T.Triangulate(polygon);
            }
            catch (Exception e)
            {
                LastTriangulationException = e;
            }
            var stop = DateTime.Now;
            LastTriangulationDuration = (stop - start);
        }

        public List<MyTriangle> GetTriangles()
        {
            if (polygon.Triangles == null)
                return null;

            List<MyTriangle> triList = new List<MyTriangle>();

            MyTriangle MyTri;
            foreach (DelaunayTriangle tri in polygon.Triangles)
            {
                MyTri = new MyTriangle(new Point3d(tri.Points[0].X, -1 * tri.Points[0].Y, 0.0),
                                       new Point3d(tri.Points[1].X, -1 * tri.Points[1].Y, 0.0),
                                       new Point3d(tri.Points[2].X, -1 * tri.Points[2].Y, 0.0));
                triList.Add(MyTri);
            }

            return triList;
        }

    }// class end
}
