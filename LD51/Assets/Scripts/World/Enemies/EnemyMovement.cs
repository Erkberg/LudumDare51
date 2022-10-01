using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LD51
{
    public class EnemyMovement : MonoBehaviour
    {
        public Enemy enemy;
        public Rigidbody2D rb2d;

        private void Update()
        {
            if(!rb2d.isKinematic)
            {
                Move();
            }            
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
                    AdjustRotation(dir);
                    break;
            }
        }

        private void AdjustRotation(Vector2 dir)
        {
            if (dir != Vector2.zero)
            {
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }

        public void OnDeath()
        {
            rb2d.isKinematic = true;
            rb2d.velocity = Vector2.zero;
        }
    }
}
