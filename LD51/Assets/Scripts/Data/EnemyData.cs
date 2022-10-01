using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    [CreateAssetMenu]
    public class EnemyData : ScriptableObject
    {
        public EnemyType type;
        public float moveSpeed = 2f;        
        public float playerDistance = 6.67f;
        public float shootCoolDown = 2f;
        public bool aimAtPlayer;
        public float lifetime;
    }
}
