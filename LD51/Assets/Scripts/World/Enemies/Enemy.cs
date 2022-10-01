using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class Enemy : MonoBehaviour
    {
        public EnemyData data;
        public EnemyMovement move;
        public EnemyInteraction interact;
        public EnemyAnimation anim;
        public EnemyShoot shoot;

        public PlayerController player;
        public bool isDying;

        private void Awake()
        {
            player = Game.inst.refs.player;
            if(data.lifetime > 0f)
            {
                Destroy(gameObject, data.lifetime);
            }
        }

        public void Die()
        {
            StartCoroutine(DeathSequence());            
        }

        private IEnumerator DeathSequence()
        {
            isDying = true;
            if(data.type != EnemyType.Bullet)
            {
                Game.inst.progress.OnEnemyDied();
                Game.inst.effects.EmitHearticleAtPosition(move.transform.position);
                move.OnDeath();
                anim.OnDeath();
            }        
            else
            {
                anim.OnDeath(3.33f);
            }
                      
            yield return new WaitForSeconds(1.33f);
            Destroy(gameObject);
        }
    }
}
