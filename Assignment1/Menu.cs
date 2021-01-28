﻿using System;
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
				user = user.ToLower(); // lowercase the string for input handling
				if(user.Equals("t")) // hidden option for comparison testing
                {

                }
				else if(user.Equals("q") || user.Equals("quit") || user.Equals("10"))
                {
					break;
                }
                else 
				{
					int choice;
					try
					{
						choice = Int32.Parse(user);
						switch(choice)
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

								break;
							case 5:

								break;
							case 6:

								break;
							case 7:

								break;
							case 8:

								break;
							case 9:

								break;
							default:
								Console.WriteLine("Input was out of bounds, please select a valid input.");
								break;
                        }

					}
					catch (FormatException e)
					{
						Console.WriteLine("Invalid input, input must only be a number.");
					}

				}
			}
			Console.WriteLine("Goodbye!");
		}

	}
}