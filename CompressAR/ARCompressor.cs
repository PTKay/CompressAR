using System;
using System.IO;

namespace CompressAR
{
    class ARCompressor
    {
        public static void CompressFiles(string[] files)
        {
            foreach (string file in files)
            {
                Console.WriteLine(file);
                CmdHelper.ExecuteCommand($"makecab /D CompressionType=LZX /l \"{Path.GetDirectoryName(file)}\" \"{file}\" {Path.GetFileName(file)}", true);
            }
        }

        public static void DecompressFiles(string[] files)
        {
            foreach (string file in files)
            {
                Console.WriteLine(file);
                CmdHelper.ExecuteCommand($"expand \"{file}\" \"{file}.unpack\"", true);

                if (!File.Exists($"{file}.unpack"))
                {
                    throw new InvalidOperationException("An error occured while decompressing the AR files");
                }

                File.Delete(file);
                File.Move($"{file}.unpack", file);
            }
        }
    }
}
