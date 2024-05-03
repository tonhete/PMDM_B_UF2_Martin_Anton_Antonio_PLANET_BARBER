using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyGravity : MonoBehaviour
{
    private Transform planetCenter;
    public float gravityForce = 9.8f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Obtiene el centro del planeta desde el GameManager
        planetCenter = GameManager.instance.CurrentPlanet.transform;
        
        
    }
    //para simular que la gravedad viene del planeta.
    void FixedUpdate()
    {
        if (planetCenter != null)
        {
            Vector3 gravityDirection = (transform.position - planetCenter.position).normalized;
            rb.AddForce(-gravityDirection * gravityForce);
        }
    }
}