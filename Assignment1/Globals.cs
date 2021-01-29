using System;
using System.Collections.Generic;
using System.Text;
/************************************************************
 * Assignment 1
 * Programmers: Robert Tyler Trotter z1802019
 *              Mitchell Trafton     z1831076
 ***********************************************************/

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
