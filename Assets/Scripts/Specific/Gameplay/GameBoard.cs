using System.Threading.Tasks;
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

        public async void PushTowardsDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    MovePiecesUp();
                    break;
                case Direction.Down:
                    MovePiecesDown();
                    break;
                case Direction.Left:
                    MovePiecesLeft();
                    break;
                case Direction.Right:
                    MovePiecesRight();
                    break;
            }

            await Task.Delay(1000);
        }

        private void MovePiecesUp()
        {
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = board.GetLength(1) - 1; y >= 0; y--)
                {
                    // if the tile is not empty
                    if (board[x, y].GetComponent<Tile>().Value != 0)
                    {
                        // loop through the tiles below it
                        for (int i = y - 1; i >= 0; i--)
                        {
                            // if the tile is empty, move the piece down
                            if (board[x, i].GetComponent<Tile>().Value == 0)
                            {
                                board[x, i].GetComponent<Tile>().Value = board[x, y].GetComponent<Tile>().Value;
                                board[x, y].GetComponent<Tile>().Value = 0;
                            }
                            // if the tile is not empty, check if the value is the same
                            else if (board[x, i].GetComponent<Tile>().Value == board[x, y].GetComponent<Tile>().Value)
                            {
                                // if the value is the same, merge the pieces
                                board[x, i].GetComponent<Tile>().Value *= 2;
                                board[x, y].GetComponent<Tile>().Value = 0;
                                break;
                            }
                            // if the tile is not empty and the value is not the same, stop moving the piece
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
        
        private void MovePiecesDown()
        {
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    // if the tile is not empty
                    if (board[x, y].GetComponent<Tile>().Value != 0)
                    {
                        // loop through the tiles above it
                        for (int i = y + 1; i < board.GetLength(1); i++)
                        {
                            // if the tile is empty, move the piece up
                            if (board[x, i].GetComponent<Tile>().Value == 0)
                            {
                                board[x, i].GetComponent<Tile>().Value = board[x, y].GetComponent<Tile>().Value;
                                board[x, y].GetComponent<Tile>().Value = 0;
                            }
                            // if the tile is not empty, check if the value is the same
                            else if (board[x, i].GetComponent<Tile>().Value == board[x, y].GetComponent<Tile>().Value)
                            {
                                // if the value is the same, merge the pieces
                                board[x, i].GetComponent<Tile>().Value *= 2;
                                board[x, y].GetComponent<Tile>().Value = 0;
                                break;
                            }
                            // if the tile is not empty and the value is not the same, stop moving the piece
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
        
        private void MovePiecesLeft()
        {
            // pieces should move to the left of the board, until hitting a piece or a wall
            // if the piece hits a piece with the same value, merge the pieces
            for (int x = 0; x < board.GetLength(0); x++)
            {
                // loop through the board from top to bottom
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    // if the tile is not empty
                    if (board[x, y].GetComponent<Tile>().Value != 0)
                    {
                        // loop through the tiles to the left of it
                        for (int i = x - 1; i >= 0; i--)
                        {
                            // if the tile is empty, move the piece left
                            if (board[i, y].GetComponent<Tile>().Value == 0)
                            {
                                board[i, y].GetComponent<Tile>().Value = board[x, y].GetComponent<Tile>().Value;
                                board[x, y].GetComponent<Tile>().Value = 0;
                            }
                            // if the tile is not empty, check if the value is the same
                            else if (board[i, y].GetComponent<Tile>().Value == board[x, y].GetComponent<Tile>().Value)
                            {
                                // if the value is the same, merge the pieces
                                board[i, y].GetComponent<Tile>().Value *= 2;
                                board[x, y].GetComponent<Tile>().Value = 0;
                                break;
                            }
                            // if the tile is not empty and the value is not the same, stop moving the piece
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
        
        private void MovePiecesRight()
        {
            // pieces move to the right of the board, until hitting a piece or a wall
            // if the piece hits a piece with the same value, merge the pieces
            
            for (int x = board.GetLength(0) - 1; x >= 0; x--)
            {
                // loop through the board from top to bottom
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    // if the tile is not empty
                    if (board[x, y].GetComponent<Tile>().Value != 0)
                    {
                        // loop through the tiles to the right of it
                        for (int i = x + 1; i < board.GetLength(0); i++)
                        {
                            // if the tile is empty, move the piece right
                            if (board[i, y].GetComponent<Tile>().Value == 0)
                            {
                                board[i, y].GetComponent<Tile>().Value = board[x, y].GetComponent<Tile>().Value;
                                board[x, y].GetComponent<Tile>().Value = 0;
                            }
                            // if the tile is not empty, check if the value is the same
                            else if (board[i, y].GetComponent<Tile>().Value == board[x, y].GetComponent<Tile>().Value)
                            {
                                // if the value is the same, merge the pieces
                                board[i, y].GetComponent<Tile>().Value *= 2;
                                board[x, y].GetComponent<Tile>().Value = 0;
                                break;
                            }
                            // if the tile is not empty and the value is not the same, stop moving the piece
                            else
                            {
                                break;
                            }
                        }
                    }
                }
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