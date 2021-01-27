using System;
namespace Assignment1
{
	public class menu
	{
		static void main(string[] args)
		{

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
				if (Choice(user) == 10)
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
			catch (FormatException e)
			{
				Console.WriteLine("Invalid input, input must only be a number.");
				return -1;
			}
			if (userChoice == 10) return userChoice; // quit option
			return 0;
		}

	}
}