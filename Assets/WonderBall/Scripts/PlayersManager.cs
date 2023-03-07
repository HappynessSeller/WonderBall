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

        private void OnValidate()
        {
            if (PlayerPrefab == null || PlayerPrefab.GetComponent<PlayerController>() == null)
            {
                Debug.LogException(new System.Exception("Invalid PlayerManager Configuration, please check player prefab configuration"));
            }
        }

        public void StartGame()
        {
            var leftInput = PlayerInput.Instantiate(PlayerPrefab, controlScheme: "WASD", pairWithDevice: Keyboard.current);
            leftInput.name = "PlayerLeft";
            leftInput.transform.parent = transform;
            _playerLeft = leftInput.GetComponent<PlayerController>();

            var rightInput = PlayerInput.Instantiate(PlayerPrefab, controlScheme: "Arrows", pairWithDevice: Keyboard.current); 
            rightInput.name = "PlayerRight";
            rightInput.transform.parent = transform;
            _playerRight = rightInput.GetComponent<PlayerController>();

            Reset();
        }

        public void Reset()
        {
            _playerLeft.Reset(SpawnPointLeft.position);
            _playerRight.Reset(SpawnPointRight.position);
        }

        public void OnPointScored(PlayerSide side)
        {
            // making the game a bit harder for winning player to make competition more interesting
            
            PlayerController winningPlayer = GetPlayer(side);
            winningPlayer.OnPointScored(); 

            PlayerController loosingPlayer = GetPlayer(side.GetOpponentSide());
            loosingPlayer.OnPointLost();
        }

        private PlayerController GetPlayer(PlayerSide side)
        {
            switch (side)
            {
                case PlayerSide.Left:
                    return _playerLeft;
                case PlayerSide.Right:
                    return _playerRight;
                default:
                    throw new System.NotSupportedException($"Player side {side} is not supported");
            }
        }
    }
}