using System;
using Woc_item;
using System.IO;
using System.Collections.Generic;

namespace GameFile
{
	public class GameFile
	{

		Dictionary<uint, Item> items = new Dictionary<uint, Item>();
		Dictionary<uint, string> guilds = new Dictionary<uint, string>();
		Dictionary<uint, Character> characters = new Dictionary<uint, Character>();
		public GameFile()
		{
			LoadIn();

		}


		private void LoadIn()
		{
			try
			{
				using (StreamReader inGuild = new StreamReader("./bin/init/guilds.txt"))
                {
                    string line;
					uint id;
					string name;
					while ((line = inGuild.ReadLine()) != null)
                    {
                        string[] subs = line.Split('\t');
						id = UInt32.Parse(subs[0]);
						name = subs[1];
						guilds.Add(id, name);
                    }

				}
				//we load in the items from our item list and place them into our array list for access
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
				using (StreamReader inCharacter = new StreamReader("./bin/init/Characters.txt"))
				{
					string line;
					uint id;
					string name;
					int race;
					uint level;
					uint exp;
					uint? guildID;


					while ((line = inCharacter.ReadLine()) != null)
					{
						string[] subs = line.Split('\t');
						id = UInt32.Parse(subs[0]);
						name = subs[1];
						race = Int32.Parse(subs[2]);
						level = UInt32.Parse(subs[3]);
						exp = UInt32.Parse(subs[4]);
						guildID = UInt32.Parse(subs[5]);


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