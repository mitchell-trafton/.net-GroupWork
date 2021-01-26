using System;
using Woc_consts;
namespace Woc_item
{
    class Item : IComparable
    {
        //constants
        private readonly static uint MAX_ILVL = 360;
        private readonly static uint MAX_PRIMARY = 200;
        private readonly static uint MAX_LEVEL = 60;
        private readonly static uint GEAR_SLOTS = 14;
        private readonly static uint MAX_INVENTORY_SIZE = 20;
        // variables
        public readonly int id; //identifer for the item 
        public string name; // item name
        public itemType type; //where the item can be placed
        public uint ilvl;//
        public uint primary;
        public uint stamina;
        public uint requirement;
        public string flavor; // flavor text
        public Item()
        {
            id = 0;
            name = "N/A";
            type = itemType.None;
            ilvl = 0;
            primary = 0;
            stamina = 0;
            requirement = 0;
            flavor = "N/A";
        }
        public Item(int tid, string tname, itemType ttype, uint tlvl, uint tprimary, uint tstamina, uint trequirement, string tflavor)
        {
            id = tid;
            name = tname;
            type = ttype;
            ilvl = tlvl;
            primary = tprimary;
            stamina = tstamina;
            requirement = trequirement;
            flavor = tflavor;
        }
        /***************************************************
        * IComparable interface, compareTo
        * input: Item object
        * output: An int value representing the order of the 
        * items sorting by their string name variable
        ****************************************************/
        int IComparable.CompareTo(object obj)
        {
            Item other = (Item)obj;

            return String.Compare(name, other.name);
        }
        /***************************************************
         * override ToString 
         * Prints out the item type, name, level requirement
         * and the flavor text on a second line.
         * 
         **************************************************/
        public override string ToString()
        {
            return "(" + type + ") " + name + "|" + ilvl + "|" + "\n" +"   " + flavor;
        }

    }
}
