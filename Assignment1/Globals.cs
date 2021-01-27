using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    static class Globals
    {
        //global variables are stored here
        public static Dictionary<uint, Item> items = new Dictionary<uint, Item>();
        public static Dictionary<uint, string> guilds = new Dictionary<uint, string>();
        public static Dictionary<uint, Player> characters = new Dictionary<uint, Player>();
    }
}
