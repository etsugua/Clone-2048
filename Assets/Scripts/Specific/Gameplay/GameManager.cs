using System;
using UnityEngine;

namespace Specific.Gameplay
{
    public class GameManager : MonoBehaviour {
        private GameBoard _board; // the game board
        private GameplayController _controller; // the gameplay controller

        private void Awake()
        {
            _board = GetComponent<GameBoard>();
            _controller = GetComponent<GameplayController>();
            
            
        }
    }
}