using UnityEngine;
using System;

namespace Wonderseat
{
    public class BallManager : MonoBehaviour
    {
        public BallController BallPrefab;
        public Transform BallSpawnPointLeft;
        public Transform BallSpawnPointRight;

        private BallController _ball;
        
        public void StartGame(Action<PlayerSide> onBallTourchedGround)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            _ball = Instantiate<BallController>(BallPrefab, spawnPosition, Quaternion.identity);
            _ball.OnTouchedGround = onBallTourchedGround;
            _ball.transform.parent = transform;
        }

        public void Reset()
        {
            _ball.Reset(GetRandomSpawnPosition());
        }

        public void OnPointScored(PlayerSide side)
        {
            _ball.Reset(GetSpawnPositionByPlayerSide(side.GetOpponentSide()));
        }

        private Vector3 GetRandomSpawnPosition()
        {
            return new System.Random().Next(0, 2) == 1 ? 
                BallSpawnPointLeft.position : 
                BallSpawnPointRight.position;
        }

        private Vector3 GetSpawnPositionByPlayerSide(PlayerSide side)
        {
            switch (side)
            {
                case PlayerSide.Left:
                    return BallSpawnPointLeft.position;
                case PlayerSide.Right:
                    return BallSpawnPointRight.position;
                default:
                    throw new System.NotSupportedException($"Player side {side} is not supported");
            }
        }
    }
}
