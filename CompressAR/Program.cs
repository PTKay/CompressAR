using System;
using System.IO;
using System.Linq;

namespace CompressAR
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length <= 1)
            {
                String procName = AppDomain.CurrentDomain.FriendlyName;

                Console.WriteLine("CompressAR by PTKickass, using 'makecab' and 'expand'.");
                Console.WriteLine();
                Console.WriteLine($"Usage: {procName} [-c | -d] [file [file2 ...] | dir]");
                Console.WriteLine("\t -c: Compress a file, multiple files or a directory");
                Console.WriteLine("\t -d: Decompress a file, multiple files or a directory");
                Console.ReadLine();
                return;
            }

            string[] files;

            if (File.GetAttributes(args[1]).HasFlag(FileAttributes.Directory))
            {
                files = Directory.GetFiles(args[1], "*.ar.*", SearchOption.AllDirectories);
            }
            else
            {
                files = args.Skip(1).Where(s => s.Contains(".ar.")).ToArray();
            }

            if (files == null || files.Length == 0)
            {
                throw new InvalidOperationException("Invalid files specified. Files must be AR files");
            }

            switch(args[0])
            {
                case "-c":
                    ARCompressor.CompressFiles(files);
                    break;
                case "-d":
                    ARCompressor.DecompressFiles(files);
                    break;
                default:
                    throw new InvalidOperationException("Invalid operation mode specified");
            }
        }
    }
}
