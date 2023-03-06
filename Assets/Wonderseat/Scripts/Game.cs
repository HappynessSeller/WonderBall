using UnityEngine;

namespace Wonderseat
{
    public class Game : MonoBehaviour
    {
        public PlayersManager Players;
        public BallManager Ball;

        private void Start()
        {
            Players.StartGame();
            Ball.StartGame(OnBallTouchedGround);
        }

        public void OnBallTouchedGround(PlayerSide side)
        {
            Players.OnPointScored(side);
            ResetGame();
        }

        public void OnResetGame()
        {
            ResetGame();
        }

        public void ResetGame()
        {
            Players.Reset();
            Ball.Reset();
        }
    }
}