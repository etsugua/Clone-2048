using UnityEngine;

namespace Specific.Gameplay
{
    public class GameManager : MonoBehaviour {
        // variables
        private GameBoard board;
        private PiecePrefab[] pieces; // array of PiecePrefab objects

        // constructor
        public GameManager(GameBoard board, PiecePrefab[] pieces) {
            this.board = board;
            this.pieces = pieces;
        }

        // method to start the game
        public void StartGame() {
            board.GenerateBoard(); // generate the game board
            PlacePieces(); // place the pieces on the game board
        }

        // method to restart the game
        public void RestartGame() {
            board.GenerateBoard(); // generate the game board
            PlacePieces(); // place the pieces on the game board
        }

        // method to place the pieces on the game board
        private void PlacePieces() {
            // loop through all pieces
            for (int i = 0; i < pieces.Length; i++) {
                // get a random position on the game board
                Vector2 position = GetRandomPosition();

                // create the piece on the game board
                pieces[i].CreatePrefab(board, position);
            }
        }

        // method to get a random position on the game board
        private Vector2 GetRandomPosition() {
            // generate a random x and y position
            int x = Random.Range(0, board.board.GetLength(0));
            int y = Random.Range(0, board.board.GetLength(1));

            return new Vector2(x, y);
        }
    }
}