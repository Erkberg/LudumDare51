using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ErksUnityLibrary;
using UnityEngine.Windows;
using UnityEngine.UIElements;

namespace LD51
{
    public class PlayerArea : MonoBehaviour
    {
        public PlayerController pc;
        public Collider2D coll;
        public SpriteRenderer spriteRenderer;
        public ParticleSystem particle;

        private GameData data;
        private float cooldownPassed;
        private float baseScale;

        private void Awake()
        {
            data = Game.inst.data;
            coll.enabled = false;
            transform.SetScale(0f);
            spriteRenderer.SetColorA(0f);
            baseScale = pc.anim.transform.localScale.x;
        }

        private void Update()
        {
            Timing.AddTimeAndCheckMax(ref cooldownPassed, data.playerData.playerAreaCoolDown, Time.deltaTime, Trigger);
            AdjustParticle();
        }

        private void AdjustParticle()
        {
            particle.SetEmissionOverTime(3.33f * cooldownPassed / data.playerData.playerAreaCoolDown);
        }

        private void Trigger()
        {
            Game.inst.refs.screenshake.StartShake(0.133f, 0.133f);
            Game.inst.audio.PlayAreaTriggerSound();
            StartCoroutine(TriggerSequence());
        }

        public void SuperTrigger()
        {
            Game.inst.refs.screenshake.StartShake(0.25f, 0.2f);
            Game.inst.audio.PlaySuperAreaTriggerSound();
            cooldownPassed = 0f;
            StopAllCoroutines();
            StartCoroutine(TriggerSequence(true));
        }

        private IEnumerator TriggerSequence(bool superTrigger = false)
        {
            coll.enabled = true;
            transform.SetScale(0f);
            float timePassed = 0f;
            float duration = superTrigger ? 1.33f : data.playerData.playerAreaDuration;
            float size = superTrigger ? 32f : data.playerData.playerAreaSize;            

            while (timePassed < data.playerData.playerAreaDuration)
            {
                float percentage = timePassed / duration;
                float scale = size * baseScale * percentage;
                spriteRenderer.SetColorA(1f - percentage);
                transform.SetScale(scale);
                timePassed += Time.deltaTime;
                yield return null;
            }
            coll.enabled = false;
            transform.SetScale(baseScale);
            spriteRenderer.SetColorA(0f);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            EnemyInteraction enemy = collision.GetComponent<EnemyInteraction>();
            if(enemy)
            {
                enemy.OnEnterPlayerArea();
            }
        }
    }
}
