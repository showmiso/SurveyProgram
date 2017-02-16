using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using Excel = Microsoft.Office.Interop.Excel;

namespace KGSurvey
{
    public class ExportUtil
    {
        public static List<PointXYZCode> GetFileName(String strFileName)
        {
            List<PointXYZCode> ptCodeList = new List<PointXYZCode>();

            Excel.Application excelApp = null;
            Excel.Workbook wb = null;
            Excel.Worksheet ws = null;

            try
            {
                excelApp = new Excel.Application();

                wb = excelApp.Workbooks.Open(strFileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing
                    , Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing
                    , Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                ws = wb.Worksheets.get_Item(1) as Excel.Worksheet;

                Excel.Range usedRange = ws.UsedRange;
                Excel.Range range = usedRange.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);

                int row = range.Row;
                int col = range.Column;

                for (int i = 1; i <= row; i++)
                {
                    String[] strCol = new String[col];

                    for (int j = 1; j <= col; j++)
                    {
                        Excel.Range cell = ws.Cells[i, j] as Excel.Range;

                        if (cell.Value != null)
                            strCol[j - 1] = cell.Value.ToString();
                    }

                    Double dX, dY, dZ;
                    String strCode;

                    //int nNum = Convert.ToInt32(strCol[0]);
                    dX = Convert.ToDouble(strCol[2]);
                    dY = Convert.ToDouble(strCol[1]);
                    dZ = Convert.ToDouble(strCol[3]);
                    strCode = strCol[4].TrimEnd();

                    ptCodeList.Add(new PointXYZCode(dX, dY, dZ, strCode));
                }

                wb.Close(true);
                excelApp.Quit();
            }
            catch (Exception exp)
            {
                int a;
                a = 1;
            }
            finally
            {
                ReleaseExcelObject(ws);
                ReleaseExcelObject(wb);
                ReleaseExcelObject(excelApp);
            }

            return ptCodeList;
        }

        private static void ReleaseExcelObject(object obj) // 엑셀 해제 시켜주는 프로그램
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (System.Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
