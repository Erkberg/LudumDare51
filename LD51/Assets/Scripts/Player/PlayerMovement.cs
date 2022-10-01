using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class PlayerMovement : MonoBehaviour
    {
        public PlayerController pc;
        public Rigidbody2D rb2d;
        public Collider2D coll;

        private GameInput input;
        private GameData data;
        private Vector2 lastDir;
        private bool isDashing;

        private void Awake()
        {
            input = Game.inst.input;
            data = Game.inst.data;
        }

        private void Update()
        {
            if (isDashing)
                return;

            Move();
            CheckDash();

            if(rb2d.velocity != Vector2.zero)
            {
                lastDir = rb2d.velocity.normalized;
            }
        }

        private void Move()
        {
            rb2d.velocity = input.GetMovement() * data.playerData.baseMoveSpeed;
        }

        private void CheckDash()
        {
            if(input.GetDashDown())
            {
                rb2d.velocity = lastDir * data.playerData.dashMultiplier;
                StartCoroutine(DashSequence());
            }
        }

        private IEnumerator DashSequence()
        {
            isDashing = true;
            coll.enabled = false;
            Game.inst.refs.screenshake.StartShake(0.033f, 0.033f);

            float durationPassed = 0f;
            while(rb2d.velocity.magnitude > 0f && durationPassed < data.playerData.dashDuration)
            {
                durationPassed += Time.deltaTime;
                yield return null;
            }

            coll.enabled = true;
            isDashing = false;
        }

        public bool IsInvincible()
        {
            return !coll.enabled;
        }
    }
}
