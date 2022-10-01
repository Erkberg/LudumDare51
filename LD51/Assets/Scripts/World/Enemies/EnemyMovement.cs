using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class EnemyMovement : MonoBehaviour
    {
        public Enemy enemy;
        public Rigidbody2D rb2d;

        private void Update()
        {
            Move();
        }

        protected virtual void Move() 
        {
            switch (enemy.data.type)
            {
                case EnemyType.None:
                    break;

                case EnemyType.Follow:
                    Vector2 dir = enemy.player.GetPosition() - transform.position;
                    rb2d.velocity = dir.normalized * enemy.data.moveSpeed;
                    break;
            }
        }
    }
}
