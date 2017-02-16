using System;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;

namespace KGSurvey
{
    public class ZoomUtil
    {
        // Zoom 함수
        public static void ZoomExtend()
        {
            Object acadObject = Application.AcadApplication;
            acadObject.GetType().InvokeMember("ZoomExtents",
                System.Reflection.BindingFlags.InvokeMethod, null, acadObject, null);
        }

        /// <summary>
        /// Entity로 Zoom하는 함수
        /// </summary>
        /// <param name="ed"></param>
        /// <param name="ent">보통 폴리선을 사용한다.</param>
        /// <param name="dMargin">좌우 여백 여유 값</param>
        public static bool ZoomExtend(Editor ed, Entity ent, Double dMargin = 2.0)
        {
            try
            {
                Extents3d ext = ent.GeometricExtents;
                ext.TransformBy(ed.CurrentUserCoordinateSystem.Inverse());
                ZoomWindow(ed, ext.MinPoint, ext.MaxPoint, dMargin);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private static void ZoomWindow(Editor ed, Point3d ptMin, Point3d ptMax, Double dMargin)
        {
            Point2d ptMin2d = new Point2d(ptMin.X - dMargin, ptMin.Y - dMargin);
            Point2d ptMax2d = new Point2d(ptMax.X + dMargin, ptMax.Y + dMargin);

            ViewTableRecord view = new ViewTableRecord();
            view.CenterPoint = ptMin2d + ((ptMax2d - ptMin2d) / 2.0);
            view.Width = ptMax2d.X - ptMin2d.Y;
            view.Height = ptMax2d.Y - ptMin2d.Y;

            ed.SetCurrentView(view);
        }
    }
}
