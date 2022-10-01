using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    [CreateAssetMenu]
    public class PlayerData : ScriptableObject
    {
        public float baseMoveSpeed = 3.33f;
        public float dashMultiplier = 6.67f;
        public float dashDuration = 0.33f;

        public float playerAreaCoolDown = 10f;
        public float playerAreaDuration = 1f;
        public float playerAreaSize = 3.33f;
    }
}
