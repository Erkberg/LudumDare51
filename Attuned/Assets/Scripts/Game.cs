using ErksUnityLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        public new Audio audio;
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
            state = State.End;
            timer.ResetTimer();
            timer.SetPaused(true);
            ui.OnEnd();
        }

        public bool IsIngame()
        {
            return state == State.Ingame;
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
