using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Attuned
{
    public class Levels : MonoBehaviour
    {
        public List<LevelData> levels;

        private int currentLevel = -1;
        private int ticksThisLevel;

        private void Awake()
        {
            Game.inst.timer.onTick += OnTick;            
        }

        public void OnStartGame()
        {
            StartNextLevel();
        }

        private void OnTick()
        {
            ticksThisLevel++;

            if (ticksThisLevel > 1)
            {
                bool finished = CheckLevelFinished();
                if(!finished)
                {
                    TriggerWrongNotes(false);
                }
            }
            else if(ticksThisLevel == 1)
            {
                Game.inst.ui.SetStateText(true);
                Game.inst.notes.SetSlidersActive(true);
                TriggerWrongNotes(true);
            }
        }

        private void TriggerWrongNotes(bool firstTime)
        {
            Game.inst.notes.TriggerWrongNotes(levels[currentLevel], firstTime);
        }

        private bool CheckLevelFinished()
        {
            int wrongNotesAmount = Game.inst.notes.GetWrongNotesAmount();
            if(wrongNotesAmount == 0)
            {
                Debug.Log("finished level " + currentLevel);
                StartNextLevel();
                return true;
            }

            return false;
        }

        private void StartNextLevel()
        {
            ticksThisLevel = 0;
            currentLevel++;            

            if (currentLevel >= levels.Count)
            {
                Game.inst.OnGameEnd();
            }
            else
            {
                Game.inst.notes.InitLevel(levels[currentLevel]);
                Game.inst.ui.SetStateText(false);
                Game.inst.ui.SetLevelText(levels[currentLevel].name);
                Game.inst.notes.SetSlidersActive(false);
            }                
        }

        private void Update()
        {
            
        }
    }
}
