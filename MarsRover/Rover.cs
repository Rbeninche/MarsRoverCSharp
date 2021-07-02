using System;
namespace MarsRover
{
    public class Rover
    {
        public string Mode { get; set; }
        public int Position { get; set; }
        public int GeneratorWatts { get; set; }

        public Rover(int position)
        {
            Position = position;
            Mode = "NORMAL";
            GeneratorWatts = 110;
        }

        public void ReceiveMessage(Message message)
        {

            for (int i = 0; i < message.Commands.Length; i++)
            {
                string commandType = message.Commands[i].CommandType;
             
                if (commandType == "MODE_CHANGE")
                {
                    Mode = message.Commands[i].NewMode;
                }
                else if (commandType == "MOVE")
                {
                    if (Mode != "LOW_POWER")
                    {
                        Position = message.Commands[i].NewPostion;
                    }
                }
                else if(commandType != "MODE_CHANGE" || commandType != "MOVE")
                {
                  
                  throw new ArgumentException("This commantype is denied");
                   
                }
            }

            return;
        }


        public override string ToString()
        {
            return "Position: " + Position + " - Mode: " + Mode + " - GeneratorWatts: " + GeneratorWatts; 
        }

    }
}
