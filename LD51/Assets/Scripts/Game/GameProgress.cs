using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class GameProgress : MonoBehaviour
    {
        public int currentLevel = 0;

        private int currentLevelEnemiesDied;

        public LevelData GetCurrentLevelData()
        {
            return Game.inst.data.GetLevelData(currentLevel);
        }

        public void OnEnemyDied()
        {
            currentLevelEnemiesDied++;
            if(currentLevelEnemiesDied >= GetCurrentLevelData().enemiesToNextLevel)
            {
                currentLevelEnemiesDied = 0;
                currentLevel++;
            }
            Game.inst.ui.SetProgress((float)currentLevelEnemiesDied / GetCurrentLevelData().enemiesToNextLevel);
        }
    }
}
