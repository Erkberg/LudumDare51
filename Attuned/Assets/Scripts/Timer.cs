using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ErksUnityLibrary;

namespace Attuned
{
    public class Timer : MonoBehaviour
    {
        public System.Action onTick;

        private float tickDurationPassed;
        private bool paused = true;

        private const float TickDuration = 10f;

        public void OnStartGame()
        {
            paused = false;
        }

        void Update()
        {
            if(!paused)
            {
                Timing.AddTimeAndCheckMax(ref tickDurationPassed, TickDuration, Time.deltaTime, Tick);
                Game.inst.ui.SetTimerText(TickDuration - tickDurationPassed);
            }            
        }

        public void ResetTimer()
        {
            tickDurationPassed = 0f;
        }

        public void SetPaused(bool paused)
        {
            this.paused = paused;
        }

        private void Tick()
        {
            onTick?.Invoke();
        }
    }
}
