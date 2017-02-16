using System;
using System.Drawing;
using System.Collections.Generic;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;

namespace KGSurvey
{
    public class SelectUtil
    {
        // 전체 선택
        public static ObjectIdCollection SelectAll(Editor ed, String strLayerName, String strType)
        {
            TypedValue[] tv = null;
            if (strLayerName == "")
            {
                tv = new TypedValue[1] { 
                        new TypedValue((int)DxfCode.Start, strType) };
            }
            else
            {
                tv = new TypedValue[2] { 
                        new TypedValue((int)DxfCode.LayerName, strLayerName),
                        new TypedValue((int)DxfCode.Start, strType)};
            }

            SelectionFilter sf = new SelectionFilter(tv);

            PromptSelectionResult psr = ed.SelectAll(sf);

            if (psr.Status == PromptStatus.OK)
            {
                return new ObjectIdCollection(
                    psr.Value.GetObjectIds());
            }

            return new ObjectIdCollection();
        }

        // 폴리선 하나 선택하는 함수
        public static ObjectId SelectOnePolyline(Editor ed, String strLayerName, String strType, String strMsg = "폴리선을 하나 선택해주세요.")
        {
            while (true)
            {
                TypedValue[] tv = null;
                if (strLayerName == "")
                {
                    tv = new TypedValue[1] { 
                        new TypedValue((int)DxfCode.Start, strType) };
                }
                else
                {
                    tv = new TypedValue[2] { 
                        new TypedValue((int)DxfCode.LayerName, strLayerName),
                        new TypedValue((int)DxfCode.Start, strType)};
                }

                SelectionFilter sf = new SelectionFilter(tv);
                PromptSelectionOptions pso = new PromptSelectionOptions();
                pso.SingleOnly = true;
                pso.MessageForAdding = strMsg;

                PromptSelectionResult psr = ed.GetSelection(pso, sf);
                if (psr.Status == PromptStatus.OK)
                {
                    if (psr.Value.Count == 1)
                    {
                        return psr.Value.GetObjectIds()[0];
                    }
                    else
                    {
                        ed.WriteMessage("폴리선을 하나만 선택해주세요.");
                    }
                }
                else
                {
                    return ObjectId.Null;
                }
            }
        }

        // 폴리선 내부의 객체 선택하는 함수
        public static ObjectIdCollection SelectInPolyline(Editor ed, String strLayerName, String strType, Point3dCollection ptColl, bool bDetectAttaced)
        {
            // 2-5
            TypedValue[] tv = new TypedValue[2] { 
                new TypedValue((int)DxfCode.LayerName, strLayerName),
                new TypedValue((int)DxfCode.Start, strType),
            };

            SelectionFilter sf = new SelectionFilter(tv);

            PromptSelectionResult psr = null;

            if (bDetectAttaced == true)
            {
                // 내부와 겹쳐져 있는 MText도 선택
                // Selects objects within and crossing a polygon defined by specifying points. 
                // The polygon can be any shape but cannot cross or touch itself.
                psr = ed.SelectCrossingPolygon(ptColl, sf);
            }
            else
            {
                // 내부의 MText만 선택
                // Selects objects completely inside a polygon defined by points.
                // The polygon can be any shape but cannot cross or touch itself.
                psr = ed.SelectWindowPolygon(ptColl, sf);
            }

            if (psr.Status == PromptStatus.OK)
            {
                return new ObjectIdCollection(
                    psr.Value.GetObjectIds());
            }

            return new ObjectIdCollection();
        }


        //// 1
        //TypedValue[] tv = new TypedValue[1] { 
        //    new TypedValue((int)DxfCode.Start, strType) };

        //// 2-1
        //TypedValue[] tv = new TypedValue[2];
        //tv.SetValue(new TypedValue((int)DxfCode.Start, strType), 0);
        //tv.SetValue(new TypedValue((int)DxfCode.LayerName, strLayerName), 1);

        //// 2-2
        //TypedValue[] tv = new TypedValue[2];
        //tv[0] = new TypedValue((int)DxfCode.Start, strType);
        //tv[1] = new TypedValue((int)DxfCode.LayerName, strLayerName);

        //// 2-3
        //TypedValue[] tv = new TypedValue[] {
        //    //new TypedValue((int)DxfCode.Operator,   "<AND"),
        //    new TypedValue((int)DxfCode.Start,      strType),
        //    new TypedValue((int)DxfCode.LayerName,  strLayerName),
        //    //new TypedValue((int)DxfCode.Operator,   "AND>"),
        //};

        //// 2-4
        //TypedValue[] tv = new TypedValue[] {
        //    new TypedValue((int)DxfCode.Operator,   "<AND"),
        //    new TypedValue((int)DxfCode.Start,      strType),
        //    //new TypedValue((int)DxfCode.Operator,   "&"),
        //    new TypedValue((int)DxfCode.LayerName,  strLayerName),
        //    new TypedValue((int)DxfCode.Operator,   "AND>"),
        //};

    }
}
