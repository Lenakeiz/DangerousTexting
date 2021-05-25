using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
     private GameObject prefabProjectile;
    [SerializeField] private float initialSpeed = 10.0f;
    [SerializeField] private float initialLifetime = 5.0f;
    public AudioSource audioSource;
    void Start()
    {
        if (prefabProjectile == null) Debug.LogError("Assign projectile to the launger");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            audioSource.Play();
            Ray cameraToMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            GameObject proj = GameObject.Instantiate(prefabProjectile, cameraToMouse.origin, Quaternion.identity);
            Rigidbody rb = proj.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.velocity = cameraToMouse.direction * initialSpeed;
                rb.angularVelocity = Random.insideUnitSphere * 100.0f;
            }

            Destroy(proj, initialLifetime);
        }
    }
}
