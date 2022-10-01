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
        }

        private void Trigger()
        {
            StartCoroutine(TriggerSequence());
        }

        private IEnumerator TriggerSequence()
        {
            coll.enabled = true;
            transform.SetScale(0f);
            float timePassed = 0f;
            while(timePassed < data.playerData.playerAreaDuration)
            {
                float percentage = timePassed / data.playerData.playerAreaDuration;
                float scale = data.playerData.playerAreaSize * baseScale * percentage;
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
