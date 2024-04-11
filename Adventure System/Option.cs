using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaSemana3.Adventure_System
{
    internal class Option : Chapter
    {
        protected int number;

        public Option(string[] text, Chapter? nextChapter) : base(text, nextChapter) 
        {
            this.number = 0;
        }
        
        public void SetNumber(int number)
        {
            this.number = number;
        }

        public override void Read()
        {
            Console.WriteLine("(" + number + ") " + text[0]);
        }

        public virtual bool Requirement()
        {
            return true;
        }

        public virtual void Consequences() { }

        public override Chapter? GetNextChapter()
        {
            Consequences();
            return base.GetNextChapter();
        }
    }
}
