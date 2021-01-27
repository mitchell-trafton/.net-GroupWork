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
            gear = Gear;
            if (Inventory != null) inventory = new List<uint>(Inventory);
            else inventory = null;
        }

        ///prvate attributes
        private readonly uint id;
        private readonly string name;
        private readonly Race? race;
        private uint level;
        private uint exp;
        private uint? guildID;
        private uint[] gear = new uint[Constants.GEAR_SLOTS];
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
            set
            {
                //whenever Exp is set equal to a value, that value is added to exp
                exp += value;

                LevelUp();//call LevelUp() function to increase the current level if appropriate
            }
        }

        public uint? GuildID
        {
            get { return guildID; }
            set { guildID = value; }
        }

        public uint this[int index]
        {
            get { return gear[index]; }
            set { gear[index] = value; }
        }

        ///functions/interfaces

        private void LevelUp()
        {
            /***********************************************************************
             * Levels up the player if there is sufficient exp.
             * 
             * If there is enough exp to level up (>= current level * 1000), 
             * subtract that amount from current exp, increase current level, 
             * and call function again to see if further leveling up should occur.
             **********************************************************************/
            if (exp >= (level * 1000))
            {
                exp -= level * 1000;
                level++;
                LevelUp();
            }
        }

        public int CompareTo(object obj)
        {
            /****************************************
             * CompareTo function for IComparable interface. 
             * 
             * Compares this Player object to another using
             * the 'name' attribute.
             ****************************************/

            if (obj == null || name == null) throw new ArgumentNullException();

            Player Obj = obj as Player;

            if (Obj.Name == null) throw new ArgumentNullException();
            else return name.CompareTo(Obj.Name);
        }

        public void EquipGear(uint newGearID)
        {

        }
    }
}
