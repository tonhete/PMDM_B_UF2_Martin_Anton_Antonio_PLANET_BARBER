using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private float baseSpeed = 10f;  // Velocidad  del enemigo
    private Rigidbody rb;
    private Transform playerTransform; // Para almacenar la referencia al  jugador
    public GameObject explosionPrefab;
    private float speed; // Velocidad actual que se actualizará según el nivel
private bool increasingSpeed = false;
public float increaseSpeedTime = 30f;
private float elapsedTime =0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = baseSpeed + GameManager.instance.currentPhase * 1.5f;
        increaseSpeedTime+=GameManager.instance.currentPhase+5;
        GameObject player = GameObject.FindWithTag("Player"); 
        if (player != null)
        {
            playerTransform = player.transform;
        }
        // dirección aleatoria al inicio
        Vector3 randomDirection = Random.onUnitSphere;
        randomDirection.y = 0; // 
        rb.AddForce(randomDirection * baseSpeed, ForceMode.VelocityChange);
    }

    void Update()
    {
         // Incrementa el tiempo transcurrido
        elapsedTime += Time.deltaTime;

        // Verifica si ha pasado el tiempo para aumentar la velocidad y si no se está aumentando ya
        if (elapsedTime >= increaseSpeedTime)
        {
            // Aumenta la velocidad 
            speed *= 1.0008f; 

            // Actualiza la velocidad del Rigidbody
            rb.velocity = rb.velocity.normalized * speed;

            // Indica que se está aumentando la velocidad
            increasingSpeed = true;
        }
        
        if (playerTransform != null)
        {
           

            Vector3 direction = (playerTransform.position - transform.position).normalized;
            direction.y = 0; // no mover hacia arriba o hacia abajo

          
            rb.velocity = direction * speed;
        }
    }

    void OnTriggerEnter(Collider other)
    {   //si choca con shoot...
        if (other.CompareTag("ProyectilBala")) 
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            GameObject planet = GameManager.instance.CurrentPlanet;
            explosion.transform.SetParent(planet.transform); // Hace al enemigo hijo del planeta
            
            //play sonido explosion en la propia explosion
            Destroy(explosion, 2.0f); 
            Destroy(gameObject); // Destruye el enemigo
            Destroy(other.gameObject); //destruye el proyectil
            GameManager.instance.AddScore(100); 
        }
    }
}
