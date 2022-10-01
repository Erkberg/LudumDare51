using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class GameProgress : MonoBehaviour
    {
        public int currentLevel = 0;
        public bool betweenLevels;

        private int currentLevelEnemiesDied;

        public LevelData GetCurrentLevelData()
        {
            return Game.inst.data.GetLevelData(currentLevel);
        }

        public void OnEnemyDied()
        {
            if (betweenLevels)
                return;

            currentLevelEnemiesDied++;
            if(currentLevelEnemiesDied >= GetCurrentLevelData().enemiesToNextLevel)
            {
                StartCoroutine(LevelChangeSequence());   
            }
            Game.inst.ui.SetProgress((float)currentLevelEnemiesDied / GetCurrentLevelData().enemiesToNextLevel);
        }

        private IEnumerator LevelChangeSequence()
        {
            betweenLevels = true;
            currentLevelEnemiesDied = 0;
            currentLevel++;
            Game.inst.refs.player.area.SuperTrigger();
            yield return new WaitForSeconds(1.67f);
            currentLevelEnemiesDied = 0;
            betweenLevels = false;
        }
    }
}
