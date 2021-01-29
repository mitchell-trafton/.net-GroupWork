using System;
namespace Assignment1
{
	public class Menu
	{
		static void Main(string[] args)
		{
			/*****************************************
			 * Main function for program.
			 * 
			 * Acts as menu loop.
			 *****************************************/

			Console.WriteLine("Welcome to the World of ConflictCraft: Testing Enviornment!");
			GameFile game = new GameFile();
			while (true)
			{
				Console.WriteLine("\n \n Please select an option from the list below:");
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
				user = user.ToLower(); // lowercase the string for input handling
				if (user.Equals("t")) // hidden option for comparison testing
				{
					game.Sorting();
				}
				else if (user.Equals("q") || user.Equals("quit") || user.Equals("10"))
				{
					break;
				}
				else
				{
					int choice;
					try
					{
						choice = Int32.Parse(user);
						int pid = -1;//player id
						int iid = -1;//item/gear id
						int gid = -1;// guild id
						switch (choice)
						{
							case 1:
								game.PrintPlayer();
								break;
							case 2:
								game.PrintGuild();
								break;
							case 3:
								game.PrintItems();
								break;
							case 4:
								pid = game.SelectPlayer();
								if (pid > -1) Globals.characters[(uint)pid].PrintGearList();
								break;
							case 5:
								pid = game.SelectPlayer();
								if (pid > -1) game.LeaveGuild((uint)pid); // if we don't have an error, leave guild, otherwise return to menu
								break;
							case 6:
								pid = game.SelectPlayer();
								gid = game.SelectGuild();
								if (gid > -1 && pid > -1) game.JoinGuild((uint)pid, (uint)gid); // if both identifiers are valid, send them to JoinGuild
								break;
							case 7:
								pid = game.SelectPlayer();
								iid = game.SelectGear();
								if (iid > -1 && pid > -1) Globals.characters[(uint)pid].EquipGear((uint)iid);
								break;
							case 8:
								pid = game.SelectPlayer();
								if (pid > -1)
								{
									Globals.characters[(uint)pid].PrintGearList();
									Console.WriteLine("Please select the slot you would like to unequipt:");
									user = Console.ReadLine();
									iid = Int32.Parse(user);
									if (iid > -1 || iid < Constants.GEAR_SLOTS) Globals.characters[(uint)pid].UnequipGear(iid);
									else Console.WriteLine("Invalid choice, returning to menu");
								}
								break;
							case 9:
								pid = game.SelectPlayer();
								if (pid > -1) game.AddExp((uint)pid);
								break;
							default:
								Console.WriteLine("Input was out of bounds, please select a valid input.");
								break;
						}

					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
						Console.WriteLine("Invalid input, input must only be a number.");
					}

				}
			}
			Console.WriteLine("Goodbye!");
		}

	}
}