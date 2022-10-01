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

        public PlayerController player;

        private void Awake()
        {
            player = Game.inst.refs.player;
        }

        public void Die()
        {
            StartCoroutine(DeathSequence());            
        }

        private IEnumerator DeathSequence()
        {
            Game.inst.progress.OnEnemyDied();
            Game.inst.effects.EmitHearticleAtPosition(move.transform.position);
            anim.OnDeath();
            move.OnDeath();
            yield return new WaitForSeconds(1.33f);
            Destroy(gameObject);
        }
    }
}
