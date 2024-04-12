using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareaSemana3.Character_System;

namespace TareaSemana3.Adventure_System
{
    internal class Fight : Chapter
    {
        Enemy[] enemies;
        private bool win;

        public Fight(Enemy[] enemies, string[] text, Chapter? nextChapter) : base(text, nextChapter)
        {
            this.enemies = enemies;
        }

        public override void Read()
        {
            base.Read();
            Console.WriteLine($"{StoryTeller.instance.player.Name}, health: {StoryTeller.instance.player.Health} attack: {StoryTeller.instance.player.CalculateAttack()} armor: {StoryTeller.instance.player.CalculateArmor()}");
            Console.WriteLine("Target an enemy...");
            Console.WriteLine();

            bool end;

            do
            {
                for (int i = 0; i < enemies.Length; i++)
                {
                    if (enemies[i].IsAlive()) Console.WriteLine($"({i + 1}) {enemies[i].Name}, health: {enemies[i].Health} attack: {enemies[i].CalculateAttack()} armor: {enemies[i].CalculateArmor()}");
                    else Console.WriteLine($"({i + 1}) {enemies[i].Name}, DEATH");
                }

                Console.WriteLine("Target by the number...");
                Console.WriteLine();

                bool flag = false;

                int option = 0;

                while (!flag)
                {
                    int.TryParse(Console.ReadLine(), out option);
                    if (option > 0) option--;

                    if (option < 0 || option >= enemies.Length)
                    {
                        flag = false;
                        Console.WriteLine("Choose a valid target...");
                        continue;
                    }

                    if (!enemies[option].IsAlive())
                    {
                        flag = false;
                        Console.WriteLine($"{enemies[option].Name} is already death. Think of another target...");
                        continue;
                    }

                    flag = true;
                }

                end = ResolveTurn(enemies[option]);
            } while (!end);

            if (win) Reward();
        }

        public bool ResolveTurn(Enemy target)
        {
            StoryTeller.instance.player.Damage(target);
            Console.WriteLine($"{StoryTeller.instance.player.Name} attacked {target.Name}, leaving him in {target.Health} health points.");

            bool winCondition = true;

            for(int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].IsAlive())
                {
                    winCondition = false;
                    break;
                }
            }

            if(winCondition)
            {
                win = true;
                Console.WriteLine($"{StoryTeller.instance.player.Name} won the fight!");
                return true;
            }

            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].IsAlive())
                {
                    enemies[i].Damage(StoryTeller.instance.player);
                    Console.WriteLine($"{enemies[i].Name} attacked {StoryTeller.instance.player.Name}, leaving him in {StoryTeller.instance.player.Name} health points.");
                }
            }

            if(!StoryTeller.instance.player.IsAlive())
            {
                win = false;
                Console.WriteLine($"{StoryTeller.instance.player.Name} loose the fight");
                return true;
            }

            return false;
        }

        public virtual void Reward()
        {
            int reward = 0;

            for(int i = 0;i < enemies.Length; i++)
            {
                reward += enemies[i].Loot;
                List<Item> enemyInventory = enemies[i].GetInventory();
                for(int j = 0; j < enemyInventory.Count; j++)
                {
                    StoryTeller.instance.player.ReceiveItem(enemyInventory[j], 1);
                }
            }

            StoryTeller.instance.player.GiveMoney(reward);
        }

        public override Chapter? GetNextChapter()
        {
            if (!win) return null; 

            return base.GetNextChapter();
        }
    }
}
