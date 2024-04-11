using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaSemana3.Adventure_System
{
    internal class Chapter
    {
        protected string[] text;

        protected Chapter? nextChapter;

        public Chapter(string[] text, Chapter? nextChapter)
        {
            this.text = text;
            this.nextChapter = nextChapter;
        }

        public virtual void Read()
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.WriteLine(text[i]);
            }
        }

        public virtual Chapter? GetNextChapter()
        {
            return nextChapter;
        }
    }
}
