using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareaSemana3.Character_System;

namespace TareaSemana3.Adventure_System
{
    internal class StoryTeller
    {
        public static StoryTeller instance;

        private Queue<Chapter> story;
        private Chapter deathChapter;

        public Player player {  get; private set; }

        public StoryTeller(Chapter startChapter, Player player, Chapter deathChapter)
        {
            this.story = new Queue<Chapter>();
            story.Enqueue(startChapter);
            this.player = player;
            this.deathChapter = deathChapter;

            instance = this;
        }

        public void WriteStory()
        {
            if(story.Count <= 0) return;

            Chapter chapter = story.Dequeue();

            chapter.Read();
            Chapter? nextChapter = chapter.GetNextChapter();
            if(nextChapter != null) AddChapter(nextChapter);

            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        
            if(story.Count > 0) WriteStory();
        }

        public void AddChapter(Chapter chapter)
        {
            story.Enqueue(chapter);
        }

        public void PlayerDeath()
        {
            story.Clear();
            story.Enqueue(deathChapter);
        }
    }
}
