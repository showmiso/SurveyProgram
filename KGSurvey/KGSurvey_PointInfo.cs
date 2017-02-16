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
    public partial class KGSurvey_PointInfo : Form
    {
        Document doc = null;
        Database db = null;
        DBPoint dbPoint = null;
        public int nState = 0;

        public KGSurvey_PointInfo()
        {
            InitializeComponent();
        }

        public void SetInfo(Document _doc, DBPoint _dbPoint, int nIdx)
        {
            doc = _doc;
            db = doc.Database;
            dbPoint = _dbPoint;

            tbNum.Text = nIdx.ToString();
            cboLayer.Items.AddRange(LayerUtil.GetCurrentLayerList(doc, db).ToArray());
            cboLayer.Text = dbPoint.Layer;

            tbX.Text = String.Format("{0:f3}", dbPoint.Position.X);
            tbY.Text = String.Format("{0:f3}", dbPoint.Position.Y);
            tbZ.Text = String.Format("{0:f3}", dbPoint.Position.Z);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            // 삭제
            using (DocumentLock docLock = doc.LockDocument())
            {
                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    dbPoint.Erase();
                    tr.Commit();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // 정점 정보를 바꾼다.

            // 코드가 존재하지 않는 코드라면, 새로운 레이어를 생성한다.


            using (DocumentLock docLock = doc.LockDocument())
            {
                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    dbPoint.Layer = cboLayer.Text;


                    tr.Commit();
                }
            }


            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
