using System.Text.RegularExpressions;
using TareaSemana3;
using TareaSemana3.Adventure_System;
using TareaSemana3.Character_System;
using TareaSemana3.Item_System;

Controller controller = new Controller();

Chestplate KnightChestplate = new Chestplate("Knight's Chestplate", 1, .05f);
Sword KnightSword = new Sword("Knight's Sword", 5, .2f, .1f);

Character Breeze = new Character("Breeze", 1);

Player player = controller.SetPlayer(KnightSword, KnightChestplate);

// STORY WRITTEN FROM END TO FINISH
string death_text = "Every adventure has to end... Somehow unlucky.";
Chapter deathChapter = new Chapter(new string[] { death_text }, null);

Enemy banditOliver = new Enemy(10, 3, "Oliver", 15, 20, null, null, new List<Item>());
Enemy banditJames = new Enemy(15, 0, "James", 10, 15, null, null, new List<Item>());

string engage_bandits_text = $"{player.Name} engages fight with the bandits";
Fight engage_bandits = new Fight(new Enemy[] { banditOliver, banditJames }, new string[] { engage_bandits_text }, null);

string fight_bandits_text = "Fight those criminals";
Option fight_bandits = new Option(new string[] {fight_bandits_text}, engage_bandits);
string ignore_mother_text = "Ignore them, he've to reach the palace before the enemy";
Option ignore_mother = new Option(new string[] {ignore_mother_text}, null);

string enter_city_text = $"{player.Name} enter through the city's big gate sign of victory now crumbling into ashes.";
string mother_and_child = $"{player.Name} sees a mother and her child being harrased by bandits. What will he do?";
Selection save_people = new Selection(new string[] { enter_city_text, mother_and_child }, new Option[] {fight_bandits, ignore_mother});

string save_breeze_text = $"The war's hero lift the projectile and heals his old buddy. He leave Breeze resting aside from the road while venturing into the fire.";
Chapter save_breeze = new Chapter(new string[] { save_breeze_text }, save_people);

string option_abandon_breeze = "Abandon Breeze, knight have something worse to worry now";
OptionKiller abandon_breeze = new OptionKiller(new string[] { option_abandon_breeze}, save_people, Breeze);
string option_lift_rock = "Lift heavy catapult's projectile";
OptionStatDamaging lift_rock = new OptionStatDamaging(new string[] { option_lift_rock }, save_breeze, OptionStat.RequirementType.strength, 15, 10);

string help_breeze_text = $"Below the rock lays the knight whole life partner Breeze near death. What will he do?";
Selection help_breeze = new Selection(new string[] { help_breeze_text }, new Option[2] {abandon_breeze, lift_rock});

string as_you_approach = $"As {player.Name} approach the city the disaster seems worse. Houses set on fire, masses of innocent people running in terror, monsters and bandits fighting the knights of Termidor.";
string breeze_trips = "Breeze trips trying to dodge a catapult attack that came from afar";
string breeze_crushed = $"{player.Name}'s horse Breeze was crushed by the catapult's rock.";
Chapter rushing = new Chapter(new string[] { as_you_approach, breeze_trips, breeze_crushed }, help_breeze);

string first_chapter_text = $"(On the way to Termidor) The old knight rush to the city on fire as he sees a tall column of black smoke over the kingdom's capital. {player.Name}: 'Hurry up Breeze!'";
string examinate = $"{player.Name} examinate himself quickly as he rushes to the fire.";
string armor_and_weapon = $"{player.Name} is holding the {KnightSword.name} and is protected by the {KnightChestplate.name}";
Chapter start_chapter = new Chapter(new string[] { first_chapter_text, examinate, armor_and_weapon}, rushing);

//STORY END

StoryTeller story = new StoryTeller(start_chapter, player, deathChapter);
story.WriteStory();
