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
        public PlayerArea area;

        public int health = 3;

        public void OnEnterEnemy()
        {
            Game.inst.refs.screenshake.StartShake(0.1f, 0.1f);
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
