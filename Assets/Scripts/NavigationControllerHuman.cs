using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationControllerHuman : MonoBehaviour
{
    private NavMeshAgent navAgent;
    private Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        navAgent.SetDestination(Camera.main.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StopNavigation()
    {
        navAgent.isStopped = true;
    }
}
