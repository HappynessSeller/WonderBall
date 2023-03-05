using UnityEngine;

namespace Wonderseat
{
    public class Game : MonoBehaviour
    {
        public PlayersManager Players;
        public BallManager Ball;

        public void ResetGame()
        {
            Players.Reset();
            Ball.Reset();
        }
    }
}