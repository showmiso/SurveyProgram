using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KGSurvey
{
    public partial class KGSurvey_DataList : Form
    {
        //List<bChecked> chkList = new List<bChecked>();
        int nLength = 0;

        public KGSurvey_DataList()
        {
            InitializeComponent();

            this.ControlBox = false;

            InitSourceGrid();
        }

        private void InitSourceGrid()
        {
            grdPoints.Redim(1, 8);

            grdPoints[0, 0] = new MyHeader("");
            grdPoints[0, 1] = new MyHeader("North(Y)");
            grdPoints[0, 2] = new MyHeader("East(X)");
            grdPoints[0, 3] = new MyHeader("Elev(Z)");
            grdPoints[0, 4] = new MyHeader("Code");
            grdPoints[0, 5] = new MyHeader("Tri");
            grdPoints[0, 6] = new MyHeader("Cls");
            grdPoints[0, 7] = new MyHeader("Exc");
        }

        public void SetPtList(List<PointXYZCode> ptCodeList)
        {
            nLength = ptCodeList.Count;
            grdPoints.Redim(nLength + 1, 8);

            for (int i = 0; i < nLength; i++)
            {
                grdPoints[i + 1, 0] = new MyHeader(i + 1);
                grdPoints[i + 1, 1] = new MyCell(ptCodeList[i].pt.X);
                grdPoints[i + 1, 2] = new MyCell(ptCodeList[i].pt.Y);
                grdPoints[i + 1, 3] = new MyCell(ptCodeList[i].pt.Z);
                grdPoints[i + 1, 4] = new MyCell(ptCodeList[i].strCode);

                grdPoints[i + 1, 5] = new MyCheckBoxCell("", true);
                grdPoints[i + 1, 6] = new MyCheckBoxCell("");
                grdPoints[i + 1, 7] = new MyCheckBoxCell("");
            }

            grdPoints.AutoSizeCells();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Checkbox에 변경된 사항을 List<bChecked>에 설정한다.

            this.Close();
        }

        private void btnTri_Click(object sender, EventArgs e)
        {
            CheckedAll(5);
        }

        private void btnCls_Click(object sender, EventArgs e)
        {
            CheckedAll(6);
        }

        private void btnExc_Click(object sender, EventArgs e)
        {
            CheckedAll(7);
        }

        private void CheckedAll(int nIdx)
        {
            bool bChecked = Convert.ToBoolean(grdPoints[1, nIdx].Value);

            for (int i = 0; i < nLength; i++)
            {
                grdPoints[i + 1, nIdx] = new MyCheckBoxCell("", !bChecked);
            }

            grdPoints.Refresh();
        }

        private void grdPoints_Click(object sender, EventArgs e)
        {
            grdPoints.Refresh();
        }

    }
}
