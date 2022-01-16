using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveHelper : MonoBehaviour
{
    [NonSerialized] public GameObject Target;

    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Target != null)
        {
            _agent.SetDestination(Target.transform.position);
        }
    }
}