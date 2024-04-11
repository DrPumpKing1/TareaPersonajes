using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareaSemana3.Character_System;

namespace TareaSemana3
{
    internal class Controller
    {
        const int MAX_SKILL_POINTS = 100;


        public Player SetPlayer(Weapon weapon, Armor armor)
        {
            Console.WriteLine("Welcome...");

            string name = "A";
            name = Console.ReadLine();

            int skillPoints = MAX_SKILL_POINTS;
            int health, strength, dexterity;

            Console.WriteLine($"You've to comeback to Termidor but first, please allocate your skill points. You've {MAX_SKILL_POINTS} ready to be used");

            bool canContinue = false;

            do
            {
                Console.WriteLine("How many health points?");

                int.TryParse(Console.ReadLine(), out health);

                canContinue = health < skillPoints && health > 0;

                if (!canContinue) Console.WriteLine("Please allocate a valid quantity");

            } while (!canContinue);

            skillPoints -= health;

            do
            {
                Console.WriteLine("How many strength points?");

                int.TryParse(Console.ReadLine(), out strength);

                canContinue = strength < skillPoints && strength > 0;

                if (!canContinue) Console.WriteLine($"Please allocate a valid quantity. You only have {skillPoints} points left");

            } while (!canContinue);

            skillPoints -= strength;

            do
            {
                Console.WriteLine("How many dexterity points?");

                int.TryParse(Console.ReadLine(), out dexterity);

                canContinue = dexterity <= skillPoints && strength > 0;

                if (!canContinue) Console.WriteLine($"Please allocate a valid quantity. You only have {skillPoints} points left");

            } while (!canContinue);

            skillPoints -= dexterity;


            if (skillPoints > 0)
            {
                Console.WriteLine($"You've {skillPoints} skill points more. Do you want to allocate it (Yes/No)");

                do
                {
                    string answer = Console.ReadLine();

                    if (answer == null)
                    {
                        canContinue = false;
                        continue;
                    }

                    answer = answer.Trim().ToLower();

                    if (answer == "yes" || answer == "y")
                    {
                        Console.WriteLine("Do you want to allocate it in:");
                        Console.WriteLine("1. Health");
                        Console.WriteLine("2. Strength");
                        Console.WriteLine("3. Dexterity");
                        Console.WriteLine("Type the number of your choice");

                        canContinue = false;

                        do
                        {
                            string choice = Console.ReadLine();

                            if (choice == null)
                            {
                                canContinue = false;
                                continue;
                            }

                            choice = choice.Trim().ToLower();

                            if (choice == "1")
                            {
                                health += skillPoints;
                                canContinue = true;

                                Console.WriteLine($"Your new health points are {health}");
                            }
                            else if (choice == "2")
                            {
                                strength += skillPoints;
                                canContinue = true;

                                Console.WriteLine($"Your new strength points are {strength}");
                            }
                            else if (choice == "3")
                            {
                                dexterity += skillPoints;
                                canContinue = true;

                                Console.WriteLine($"Your new dexterity points are {dexterity}");
                            }
                            else
                            {
                                canContinue = false;
                                Console.WriteLine("That's not a valid attribute");
                            }
                        } while (!canContinue);

                        canContinue = true;
                    }
                    else if (answer == "no" || answer == "n")
                    {
                        Console.WriteLine("So it be!");

                        canContinue = true;
                    }
                    else
                    {
                        Console.WriteLine("Answer correctly! Termidor guardian...");
                        canContinue = false;
                    }
                } while (!canContinue);
            }

            return new Player(strength, dexterity, name, health, armor, weapon, new List<Item>());
        }
    }
}
