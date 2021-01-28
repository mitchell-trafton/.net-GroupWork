using System;
using System.IO;
using System.Collections.Generic;

namespace Assignment1

{
	public class GameFile
	{
		//constructor
		public GameFile()
		{
			LoadIn();

		}

		/***************************************************************
		 * LoadIn()
		 * purpose: initialize our dictionaries by reading the files in 
		 * bin/init, for the player and item classes, as well as our guilds
		 * 
		 ***************************************************************/
		private void LoadIn()
		{
			try
			{
				//loading in the guilds into our Dictionary for use
				using (StreamReader inGuild = new StreamReader("bin/init/guilds.txt"))
				{
					string line;
					uint id;
					string name;
					//we go line by line and begin creating our guilds from the file
					while ((line = inGuild.ReadLine()) != null)
					{
						string[] subs = line.Split('\t');
						id = UInt32.Parse(subs[0]);
						name = subs[1];
						Globals.guilds.Add(id, name);
					}

				}
			}
			catch (Exception e)
			{
				Console.WriteLine("guilds.txt could not be read");
				Console.WriteLine(e.Message);
			}

			try
			{
				//loading in the items into our Dictionary for use
				using (StreamReader inItems = new StreamReader("bin/init/equipment.txt"))
				{
					string line;
					uint id;
					string name;
					int type;
					uint ilvl;
					uint primary;
					uint stamina;
					uint requirement;
					string flavor;
					//this goes line by line to split up the variables so we can assign them properly within our items objects
					while ((line = inItems.ReadLine()) != null)
					{
						string[] subs = line.Split('\t');
						id = UInt32.Parse(subs[0]);
						name = subs[1];
						type = Int32.Parse(subs[2]);
						ilvl = UInt32.Parse(subs[3]);
						primary = UInt32.Parse(subs[4]);
						stamina = UInt32.Parse(subs[5]);
						requirement = UInt32.Parse(subs[6]);
						flavor = subs[7];
						Globals.items.Add(id, new Item(id, name, type, ilvl, primary, stamina, requirement, flavor));
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("equipment.txt could not be read");
				Console.WriteLine(e.Message);
			}
			try
			{ 
				//importing Players now
				using (StreamReader inCharacter = new StreamReader("bin/init/players.txt"))
				{
					string line;
					uint id;
					string name;
					int race;
					uint level;
					uint exp;
					uint? guildID;
					uint[] inventory;

					while ((line = inCharacter.ReadLine()) != null)
					{
						string[] subs = line.Split('\t');
						id = UInt32.Parse(subs[0]);
						name = subs[1];
						race = Int32.Parse(subs[2]);
						level = UInt32.Parse(subs[3]);
						exp = UInt32.Parse(subs[4]);
						guildID = UInt32.Parse(subs[5]);
						inventory = new uint[subs.Length - 6];
						for(int i = 6; i<subs.Length; i++)//the rest of the file is inventory, this will record the IDs of player inventory and store them
                        {
							inventory[i - 6] = UInt32.Parse(subs[i]);
                        }
						Globals.characters.Add(id, new Player(id, name, (Race?)race, level, exp, guildID, inventory));
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Characters.txt could not be read");
				Console.WriteLine(e.Message);
			}

		}
		/*****************************************************************
		 * void PrintItems()
		 * this will loop through the items dictionary and print out each
		 * entry using the ToString overwrite we did within that file
		 ****************************************************************/
		public void PrintItems()
        {
			foreach(KeyValuePair<uint, Item> item in Globals.items)
            {
				Console.WriteLine(item.ToString());
            }
			Console.WriteLine("End of items");
        }
		/****************************************************************
		* void PrintGuild() 
		* This will loop through each guild entry and print out the string
		* holding the guild name.
		*****************************************************************/
		public void PrintGuild()
        {
			foreach(KeyValuePair<uint, string> guild in Globals.guilds)
            {
				Console.WriteLine(guild.Value);
            }
			Console.WriteLine("End of Guilds");
        }
		/****************************************************************
		 * Void PrintPlayer()
		 * this will loop through each player entry in the dictionary
		 * using the ToString override within that class.
		 ****************************************************************/
		public void PrintPlayer()
        {
			foreach(KeyValuePair<uint, Player> character in Globals.characters)
            {
				Console.WriteLine(character.ToString());
            }
			Console.WriteLine("End of players");

        }
	}
}