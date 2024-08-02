using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public static EnemySpawnManager instance;

    [SerializeField] private List<Transform> enemySpawnPoints;
    [SerializeField] private GameObject[] enemyPrefab;

    [SerializeField] private float spawnTimer;

    private void Awake()
    {
        instance = this;
        StartCoroutine(EnemySpawnCoroutine());
    }

    private IEnumerator EnemySpawnCoroutine()
    {
        while (true)
        {
            if(enemySpawnPoints.Count > 0)
            {
                int index = Random.Range(0, enemySpawnPoints.Count);
                int enemyIndex = Random.Range(0,enemyPrefab.Length);

                Transform spawnPoint = enemySpawnPoints[index];

                Instantiate(enemyPrefab[enemyIndex], spawnPoint.position, Quaternion.identity);
            }

            yield return new WaitForSeconds(spawnTimer);

        }
    }

    public void SaveSpawnPoint(Transform spawnPoint)
    {
        if(!enemySpawnPoints.Contains(spawnPoint))
        {
            // Eger spawnPoint listede yok ise buraya gelir
            enemySpawnPoints.Add(spawnPoint);
        }
    }

    public void RemoveSpawnPoint(Transform spawnPoint)
    {
        if(enemySpawnPoints.Contains(spawnPoint))
        {
            // Eger spawnPoint listede var ise buraya gelir.
            enemySpawnPoints.Remove(spawnPoint);
        }
    }
}