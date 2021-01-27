using System;
using System.IO;
using System.Collections;
using Woc_item;
public class menu
{
	static void main(string[] args)
	{
        ArrayList items = new ArrayList();
        ArrayList guilds = new ArrayList();
		ArrayList characters = new ArrayList();
		Console.WriteLine("Welcome to the World of ConflictCraft: Testing Enviornment!");
		menu.LoadIn(items, guilds, characters);
		while (true)
        {
			Console.WriteLine("Please select an option from the list below:");
			Console.WriteLine("1.) Print All Players");
			Console.WriteLine("2.) Print All Guilds");
			Console.WriteLine("3.) Print All Gear");
			Console.WriteLine("4.) Print Gear List for Player");
			Console.WriteLine("5.) Leave Guild");
			Console.WriteLine("6.) Join Guild");
			Console.WriteLine("7.) Equip Gear");
			Console.WriteLine("8.) Unequip Gear");
			Console.WriteLine("9.) Award Experience");
			Console.WriteLine("10.) Quit");
			string user = Console.ReadLine();
			if(Choice(user) == 10)
            {
				break;
            }
		}
		Console.WriteLine("Goodbye!");
	}
	int Choice(string input)
    {
		int userChoice = -1;
		//trycatch for making sure the input is clean
        try
        {
			 userChoice = Int32.Parse(input);
        }
		catch(FormatException e)
        {
            Console.WriteLine("Invalid input, input must only be a number.");
			return -1;
        }
        if (userChoice == 10) return userChoice; // quit option
		return 0;
    }
	void LoadIn(ArrayList items, ArrayList guilds, ArrayList characters)
    {
        try
        {
			StreamReader inGuild = new StreamReader("./bin/init/guilds.txt");
			//we load in the items from our item list and place them into our array list for access
			using (StreamReader inItems = new StreamReader("./bin/init/equipment.txt"))
			{
                string line;
				int id;
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
					id = Int32.Parse(subs[0]);
					name = subs[1];
					type = Int32.Parse(subs[1]);
					ilvl = UInt32.Parse(subs[2]);
					primary = UInt32.Parse(subs[3]);
					stamina = UInt32.Parse(subs[4]);
					requirement = UInt32.Parse(subs[5]);
					flavor = subs[6];
					items.Add(new Item(id, name, type, ilvl, primary, stamina, requirement, flavor));
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
