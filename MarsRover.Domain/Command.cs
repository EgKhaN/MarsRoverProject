using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Domain
{
    public class Command
    {
        public CommandType Type { get; set; }

        public Command(CommandType type)
        {
            this.Type = type;
        }
        public static Command CreateCommandTypeFromInput(char command)
        {
            switch (command)
            {
                case 'L':
                    return new Command(CommandType.L);
                case 'R':
                    return new Command(CommandType.R);
                case 'M':
                    return new Command(CommandType.M);
                default:
                    return null;
            }
        }
        public static List<Command> ConvertInputsToCommandList(string commandInput)
        {
            List<Command> commandList = new List<Command>();

            foreach (var c in commandInput.ToCharArray())
            {
                Command command = CreateCommandTypeFromInput(c);
                if (command != null)
                    commandList.Add(command);
            }

            return commandList;
        }

   
    }

    public enum CommandType
    {
        /// <summary> Left Turn, -90degree ,-1 in enum</summary>
        L = -1,
        /// <summary>Right Turn, 90degree , +1 in enum</summary>
        R = 1,
        /// <summary> Move , 1 unit, if North and East +1 , if South and West -1 </summary>
        M
    }
}
