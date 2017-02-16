using System;
using System.Collections.Generic;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;

using Colors = Autodesk.AutoCAD.Colors;

namespace KGSurvey
{
    public class LayerUtil
    {
        // 레이어 켜고 끄는 함수
        public static void LayerTurnOnOff(Document doc, Database db, String strLayerName, bool bTurn)
        {
            using (DocumentLock docLock = doc.LockDocument())
            {
                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    LayerTable lt = tr.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;
                    LayerTableRecord ltr = tr.GetObject(lt[strLayerName], OpenMode.ForWrite) as LayerTableRecord;
                    ltr.IsOff = bTurn;
                    tr.Commit();
                }
            } 
        }

        // 레이어 유무 확인
        public static bool IsExist(Document doc, Database db, String strLayerName)
        {
            using (DocumentLock docLock = doc.LockDocument())
            {
                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    LayerTable lt = tr.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;

                    return lt.Has(strLayerName);
                }
            }
        }

        // 레이어 생성
        public static ObjectId CreateLayer(Document doc, Database db, String strLayerName, short color)
        {
            using (DocumentLock docLock = doc.LockDocument())
            {
                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    LayerTable lt = tr.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;
                    LayerTableRecord ltr = null;

                    if (lt.Has(strLayerName) == true)
                    {
                        return lt[strLayerName];
                    }
                    else
                    {
                        ltr = new LayerTableRecord();
                        ltr.Name = strLayerName;
                        ltr.Color = Colors.Color.FromColorIndex(Colors.ColorMethod.ByColor, color);

                        lt.UpgradeOpen();
                        lt.Add(ltr);
                        tr.AddNewlyCreatedDBObject(ltr, true);

                        tr.Commit();

                        return ltr.Id;
                    }

                }
            }
        }

        // 레이어 리스트를 가져와서 레이어 목록을 리턴하는 함수
        public static List<String> GetCurrentLayerList(Document doc, Database db)
        {
            List<String> layerList = new List<String>();

            using (DocumentLock docLock = doc.LockDocument())
            {
                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    LayerTable lt = tr.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;

                    foreach (ObjectId Id in lt)
                    {
                        LayerTableRecord ltr = tr.GetObject(Id, OpenMode.ForRead) as LayerTableRecord;

                        layerList.Add(ltr.Name);
                    }

                }
            }

            return layerList;
        }

        /// <summary>
        /// 레이어 이름으로 객체 가져오는 함수
        /// </summary>
        /// <param name="layName"></param>
        /// <returns></returns>
        public static ObjectIdCollection GetAllEntityByLayerName(Document doc, String layName)
        {
            TypedValue[] tvs = new TypedValue[1] {
                new TypedValue ((int) DxfCode.LayerName, layName)
            };

            SelectionFilter sf = new SelectionFilter(tvs);
            PromptSelectionResult psr = doc.Editor.SelectAll(sf);

            if (psr.Status == PromptStatus.OK)
                return new ObjectIdCollection(psr.Value.GetObjectIds());
            else return new ObjectIdCollection();
        }

    }
}
