using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;

namespace KGSurvey
{
    public partial class KGSurvey_Contour : Form
    {
        private Document doc = null;
        private String strLayerName = "";
        public bool bContour = false;

        public KGSurvey_Contour(Document _doc, String _strLayerName)
        {
            InitializeComponent();

            doc = _doc;
            strLayerName = _strLayerName;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(tbMinItv.Text) == 0)
            {
                MessageBox.Show("조곡선 간격은 0이상이여야 합니다.`");
                return;
            }

            Contour cont = new Contour(doc);

            if (chkAuto.Checked == true)
            {
                cont.MakeContour(
                    Convert.ToDouble(tbMinItv.Text),
                    -1, -1, strLayerName); 
            }
            else
            {
                cont.MakeContour(
                    Convert.ToDouble(tbMinItv.Text),
                    Convert.ToDouble(tbMaxElev.Text),
                    Convert.ToDouble(tbMinElev.Text),
                    strLayerName);

            }

            bContour = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbMinItv_TextChanged(object sender, EventArgs e)
        {
            double dNum = 0;
            if (double.TryParse(tbMinItv.Text, out dNum) == false)
            {
                MessageBox.Show("소수를 입력해주세요.");
                return;
            }

            tbMaxItv.Text = (Convert.ToDouble(tbMinItv.Text) * 5).ToString();
        }

        private void chkAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAuto.Checked == true)
            {
                tbMinElev.Enabled = false;
                tbMaxElev.Enabled = false;
            }
            else
            {
                tbMinElev.Enabled = true;
                tbMaxElev.Enabled = true;
            }
        }

    }
}
