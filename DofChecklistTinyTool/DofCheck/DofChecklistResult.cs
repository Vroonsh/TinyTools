using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyTools.DofChecklistTinyTool
{
    public class DofChecklistResult
    {
        public Image Result => ErrorsList.Count > 0 ? DofChecklistResources.ResultFail : WarningsList.Count > 0 ? DofChecklistResources.ResultWarning : DofChecklistResources.ResultOk;
        public string Description { get; set; } = string.Empty;
        public string Errors => $"{ErrorsList.Count}";
        public string Warnings => $"{WarningsList.Count}";
        public string Informations => $"{InformationsList.Count}";

        public List<string> ErrorsList = new List<string>();
        public List<string> WarningsList = new List<string>();
        public List<string> InformationsList = new List<string>();
    }
}
