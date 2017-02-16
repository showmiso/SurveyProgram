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
    public partial class KGSurvey_LineInfo : Form
    {
        Document doc = null;
        Database db = null;
        Line line = null;

        public KGSurvey_LineInfo()
        {
            InitializeComponent();
        }

        public void SetInfo(Document _doc, Line _line)
        {
            doc = _doc;
            db = doc.Database;
            line = _line;

            cboLayerName.Items.AddRange(LayerUtil.GetCurrentLayerList(doc, db).ToArray());
            cboLayerName.Text = line.Layer;

            tbPt1X.Text = String.Format("{0:f3}", line.StartPoint.X);
            tbPt1Y.Text = String.Format("{0:f3}", line.StartPoint.Y);
            tbPt1Z.Text = String.Format("{0:f3}", line.StartPoint.Z);

            tbPt2X.Text = String.Format("{0:f3}", line.EndPoint.X);
            tbPt2Y.Text = String.Format("{0:f3}", line.EndPoint.Y);
            tbPt2Z.Text = String.Format("{0:f3}", line.EndPoint.Z);


            tbDist.Text = String.Format("{0:f3}", line.Length);
            tbAngle.Text = String.Format("{0:f3}", line.Angle);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            // 삭제
            using (DocumentLock docLock = doc.LockDocument())
            {
                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    line.Erase();
                    tr.Commit();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
