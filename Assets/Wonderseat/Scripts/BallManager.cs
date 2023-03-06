using UnityEngine;
using System;

namespace Wonderseat
{
    public class BallManager : MonoBehaviour
    {
        public BallController BallPrefab;
        public Transform BallSpawnPoint;

        private BallController _ball;
        
        public void StartGame(Action<PlayerSide> onBallTourchedGround)
        {
            _ball = Instantiate<BallController>(BallPrefab, BallSpawnPoint.position, Quaternion.identity);
            _ball.OnTouchedGround = onBallTourchedGround;
            _ball.transform.parent = transform;
        }

        public void Reset()
        {
            _ball.Reset(BallSpawnPoint.position);
        }
    }
}
