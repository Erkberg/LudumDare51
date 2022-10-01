using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LD51
{
    public class Game : MonoBehaviour
    {
        public static Game inst;

        public GameInput input;
        public GameUI ui;
        public GameData data;
        public GameRefs refs;
        public GameProgress progress;
        public GameEffects effects;
        public new GameAudio audio;

        private void Awake()
        {
            inst = this;
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
