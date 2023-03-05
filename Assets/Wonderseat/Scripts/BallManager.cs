using UnityEngine;

namespace Wonderseat
{
    public class BallManager : MonoBehaviour
    {
        public BallController BallPrefab;
        public Transform BallSpawnPoint;

        private BallController _ball;
        
        private void Awake()
        {
            _ball = Instantiate<BallController>(BallPrefab, BallSpawnPoint.position, Quaternion.identity);
            _ball.transform.parent = transform;
        }

        public void Reset()
        {
            _ball.Reset(BallSpawnPoint.position);
        }
    }
}
