using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectilePrefab;
    public float fireRate = 0.5f; // Tiempo entre disparos
    private float nextFireTime = 0f;
    public float projectileSpeed = 20f; // Velocidad del disparo
    public float shotAngleDeviation = 5f; // Ángulo de desviación del disparo (para controlar con el planeta)
     public Vector3 spawnOffset; //para ajustar donde instancia el disparo.

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            //para controlar el fire rate.
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
       //instancia el prefab shoot.
       
        Vector3 spawnPosition = GameManager.instance.CurrentPlayer.transform.position+spawnOffset;

        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Calcula la nueva dirección para seguir la superficie del planeta
            Quaternion shotRotation = Quaternion.Euler(0, shotAngleDeviation, 0);
            Vector3 deviationDirection = shotRotation * firePoint.forward;

            rb.velocity = deviationDirection * projectileSpeed;
        }
    }
}