using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MarsRover.Domain
{
    public class Input
    {
        public Plateau PlateauInput { get; set; }

        public List<ConvertedRoverCommandInput> RoverCommandInputList { get; set; }

        public Input()
        {
            RoverCommandInputList = new List<ConvertedRoverCommandInput>();
        }

        public void ConvertInputFromFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) {
                Console.WriteLine("File path is empty!");
                return;
            }


            int lineIndex = 0;
            string line;

            // Read the file and display it line by line.  
            using (var fileStream = File.OpenRead(fileName))
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader(fileStream))
                {
                    Console.WriteLine("**********INPUT**********");
                    while ((line = file.ReadLine()) != null)
                    {
                        if (lineIndex == 0)
                        {
                            this.PlateauInput = Plateau.Parse(line);
                        }
                        if (lineIndex > 0 && lineIndex % 2 == 1)
                        {
                            this.RoverCommandInputList.Add(new ConvertedRoverCommandInput
                            {
                                Rover = Rover.Parse(line)
                            });
                        }
                        else if (lineIndex > 0 && lineIndex % 2 == 0)
                        {
                            if (this.RoverCommandInputList.Last()?.Rover != null)
                                this.RoverCommandInputList.Last().CommandInput = line;
                        }

                        lineIndex++;
                        System.Console.WriteLine(line);

                    }

                    file.Close();
                };
            }
        }

        public void ShowOutput()
        {
            Console.WriteLine("\n" + "**********OUTPUT**********");

            foreach (var rover in RoverCommandInputList.Select(q => q.Rover))
            {
                Console.WriteLine(rover.Output());
            }
        }
        
        public void ExecuteCommands()
        {
            foreach (var item in RoverCommandInputList)
            {
                item.Rover.ExecuteCommands(item.CommandInput);
            }
        }
    }
}
