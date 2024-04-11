using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaSemana3.Adventure_System
{
    internal class Selection : Chapter
    {
        Option[] options;
        private Option selectedOption;

        public Selection(string[] text, Option[] options) : base(text, null)
        {
            this.options = options;
        }

        public override void Read()
        {
            base.Read();
            Console.WriteLine("Select an option...");
            Console.WriteLine();


            for (int i = 0; i < options.Length; i++)
            {
                options[i].SetNumber(i + 1);
                options[i].Read();
            }

            Console.WriteLine("Select the number...");
            Console.WriteLine();

            bool flag = false;

            while (!flag)
            {
                int option;

                try
                {
                    option = int.Parse(Console.ReadLine()) - 1;
                }

                catch(Exception e)
                {
                    option = 0;
                }

                if (option < 0 || option >= options.Length)
                {
                    flag = false;
                    Console.WriteLine("Choose a valid number...");
                    continue;
                }

                flag = options[option].Requirement();

                if (!flag)
                {
                    Console.WriteLine($"{StoryTeller.instance.player.Name} don't meet the requirements. Choose another option...");
                    continue;
                }

                selectedOption = options[option];
            }
        }

        public override Chapter? GetNextChapter()
        {
            return selectedOption.GetNextChapter();
        }
    }
}
