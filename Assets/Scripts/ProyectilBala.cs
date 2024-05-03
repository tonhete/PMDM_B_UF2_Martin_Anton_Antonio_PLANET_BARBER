using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifespan = 5f; // Tiempo de vida del disparo
    private Transform planetCenter;
    public float surfaceDistance = 10f; // Distancia desde la superficie del planeta
    void Start()
    {
     planetCenter = GameManager.instance.CurrentPlanet.transform;
        Destroy(gameObject, lifespan); // Destruye el disparo después de un tiempo determinado
          if (planetCenter != null)
        {
            AdjustHeight();
        }
    }
   void Update()
    {
        if (planetCenter != null)
        {
            AdjustHeight();
        }
    }
    //para controlar la distancia a la superficie del planeta.
  void AdjustHeight()
{
    if (planetCenter == null) return;
    //recupera el collider del planeta y calcula el radio efectivo.
    SphereCollider planetCollider = planetCenter.GetComponent<SphereCollider>();
    float planetRadius = planetCollider.radius;
    
    float effectiveRadius = planetRadius * Mathf.Max(planetCenter.localScale.x, planetCenter.localScale.y, planetCenter.localScale.z);

    //controla la posicion para seguir la curvatura de la superficie del planeta.
    Vector3 toCenter = (transform.position - planetCenter.position).normalized;
    transform.position = planetCenter.position + toCenter * (effectiveRadius + surfaceDistance);
}
}