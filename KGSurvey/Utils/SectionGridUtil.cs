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
    public class MyHeader : SourceGrid.Cells.ColumnHeader
    {
        public MyHeader(object value)
            : base(value)
        {
            SourceGrid.Cells.Views.ColumnHeader view = new SourceGrid.Cells.Views.ColumnHeader();
            view.Font = new System.Drawing.Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold); // 글자 크기와 글자체 등을 설정한다.
            view.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            this.ResizeEnabled = false;

            // Header Hold를 위한 추가
            SourceGridHeaderEvent sgHeaderEvent = new SourceGridHeaderEvent();
            this.AddController(sgHeaderEvent);

            View = view;
            AutomaticSortEnabled = false;
        }
        public MyHeader(object value, FontFamily fontFam, float fFontSize, FontStyle fontStyle,
            DevAge.Drawing.ContentAlignment Align = DevAge.Drawing.ContentAlignment.MiddleCenter)
            : base(value)
        {
            SourceGrid.Cells.Views.ColumnHeader view = new SourceGrid.Cells.Views.ColumnHeader();
            view.Font = new System.Drawing.Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold); // 글자 크기와 글자체 등을 설정한다.
            view.TextAlignment = Align; //  DevAge.Drawing.ContentAlignment.MiddleCenter;

            // Header Hold를 위한 추가
            SourceGridHeaderEvent sgHeaderEvent = new SourceGridHeaderEvent();
            this.AddController(sgHeaderEvent);

            View = view;
            AutomaticSortEnabled = false;
        }
    }

    public class MyCell : SourceGrid.Cells.Cell
    {
        public MyCell(object value)
            : base(value)
        {
            SourceGrid.Cells.Views.Cell view = new SourceGrid.Cells.Views.Cell();
            view.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;

            View = view;
        }
    }

    public class MyCheckBoxCell : SourceGrid.Cells.CheckBox
    {
        public MyCheckBoxCell(object value, bool bChecked = false)
        {
            SourceGrid.Cells.Views.Cell view = new SourceGrid.Cells.Views.Cell();
            view.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;

            View = view;

            this.Checked = bChecked;
        }
    }

    public class SourceGridHeaderEvent : SourceGrid.Cells.Controllers.ControllerBase
    {
        public override void OnMouseUp(SourceGrid.CellContext sender, System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(sender, e);

            sender.Grid.AutoSizeCells();
        }
    }
}
