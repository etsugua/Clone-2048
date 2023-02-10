using UnityEngine;

namespace Specific.Gameplay
{
    public class GameBoard : MonoBehaviour
    {
        public GameObject tilePrefab; // the prefab of the tile
        public GameObject[,] board; // a 2D array of Tile objects

        public void ResetBoard(int size)
        {
            // create a new Tile array of size x size with Tile objects with the Value 0
            board = new GameObject[size, size];

            // loop through the array and set the Value of each Tile to 0
            var startX = -3.75f;
            var startY = 1.75f;
            var increment = 2.5f;
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    var tile = Instantiate(tilePrefab, new Vector2(startX + (increment * x), startY - (increment * y)),
                        Quaternion.identity);
                    tile.GetComponent<Tile>().Value = 0;
                    board[x, y] = tile;
                }
            }

            GenerateNewTile();
            GenerateNewTile();
        }

        public void PushTowardsDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    // TODO
                    break;
                case Direction.Down:
                    // TODO
                    break;
                case Direction.Left:
                    // TODO
                    break;
                case Direction.Right:
                    // TODO
                    break;
            }
        }

        public bool GenerateNewTile()
        {
            var emptyTile = FindEmptyTile();
            if (emptyTile)
            {
                // random set the value of the tile to 2 or 4
                emptyTile.GetComponent<Tile>().Value = Random.Range(0, 2) == 0 ? 2 : 4;
                return true;
            }
            else
            {
                Debug.LogError("GAME OVER! No empty tiles left!");
                return false;
            }
        }
        
        private GameObject FindEmptyTile()
        {
            var emptyTiles = new GameObject[board.Length];
            var emptyTileCount = 0;
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    if (board[x, y].GetComponent<Tile>().Value == 0)
                    {
                        emptyTiles[emptyTileCount] = board[x, y];
                        emptyTileCount++;
                    }
                }
            }

            if (emptyTileCount == 0)
            {
                return null;
            }

            var randomIndex = Random.Range(0, emptyTileCount);
            return emptyTiles[randomIndex];
        }
    }
}