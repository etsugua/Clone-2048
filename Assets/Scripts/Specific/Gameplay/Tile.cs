using UnityEngine;

namespace Specific.Gameplay
{
    public class Tile {
        public int Number; // the number on the tile
        public Vector2 Position; // the position of the tile on the game board

        // constructor
        public Tile(int number, Vector2 position) {
            Number = number;
            Position = position;
        }
    }
}