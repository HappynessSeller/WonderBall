using UnityEngine;
using UnityEngine.InputSystem;

namespace Wonderseat
{
    public class PlayersManager : MonoBehaviour
    {
        public GameObject PlayerPrefab;
        public Transform SpawnPointLeft;
        public Transform SpawnPointRight;

        private PlayerController _playerLeft;
        private PlayerController _playerRight;

        private void Awake()
        {
            var leftInput = PlayerInput.Instantiate(PlayerPrefab, controlScheme: "WASD", pairWithDevice: Keyboard.current);
            leftInput.name = "PlayerLeft";
            _playerLeft = leftInput.GetComponent<PlayerController>();

            var rightInput = PlayerInput.Instantiate(PlayerPrefab, controlScheme: "Arrows", pairWithDevice: Keyboard.current); 
            rightInput.name = "PlayerRight";
            _playerRight = rightInput.GetComponent<PlayerController>();

            Reset();
        }

        public void Reset()
        {
            _playerLeft.Reset(SpawnPointLeft.position);
            _playerRight.Reset(SpawnPointRight.position);
        }
    }
}