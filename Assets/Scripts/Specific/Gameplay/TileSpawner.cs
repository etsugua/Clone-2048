using UnityEngine;

namespace Specific.Gameplay
{
    public class TileSpawner : MonoBehaviour
    {
        public GameObject PiecePrefab; // Reference to the piece prefab
        public int BoardSize; // The size of the board

        void Start()
        {
            // Spawn the pieces at the start of the game
            for (int x = 0; x < BoardSize; x++)
            {
                for (int y = 0; y < BoardSize; y++)
                {
                    GameObject piece = Instantiate(PiecePrefab, new Vector2(x, y), Quaternion.identity);
                }
            }
        }

        void Update()
        {
            // Check if pieces have been moved and if so, spawn a new piece
        }
    }
}