using System.Collections.Generic;
using System.Text;
using System;

using Woc_consts;

namespace Assignment1
{
    class Player:IComparable
    {
        ///constructors
        public Player()
        {
            /**************************************************
             * Default constructor. 
             * Sets all private attributes to 0, "", or null.
             *************************************************/

            id = 0;
            name = "";
            race = null;
            level = 0;
            exp = 0;
            guildID = null;
            gear = null;
            inventory = null;
        }

        public Player(uint ID = 0, string Name = "", Race? Race = null, uint Level = 0, uint Exp = 0,
            uint? GuildID = null, uint[] Gear = null, uint[] Inventory = null)
        {
            /*******************************************************************
             * Alternate constructor.
             * Allows caller to define class attributes when class is created.
             * All undefined attributes are set to 0, "", or null.
             *****************************************************************/


            id = ID;
            name = Name;
            race = this.Race;
            level = Level;
            exp = Exp;
            guildID = GuildID;
            gear = new List<uint>(Gear);
            inventory = new List<uint>(Inventory);
        }

        ///prvate attributes
        private readonly uint id;
        private readonly string name;
        private readonly Race? race;
        private uint level;
        private uint exp;
        private uint? guildID;
        private List<uint>? gear;
        private List<uint>? inventory;

        ///public attributes
        public uint ID
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
        }

        public Race? Race
        {
            get { return race; }
        }

        public uint Level
        {
            get { return level; }
            set
            {
                //set level as requested so long as number does not exceed MAX_LEVEL
                if (value <= Constants.MAX_LEVEL)
                {
                    level = value;
                }
                else
                {
                    Console.WriteLine("ERROR: Level value " + value + " is out of range (max " + Constants.MAX_LEVEL + ").\n" +
                        "Level not changed.");
                }
            }
        }

        public uint Exp
        {
            get { return exp; }
            set { Add_Exp(value); }
        }

        public uint? GuildID
        {
            get { return guildID; }
            set { guildID = value; }
        }

        public uint this[int index]
        {
            get {
                return gear[index]; }
            set
            {
                if (gear == null) gear = new List<uint>();
                //before moving value to index, extend list length if needed
                while (gear.Count < (index + 1)) gear.Add(0);

                gear[index] = value;
            }
        }

        ///functions/interfaces

        private void Add_Exp(uint expAmt)
        {

        }

        public int CompareTo(object obj)
        {
            return name.CompareTo(obj);
        }
    }
}
