using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class GameData : MonoBehaviour
    {
        public PlayerData playerData;
        public List<EnemyData> enemyData;

        public EnemyData GetEnemyData(EnemyType type)
        {
            return enemyData.Find(x => x.type == type);
        }
    }
}
