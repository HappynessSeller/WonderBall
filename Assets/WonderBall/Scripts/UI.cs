using UnityEngine;
using UnityEngine.UI;

namespace Wonderseat
{
    public class UI : MonoBehaviour
    {
        public Game Game;
        public Button ResetButton;

        private void Awake()
        {
            ResetButton.onClick.AddListener(ResetGame);
        }

        public void ResetGame()
        {
            Game.ResetGame();
        }
    }
}
