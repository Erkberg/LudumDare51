using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class Game : MonoBehaviour
    {
        public static Game inst;

        public GameInput input;
        public GameUI ui;
        public GameData data;
        public new GameAudio audio;

        private void Awake()
        {
            inst = this;
        }
    }
}
