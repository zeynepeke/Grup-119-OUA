using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBase : MonoBehaviour
{
    public EnemyAI enemyAI;

    public int damage;
    public float colliderRadius;
    public float movementSpeed;

    [SerializeField] private SphereCollider vcollider;

    public virtual void Awake()
    {
        enemyAI = GetComponent<EnemyAI>();
        vcollider.radius = colliderRadius;

        GetComponent<EnemyMovement>().movementSpeed = movementSpeed;

    }
}