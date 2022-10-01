using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ErksUnityLibrary;

namespace LD51
{
    public class GameAudio : MonoBehaviour
    {
        public AudioSource asMusic;
        public AudioSource asAtmo;
        public AudioSource asSounds;

        public AudioClip dashSound;
        public AudioClip areaTriggerSound;
        public AudioClip superAreaTriggerSound;
        public AudioClip playerHurtSound;
        public AudioClip playerDieSound;
        public AudioClip enemyDieSound;
        public AudioClip enemyBulletDieSound;
        public AudioClip enemyBulletSound;
        public AudioClip enemyBulletWideSound;

        public void PlayDashSound()
        {
            asSounds.PlayOneShotRandomVolumePitch(dashSound);
        }

        public void PlayAreaTriggerSound()
        {
            asSounds.PlayOneShot(areaTriggerSound);
        }

        public void PlaySuperAreaTriggerSound()
        {
            asSounds.PlayOneShot(superAreaTriggerSound);
        }

        public void PlayPlayerHurtSound()
        {
            asSounds.PlayOneShot(playerHurtSound);
        }

        public void PlayPlayerDieSound()
        {
            asSounds.PlayOneShot(playerDieSound);
        }

        public void PlayEnemyDieSound()
        {
            asSounds.PlayOneShotRandomVolumePitch(enemyDieSound);
        }

        public void PlayEnemyBulletDieSound()
        {
            asSounds.PlayOneShotRandomVolumePitch(enemyBulletDieSound);
        }

        public void PlayEnemyBulletSound()
        {
            asSounds.PlayOneShotRandomVolumePitch(enemyBulletSound);
        }

        public void PlayEnemyBulletWideSound()
        {
            asSounds.PlayOneShotRandomVolumePitch(enemyBulletWideSound);
        }
    }
}
