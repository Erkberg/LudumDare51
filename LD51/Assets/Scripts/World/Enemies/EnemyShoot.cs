using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ErksUnityLibrary;

namespace LD51
{
    public class EnemyShoot : MonoBehaviour
    {
        public Enemy enemy;
        public Enemy bulletPrefab;

        private float coolDownPassed;

        void Update()
        {
            if (enemy.isDying)
                return;

            if(enemy.data.aimAtPlayer)
            {
                AdjustRotation(enemy.player.GetPosition() - transform.position);
            }

            CheckShoot();
        }

        private void CheckShoot()
        {
            Timing.AddTimeAndCheckMax(ref coolDownPassed, enemy.data.shootCoolDown, Time.deltaTime, Shoot);
        }

        private void Shoot()
        {
            Enemy bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.move.rb2d.velocity = transform.right * bullet.data.moveSpeed;

            if(enemy.data.type == EnemyType.Shoot)
            {
                Game.inst.audio.PlayEnemyBulletSound();
            }
            else
            {
                Game.inst.audio.PlayEnemyBulletWideSound();
            }
        }

        private void AdjustRotation(Vector2 dir)
        {
            if (dir != Vector2.zero)
            {
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
    }
}
