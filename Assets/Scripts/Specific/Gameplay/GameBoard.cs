using UnityEngine;

namespace Specific.Gameplay
{
    public class GameBoard : MonoBehaviour {
        public Tile[,] board; // a 2D array of Tile objects

        // constructor
        public GameBoard(int size) {
            board = new Tile[size, size]; // create a 2D array of size x size
        }

        // method to generate a new game board
        public void GenerateBoard() {
            // loop through all tiles in the board array
            for (int x = 0; x < board.GetLength(0); x++) {
                for (int y = 0; y < board.GetLength(1); y++) {
                    // assign a new Tile object to the current tile
                    board[x, y] = new Tile(0, new Vector2(x, y));
                }
            }
        }

        // method to move a tile
        public void MoveTile(Tile tile, Vector2 direction) {
            // get the position of the tile
            Vector2 position = tile.Position;

            // calculate the new position of the tile
            Vector2 newPosition = position + direction;
            // move the tile to the new position
            board[(int)position.x, (int)position.y] = null;
            board[(int)newPosition.x, (int)newPosition.y] = tile;
            tile.Position = newPosition;
        }
    }
}