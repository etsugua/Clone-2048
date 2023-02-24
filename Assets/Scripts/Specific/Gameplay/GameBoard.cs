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
                    var tileObject = Instantiate(tilePrefab, new Vector2(startX + (increment * x), startY - (increment * y)),
                        Quaternion.identity);
                    var tileScript = tileObject.GetComponent<Tile>();
                    tileScript.Value = 0;
                    board[x, y] = tileObject;
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
                    SwipeUp();
                    break;
                case Direction.Down:
                    SwipeDown();
                    break;
                case Direction.Left:
                    SwipeLeft();
                    break;
                case Direction.Right:
                    SwipeRight();
                    break;
            }

            ResetWasMerged();
            await Task.Delay(1000);
        }
        
        private Tile GetTile(int x, int y)
        {
            return board[x, y].GetComponent<Tile>();
        }

        private void SwipeUp()
        {
            for (var x = 0; x < board.GetLength(0); x++)
            {
                for (var y = 0; y < board.GetLength(1) - 1; y++)
                {
                    Tile currentTile = GetTile(x, y);

                    for (var y2 = y + 1; y2 < board.GetLength(1); y2++)
                    {
                        var checkTile = GetTile(x, y2);
                        
                        if (checkTile.IsEmpty)
                        {
                            continue;
                        }
                        
                        if (currentTile.IsEmpty) 
                        {
                            currentTile.Value = checkTile.Value;
                            checkTile.Value = 0;
                            y--; // check the same tile again
                        }
                        else if (currentTile.Value == checkTile.Value && !currentTile.WasMerged)
                        {
                            currentTile.Value *= 2;
                            currentTile.WasMerged = true;
                            checkTile.Value = 0;
                        }

                        break;
                    }
                }
            }
        }

        private void SwipeDown()
        {
            for (var x = 0; x < board.GetLength(0); x++)
            {
                for (var y = board.GetLength(1) - 1; y > 0; y--)
                {
                    Tile currentTile = GetTile(x, y);

                    for (var y2 = y - 1; y2 >= 0; y2--)
                    {
                        var checkTile = GetTile(x, y2);
                        
                        if (checkTile.IsEmpty)
                        {
                            continue;
                        }
                        
                        if (currentTile.IsEmpty) 
                        {
                            currentTile.Value = checkTile.Value;
                            checkTile.Value = 0;
                            y++; // check the same tile again
                        }
                        else if (currentTile.Value == checkTile.Value && !currentTile.WasMerged)
                        {
                            currentTile.Value *= 2;
                            currentTile.WasMerged = true;
                            checkTile.Value = 0;
                        }

                        break;
                    }
                }
            }
        }
        
        private void SwipeLeft()
        {
            for (var y = 0; y < board.GetLength(1); y++)
            {
                for (var x = 0; x < board.GetLength(0) - 1; x++)
                {
                    Tile currentTile = GetTile(x, y);

                    for (var x2 = x + 1; x2 < board.GetLength(0); x2++)
                    {
                        var checkTile = GetTile(x2, y);
                        
                        if (checkTile.IsEmpty)
                        {
                            continue;
                        }
                        
                        if (currentTile.IsEmpty) 
                        {
                            currentTile.Value = checkTile.Value;
                            checkTile.Value = 0;
                            x--; // check the same tile again
                        }
                        else if (currentTile.Value == checkTile.Value && !currentTile.WasMerged)
                        {
                            currentTile.Value *= 2;
                            currentTile.WasMerged = true;
                            checkTile.Value = 0;
                        }

                        break;// this would mean we found a different tile, so we can stop checking
                    }
                }
            }
        }
        
        private void SwipeRight()
        {
            for (var y = 0; y < board.GetLength(1); y++)
            {
                for (var x = board.GetLength(0) - 1; x >= 1; x--)
                {
                    Tile currentTile = GetTile(x, y);

                    for (var x2 = x - 1; x2 >= 0; x2--)
                    {
                        var checkTile = GetTile(x2, y);
                        
                        if (checkTile.IsEmpty)
                        {
                            continue;
                        }
                        
                        if (currentTile.IsEmpty) 
                        {
                            currentTile.Value = checkTile.Value;
                            checkTile.Value = 0;
                            x++; // check the same tile again
                        }
                        else if (currentTile.Value == checkTile.Value && !currentTile.WasMerged)
                        {
                            currentTile.Value *= 2;
                            currentTile.WasMerged = true;
                            checkTile.Value = 0;
                        }

                        break;// this would mean we found a different tile, so we can stop checking
                    }
                }
            }
        }
        
        private void ResetWasMerged()
        {
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    board[x, y].GetComponent<Tile>().WasMerged = false;
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
                Debug.LogWarning("GAME OVER! No empty tiles left!");
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