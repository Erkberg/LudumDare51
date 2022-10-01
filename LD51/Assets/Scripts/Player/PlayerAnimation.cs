using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ErksUnityLibrary;

namespace LD51
{
    public class PlayerAnimation : MonoBehaviour
    {
        public PlayerController pc;
        public Animator animator;
        public SpriteRenderer spriteRenderer;
        public FlickerRenderers flickerRenderers;

        private void Update()
        {
            CheckInvincible();
        }

        private void CheckInvincible()
        {
            spriteRenderer.SetColorA(pc.move.IsInvincible() ? 0.167f : 1f);
        }

        public void OnHit()
        {
            flickerRenderers.StartFlicker(0.33f);
        }
    }
}
