using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarController : MonoBehaviour
{
    private NavMeshAgent agent;
    public static NavMeshSurface surface;
    public Transform target;
    public static List<Transform> wayPoints = new List<Transform>();
    private void Start()
    {
        surface = FindObjectOfType<NavMeshSurface>();
        agent = GetComponent<NavMeshAgent>();
        
        
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            agent.enabled = true; 
            agent.SetDestination(wayPoints[wayPoints.Count - 1].position);
        }
    }
}
