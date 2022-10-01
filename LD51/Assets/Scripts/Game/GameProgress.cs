using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class GameProgress : MonoBehaviour
    {
        public int currentLevel = 0;

        public LevelData GetCurrentLevelData()
        {
            return Game.inst.data.GetLevelData(currentLevel);
        }
    }
}
