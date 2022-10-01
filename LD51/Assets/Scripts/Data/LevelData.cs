using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ErksUnityLibrary;

namespace LD51
{
    [CreateAssetMenu]
    public class LevelData : ScriptableObject
    {
        public float spawnTime = 3.33f;
        public List<EnemyType> enemyTypes;

        public EnemyType GetRandomEnemyType()
        {
            return enemyTypes.GetRandomItem();
        }
    }
}
