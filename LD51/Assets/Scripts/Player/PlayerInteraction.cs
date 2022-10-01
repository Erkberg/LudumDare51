using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class PlayerInteraction : MonoBehaviour
    {
        public PlayerController pc;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            EnemyInteraction enemy = collision.GetComponent<EnemyInteraction>();
            if(enemy)
            {
                pc.OnEnterEnemy();
            }
        }
    }
}
