using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] private bool isGizmosAvailable;

    [SerializeField] private Transform player;
    [SerializeField] private float distanceFromPlayer;

    [SerializeField] private float detectPlayerDistance;
    private void Update()
    {
        distanceFromPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceFromPlayer < detectPlayerDistance)
        {
            EnemySpawnManager.instance.SaveSpawnPoint(transform);
        }
        else
        {
            EnemySpawnManager.instance.RemoveSpawnPoint(transform);
        }
    }

    private void OnDrawGizmos()
    {
        if (isGizmosAvailable)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(transform.position, detectPlayerDistance);
        }
    }
}