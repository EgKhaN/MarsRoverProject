using MarsRover.Domain;
using System;
using System.IO;
using System.Reflection;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = GetInputFilePath(args);

            Input input = new Input();
            input.ConvertInputFromFile(path);
            input.ExecuteCommands();
            input.ShowOutput();

            Console.ReadLine();
        }

        private static string GetInputFilePath(string[] args)
        {
            bool workingFromConsole = args.Length > 0 && !string.IsNullOrEmpty(args[0]);

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string path = workingFromConsole ?
                Path.Combine(workingDirectory, args[0])
                : Path.Combine(projectDirectory, @"Data\input.txt");
            return path;
        }
    }
}
