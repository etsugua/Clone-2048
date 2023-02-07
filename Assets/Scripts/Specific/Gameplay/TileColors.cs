using UnityEngine;

namespace Specific.Gameplay
{
    public class TileColors
    {
        private static Color Empty = new Color(0.3f,0.3f,0.3f, 1f);
        private static Color Tile_2 = new Color(1f,1f,0.3f, 1f);
        private static Color Tile_4 = new Color(1f,1f,0.7f, 1f);
        private static Color Tile_8 = new Color(1f,0.7f,0.5f, 1f);
        private static Color Tile_16 = new Color(1f,0.7f,0.7f, 1f);
        private static Color Tile_32 = new Color(1f,0.5f,0.5f, 1f);
        private static Color Tile_64 = new Color(1f,0.5f,0.7f, 1f);
        private static Color Tile_128 = new Color(1f,0.5f,1f, 1f);
        private static Color Tile_256 = new Color(0.7f,0.5f,1f, 1f);
        private static Color Tile_512 = new Color(0.5f,0.7f,1f, 1f);
        private static Color Tile_1024 = new Color(0.5f,1f,1f, 1f);
        private static Color Tile_2048 = new Color(0.5f,1f,0.5f, 1f);
        private static Color Unknown = new Color(0f,0f,0f, 1f);
        
        // color map, with a int for a key and a color for a value
        public static Color GetColor(int number)
        {
            switch (number)
            {
                case 0:
                    return Empty;
                case 2:
                    return Tile_2;
                case 4:
                    return Tile_4;
                case 8:
                    return Tile_8;
                case 16:
                    return Tile_16;
                case 32:
                    return Tile_32;
                case 64:
                    return Tile_64;
                case 128:
                    return Tile_128;
                case 256:
                    return Tile_256;
                case 512:
                    return Tile_512;
                case 1024:
                    return Tile_1024;
                case 2048:
                    return Tile_2048;
                default:
                    return Unknown;
            }
        }
    }
}