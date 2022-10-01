using ErksUnityLibrary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD51
{
    public class EnemySpawner : MonoBehaviour
    {
        public List<Enemy> enemyPrefabs;
        public Vector2 spawnBounds;

        private GameProgress progress;
        private float spawnTimePassed;

        private void Awake()
        {
            progress = Game.inst.progress;
            SpawnEnemy();
        }

        private void Update()
        {
            CheckSpawn();
        }

        private void CheckSpawn()
        {
            float spawnTime = progress.GetCurrentLevelData().spawnTime;
            Timing.AddTimeAndCheckMax(ref spawnTimePassed, spawnTime, Time.deltaTime, SpawnEnemy);
        }

        private void SpawnEnemy()
        {
            EnemyType enemyType = progress.GetCurrentLevelData().GetRandomEnemyType();
            Enemy enemyPrefab = enemyPrefabs.Find(x => x.data.type == enemyType);
            Vector3 spawnPosition = RandomSpawnPosition.GetRandomSpawnPosition2D(spawnBounds.x, spawnBounds.y);
            Enemy enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, transform);
        }
    }
}
