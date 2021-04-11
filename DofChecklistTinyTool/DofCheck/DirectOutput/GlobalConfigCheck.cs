using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyTools.DofChecklistTinyTool
{
    public class GlobalConfig
    {
        public int LedControlMinimumEffectDurationMs = 60;
        public int LedControlMinimumRGBEffectDurationMs = 120;
        public int PacLedDefaultMinCommandIntervalMs = 10;
        public string IniFilesPath = string.Empty;
        public string ShapeDefintionFilePattern = string.Empty;
        public string CabinetConfigFilePattern = string.Empty;
        public string TableConfigFilePatterns = string.Empty;
        public bool EnableLogging = true;
        public bool ClearLogOnSessionStart = true;
        public string LogFilePattern = ".\\DirectOutput.log";
    }
}
