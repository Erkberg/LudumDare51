using ErksUnityLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Attuned
{
    public class Game : MonoBehaviour
    {
        public static Game inst;

        public State state;
        public UI ui;
        public Timer timer;
        public Levels levels;
        public Notes notes;
        public Screenshake screenshake;

        private void Awake()
        {
            inst = this;
        }

        public void OnStartGame()
        {
            state = State.Ingame;
            timer.OnStartGame();
            levels.OnStartGame();
        }

        public bool IsIngame()
        {
            return state == State.Ingame;
        }

        public enum State
        {
            None,
            Title,
            Ingame,
            End
        }
    }
}
