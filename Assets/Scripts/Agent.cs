using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    private NavMeshAgent agent;
    
    [SerializeField] 
    private Transform objectToFollow;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    
    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(objectToFollow.position);
    }
}
