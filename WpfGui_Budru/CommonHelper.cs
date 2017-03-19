using System;
using System.Diagnostics;
using System.IO;

namespace WpfGui_Budru {
    internal class CommonHelper {
        public CommonHelper(string buildTpye) {
            this.buildType = buildTpye;
        }

        private string buildType;

        private ProcessStartInfo stinfo = new ProcessStartInfo();



        public void openTargetFile(string param) {
            stinfo.FileName = this.getTargetFilePath() ;
            stinfo.UseShellExecute = true;
            stinfo.CreateNoWindow = true;
            Process.Start(stinfo.FileName, param);
        }


        private string getTargetFilePath() {
            string targetFilePath = "";
            if (this.buildType.ToLower().Equals("debug")) {
                targetFilePath = @"C:\Users\Christian\Documents\Visual Studio 2017\Projects\getResult\getResult\bin\Debug\getResult.exe";
            } 
            else if (this.buildType.ToLower().Equals("release")) {
                string currentDirectory = Environment.CurrentDirectory;
                targetFilePath = currentDirectory + "\\getResult.exe";
            }
            return targetFilePath;
        }

        public string getCurrentDirectory() {
            return Environment.CurrentDirectory;
        }

        public string getJSONFilePath() {
            string target = AppDomain.CurrentDomain.BaseDirectory + "\\data.json";
            return target;
            
        }
        

    }
}