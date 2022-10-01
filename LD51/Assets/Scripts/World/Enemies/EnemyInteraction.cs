using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class EnemyInteraction : MonoBehaviour
    {
        public Enemy enemy;
        public Collider2D coll;

        public void OnEnterPlayerArea()
        {
            coll.enabled = false;
            enemy.Die();
        }
    }
}
