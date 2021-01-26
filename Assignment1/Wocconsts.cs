using System;
namespace Woc_consts 
{
    public enum itemType
    {
    Helmet, Neck, Shoulders, Back, Chest, Wrist,
    Gloves, Belt, Pants, Boots, Ring, Trinket, None
    };
    public enum Race { Orc, Troll, Tauren, Forsaken};

    static class Constants
    {
        public static uint MAX_ILVL = 360;
        public static uint MAX_PRIMARY = 200;
        public static uint MAX_STAMINA = 275;
        public static uint MAX_LEVEL = 60;
        public static uint GEAR_SLOTS = 14;
        public static uint MAX_INVENTORY_SIZE = 20;
    }
}
