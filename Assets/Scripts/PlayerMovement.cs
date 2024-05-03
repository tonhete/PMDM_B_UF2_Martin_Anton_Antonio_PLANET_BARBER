using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;




public class PlayerMovement : MonoBehaviour
{
    
    private Transform planetCenter;
    public Transform playerTransform; // La transformación del personaje
    public float rotationSpeed = 5f;
    public int vidas = 3;

    public Text textoVidas;

    public Camera cam;

    private Animator animator;

    public GameObject explosionPlayer;
    
    private Collider playerCollider; 
   

 void Start()
    {
        //obtiene referencias del collider y el animator del player.
        playerCollider = GetComponent<Collider>();  
        animator = GetComponentInChildren<Animator>();

    }
    void Update()
    {
        //para manejar la animacion de correr del player
        if (animator != null)
        {
            // Comprobar  `W` o `S` 
            bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S);

            //  estado de isRunning en el Animator del player
            animator.SetBool("IsRunning", isMoving);

        }

        //  posición del ratón en pantalla
        Vector3 mouseScreenPosition = Input.mousePosition;

        // Convierte posición del raton en pantalla a una posición en el mundo 3D
        // Se asume una profundidad fija para simplificar
        mouseScreenPosition.z = cam.transform.position.y - transform.position.y;
        Vector3 mouseWorldPosition = cam.ScreenToWorldPoint(mouseScreenPosition);

        // Calcula  direccion hacia la que  mirar
        Vector3 direction = mouseWorldPosition - transform.position;

        // si el vector != 0
        if (direction != Vector3.zero)
        {
            // Calcula la rotación necesaria para mirar en esa dirección
            Quaternion lookRotation = Quaternion.LookRotation(direction);

            // Aplica la rotación al personaje
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10);
        }

    }

    void AlignPlayerToSurface() //ya lo dice el nombre
    {
        if (GameManager.instance.CurrentPlanet != null)
        {
            planetCenter = GameManager.instance.CurrentPlanet.transform;
            // Calcula la normal desde el centro del planeta hasta el personaje
            Vector3 gravityDirection = (playerTransform.position - planetCenter.position).normalized;

            // Aquí se alinea el 'arriba' del personaje con la normal calculada, de modo que la parte inferior del personaje siempre apunta hacia el centro del planeta
            Quaternion toRotation = Quaternion.FromToRotation(playerTransform.up, gravityDirection) * playerTransform.rotation;
            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, toRotation, Time.deltaTime * 1f);

        }
    }

    //los trigers del player
    void OnTriggerEnter(Collider other)
    {   //monolito para pasar de fase.
        if (other.CompareTag("Monolito"))
        {
            GameManager.instance.NextPhase();
        }
        //cuando le da un enemigo pierde vida.
        else if (other.CompareTag("EnemyBola"))
        {
            GameObject explosion = Instantiate(explosionPlayer, transform.position, Quaternion.identity);
            
            GameManager.instance.PerderVida();

        }
      
    }
}