using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    public bool isDead = false;
    public NavigationControllerHuman navMeshController;
    public GameObject agentPhone;
    public Animator animator;
    public Rigidbody rb_Pelvis;
    public float maxForceExplosion = 3.0f;
    public float maxForcePush = 30.0f;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleCollision(Collision collision, Rigidbody rb_hit)
    {
        if (isDead) return;
        audioSource.Play();
        isDead = true;
        navMeshController.StopNavigation();
        animator.enabled = false;
        Destroy(collision.gameObject);
        agentPhone.transform.SetParent(null,true);
        Vector3 ImpactDirection = (rb_hit.gameObject.transform.position - collision.GetContact(0).point).normalized;
        rb_Pelvis.AddForce(ImpactDirection* maxForcePush, ForceMode.Impulse);
        Rigidbody rb = agentPhone.AddComponent<Rigidbody>();
        rb.detectCollisions = true;
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        rb.velocity = new Vector3(Random.Range(0.0f, maxForceExplosion), 8.0f, Random.Range(0.0f, maxForceExplosion));
        rb.angularVelocity = Random.insideUnitSphere * 200.0f;
        BoxCollider bc = agentPhone.AddComponent<BoxCollider>();
        bc.isTrigger = false;
    }
}
