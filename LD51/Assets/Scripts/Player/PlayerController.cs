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

        public void OnEnterEnemy()
        {
            Die();
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
