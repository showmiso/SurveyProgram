using System;
using System.Collections.Generic;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;

using Application = Autodesk.AutoCAD.ApplicationServices.Application;

namespace KGSurvey
{
    public class MainProgram
    {
        [CommandMethod("KGS")]
        public void MainFunction()
        {
            KGSurvey Survey = new KGSurvey();
            Survey.Show();
        }
    }
}
