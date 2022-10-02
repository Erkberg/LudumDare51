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
        public Settings settings;
        public Screenshake screenshake;
        public bool hardMode;

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

        public void OnGameEnd()
        {
            Debug.Log("all levels finished");
        }

        public bool IsIngame()
        {
            return state == State.Ingame;
        }

        public void OnTimeChanged(float value)
        {
            Time.timeScale = value;
            notes.SetPitchAll(value);
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
