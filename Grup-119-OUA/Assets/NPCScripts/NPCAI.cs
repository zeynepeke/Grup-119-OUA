using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{

    [SerializeField] private GameObject destinationPoint;
    private NavMeshAgent _agent;
    void Start()
    {
       _agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        _agent.SetDestination(destinationPoint.transform.position);
    }
}
