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
            if (ticksThisLevel != 0)
            {
                CheckLevelFinished();
            }

            ticksThisLevel++;
        }

        private void CheckLevelFinished()
        {
            int wrongNotesAmount = Game.inst.notes.GetWrongNotesAmount();
            if(wrongNotesAmount == 0)
            {
                StartNextLevel();
            }
        }

        private void StartNextLevel()
        {
            currentLevel++;
            if(currentLevel >= levels.Count)
            {
                Debug.Log("all levels finished");
            }
            else
            {
                Game.inst.notes.InitLevel(levels[currentLevel]);
            }                
        }

        private void Update()
        {
            
        }
    }
}
