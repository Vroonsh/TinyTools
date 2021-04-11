using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyTools.DofChecklistTinyTool
{
    public abstract class DofCheckPass
    {
        public List<DofChecklistResult> Results = new List<DofChecklistResult>();

        public enum ECheckResultType
        {
            Error,
            Warning,
            Info,
            Silent
        }

        protected void AppendCheckResult(string description, ECheckResultType resultType, string message)
        {
            var newResult = new DofChecklistResult() { Description = description };

            if (message != string.Empty) {
                switch (resultType) {
                    case ECheckResultType.Error:
                        newResult.ErrorsList.Add(message);
                        break;

                    case ECheckResultType.Warning:
                        newResult.WarningsList.Add(message);
                        break;

                    case ECheckResultType.Info:
                        newResult.InformationsList.Add(message);
                        break;
                }

                Results.Add(newResult);
            }
        }

        public abstract void DoCheck();
    }
}
