using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerMovement move;
        public PlayerInteraction interact;
        public PlayerAnimation anim;

        public int health = 3;

        public void OnEnterEnemy()
        {
            health--;
            Game.inst.ui.SetHealth(health);
            anim.OnHit();

            if(health <= 0)
            {
                Die();
            }            
        }

        private void Die()
        {
            Game.inst.Restart();
        }

        public Vector3 GetPosition()
        {
            return move.transform.position;
        }
    }
}
