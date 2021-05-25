using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void onEnteredCollision(Collision collision, Rigidbody rb);


public class ColliderCheck : MonoBehaviour
{
    public onEnteredCollision collisionEntered;
    void Start()
    {
        AgentController ac = transform.root.GetComponent<AgentController>();
        collisionEntered += ac.HandleCollision;
    }

    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Projectile"))
        {
            Debug.Log(transform.name);
            if (collisionEntered != null)
            {
                Rigidbody rb = GetComponent<Rigidbody>();
                collisionEntered(collision, rb);
            }
        }            
    }
}
