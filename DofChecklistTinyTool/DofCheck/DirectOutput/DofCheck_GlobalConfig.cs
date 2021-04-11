using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TinyTools.DofChecklistTinyTool
{
    public class DofCheck_GlobalConfig : DofCheckPass
    {
        public string MainGlobalConfigFile = string.Empty;

        private string ConfigPath;

        public override void DoCheck()
        {
            ConfigPath = Path.GetDirectoryName(MainGlobalConfigFile);

            AppendCheckResult($"Check base config path : {ConfigPath}", Directory.Exists(ConfigPath) ? ECheckResultType.Silent : ECheckResultType.Error, "Invalid config path, check your GlobalConfig file selection");

            string[] globalConfigFiles = new string[0];
            if (Directory.Exists(ConfigPath)) {
                globalConfigFiles = Directory.GetFiles(ConfigPath, "GlobalConfig*.xml");
            }

            var globalConfigFilesResult = new DofChecklistResult() { Description = "GlobalConfig files enumeration" };

            if (globalConfigFiles.Length == 0) {
                globalConfigFilesResult.ErrorsList.Add($"No GlobalConfig files found in {ConfigPath}.");
            } else {
                if (MainGlobalConfigFile.ToLower().Contains(".xml.xml")) {
                    globalConfigFilesResult.ErrorsList.Add($"Reference File : {Path.GetFileName(MainGlobalConfigFile)}, Double extension detected (.xml.xml)");
                } else {
                    SHA1 sha = SHA1.Create();
                    FileStream fileStream = File.OpenRead(MainGlobalConfigFile);
                    fileStream.Position = 0;
                    var refSize = fileStream.Length;
                    var refSHA = string.Join("", sha.ComputeHash(fileStream));

                    globalConfigFilesResult.InformationsList.Add($"Reference File : {Path.GetFileName(MainGlobalConfigFile),-64} Size: {refSize,8} SHA: {refSHA}");
                    fileStream.Close();

                    foreach (var file in globalConfigFiles) {
                        if (file.Equals(MainGlobalConfigFile, StringComparison.InvariantCultureIgnoreCase)) {
                            continue;
                        }

                        if (file.ToLower().Contains(".xml.xml")) {
                            globalConfigFilesResult.WarningsList.Add($"{Path.GetFileName(file),-64}, Double extension detected (.xml.xml)");
                        } else {
                            fileStream = File.OpenRead(file);
                            fileStream.Position = 0;
                            // Compute the hash of the fileStream.
                            var curSHA = string.Join("", sha.ComputeHash(fileStream));
                            var sameFile = fileStream.Length == refSize && curSHA.Equals(refSHA, StringComparison.InvariantCultureIgnoreCase);
                            if (!sameFile) {
                                globalConfigFilesResult.WarningsList.Add($"{Path.GetFileName(file),-64} Size: {fileStream.Length,8}, File doesn't match reference (SHA is different).");
                            }
                            fileStream.Close();
                        }
                    }
                    sha.Dispose();

                    Results.Add(globalConfigFilesResult);
                }
            }
        }
    }
}
;