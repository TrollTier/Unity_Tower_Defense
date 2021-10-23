using Assets;
using System;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private Transform GoalPoint;
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private int SpawnsPerWave = 10;
    [SerializeField] private float secondsBetweenSpawns = 1000;

    private int spawnedThisWave = 0;
    private float secondsSinceLastSpawn = 0;

    void Update()
    {
        secondsSinceLastSpawn += Time.deltaTime;

        if (spawnedThisWave >= SpawnsPerWave || secondsSinceLastSpawn < secondsBetweenSpawns)
        {
            return;
        }

        var enemy = GameObject.Instantiate(EnemyPrefab);
        enemy.transform.position = SpawnPoint.transform.position;

        var navAgent = enemy.GetComponent<NavMeshAgent>();

        if (navAgent == null)
        {
            Console.Error.WriteLine("Enemy needs a NavMeshAgent component!");
        }

        navAgent.transform.position = SpawnPoint.transform.position;
        navAgent.SetDestination(GoalPoint.position);

        spawnedThisWave += 1;
        secondsSinceLastSpawn = 0;

        Events.SendEnemySpawned(enemy);
    }
}
