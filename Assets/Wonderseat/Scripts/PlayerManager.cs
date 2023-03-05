using UnityEngine;
using UnityEngine.InputSystem;

namespace Wonderseat
{
    public class PlayerManager : MonoBehaviour
    {
        public GameObject PlayerPrefab;
        public Transform SpawnPointLeft;
        public Transform SpawnPointRight;

        private PlayerInput _playerLeft;
        private PlayerInput _playerRight;

        void Awake()
        {
            _playerLeft = PlayerInput.Instantiate(PlayerPrefab, controlScheme: "WASD", pairWithDevice: Keyboard.current);
            _playerLeft.name = "PlayerLeft";
            _playerLeft.transform.position = SpawnPointLeft.position;

            _playerRight = PlayerInput.Instantiate(PlayerPrefab, controlScheme: "Arrows", pairWithDevice: Keyboard.current); 
            _playerRight.name = "PlayerRight";
            _playerRight.transform.position = SpawnPointRight.position;
        }
    }
}