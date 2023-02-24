using UnityEngine;

namespace Specific.Gameplay
{
    public class GameplayController : MonoBehaviour
    {
        public GameObject boardObject; // the game board object
        private GameBoard _board;
        public GameState GameState; // whether the game is active or not

        void Start()
        {
            GameState = GameState.Starting; // set the game to active
            
            _board = boardObject.GetComponent<GameBoard>(); // get the game board
            _board.ResetBoard(4);

            GameState = GameState.Playing;
        }
        
        void Update()
        {
            Debug.Log($"GameState: {GameState.ToString()}");
            if (GameState == GameState.Generating)
            {
                if (_board.GenerateNewTile())
                {
                    GameState = GameState.Playing;
                }
                else
                {
                    GameState = GameState.EndGame;
                }
                
                return;
            }
            
            if (GameState != GameState.Playing) // if the game is not active
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow)) 
            {
                GameState = GameState.Matching;
                _board.PushTowardsDirection(Direction.Right);
                GameState = GameState.Generating;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow)) 
            {
                GameState = GameState.Matching;
                _board.PushTowardsDirection(Direction.Left);
                GameState = GameState.Generating;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow)) 
            {
                GameState = GameState.Matching;
                _board.PushTowardsDirection(Direction.Up);
                GameState = GameState.Generating;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow)) 
            {
                GameState = GameState.Matching;
                _board.PushTowardsDirection(Direction.Down);
                GameState = GameState.Generating;
            }
            
        }
    }
}