using System;
using System.IO;
using System.Collections.Generic;

namespace Assignment1

{
	public class GameFile
	{
		//public variables
		Dictionary<uint, Item> items = new Dictionary<uint, Item>();
		Dictionary<uint, string> guilds = new Dictionary<uint, string>();
		Dictionary<uint, Player> characters = new Dictionary<uint, Player>();
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
				using (StreamReader inGuild = new StreamReader("./bin/init/guilds.txt"))
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
						guilds.Add(id, name);
                    }

				}
				//loading in the items into our Dictionary for use
				using (StreamReader inItems = new StreamReader("./bin/init/equipment.txt"))
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
						type = Int32.Parse(subs[1]);
						ilvl = UInt32.Parse(subs[2]);
						primary = UInt32.Parse(subs[3]);
						stamina = UInt32.Parse(subs[4]);
						requirement = UInt32.Parse(subs[5]);
						flavor = subs[6];
						items.Add(id, new Item(id, name, type, ilvl, primary, stamina, requirement, flavor));
					}
				}
				//importing Players now
				using (StreamReader inCharacter = new StreamReader("./bin/init/Characters.txt"))
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
						characters.Add(id, new Player(id, name, race, level, exp, guildID, inventory));
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("A file could not be read");
				Console.WriteLine(e.Message);
			}

		}
	}
}