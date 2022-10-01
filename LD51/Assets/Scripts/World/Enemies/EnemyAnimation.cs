using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ErksUnityLibrary;

namespace LD51
{
    public class EnemyAnimation : MonoBehaviour
    {
        public SpriteRenderer spriteRenderer;
        public Animator animator;
        public FadeSprite fadeSprite;

        public void OnDeath(float duration = 1f)
        {
            fadeSprite.StartFade("out", false, duration, 0f);
        }
    }
}
