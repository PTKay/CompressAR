using System;
using System.Diagnostics;
using System.IO;

namespace CompressAR
{
    class CmdHelper
    {
        public static void ExecuteCommand(string cmd, bool printOutput = false)
        {
            Process proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = @"C:\Windows\System32\cmd.exe",
                    Arguments = "/c " + cmd,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    WorkingDirectory = Directory.GetCurrentDirectory()
                }
            };

            proc.Start();
            if (printOutput) Console.WriteLine(proc.StandardOutput.ReadToEnd());

            proc.WaitForExit();
        }
    }
}
