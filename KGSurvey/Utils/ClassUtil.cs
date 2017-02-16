using System;
using System.Collections.Generic;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;

namespace KGSurvey
{
    public class bChecked
    {
        public bool bTri = true;
        public bool bCls = false;
        public bool bExc = false;
    }

    public class State
    {
        public bool bLoaded = false;    // 측점 파일 열기
        public bool bLinked = false;    // 코드 연결
        public bool bTriangle = false;  // 삼각망
        public bool bContour = false;   // 등고선
        public bool bMarked = false;    // 측점 표기
    }

    public class PointXYZCode
    {
        public Point3d pt;
        public String strCode;

        public PointXYZCode(Point3d _pt, String _strCode)
        {
            pt = _pt;
            strCode = _strCode;
        }
        public PointXYZCode(double _x, double _y, double _z, String _strCode)
        {
            pt = new Point3d(_x, _y, _z);
            strCode = _strCode;
        }
    }

}
