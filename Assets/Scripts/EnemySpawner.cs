using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float baseSpawnInterval = 50f;
    private float spawnInterval;
    private float nextSpawnTime = 0;

    void Update()
    {
        // Ajusta el intervalo de creacion segun el nivel del juego
        spawnInterval = Mathf.Max(0.5f, baseSpawnInterval - GameManager.instance.currentPhase * 1.2f);

        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
    //instanciar los enemigos.

    /* 
    void SpawnEnemy()
    {
        Vector3 spawnPos = Random.onUnitSphere * 10f + GameManager.instance.CurrentPlanet.transform.position;
        
        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        enemy.transform.SetParent(GameManager.instance.CurrentPlanet.transform); // Hace al enemigo hijo del planeta
    }*/
    void SpawnEnemy()
{
    // Obtiene la posición del centro del planeta
    Vector3 planetCenter = GameManager.instance.CurrentPlanet.transform.position;
    
    // Obtiene el radio del planeta
    float planetRadius = GameManager.instance.CurrentPlanet.GetComponent<SphereCollider>().radius * GameManager.instance.CurrentPlanet.transform.localScale.x;
    
    // Genera un punto aleatorio en la superficie del planeta
    Vector3 randomDirection = Random.onUnitSphere;
    Vector3 spawnPos = randomDirection * planetRadius * 0.9f + planetCenter; //para que salga un poco por debajo de la superfice del planeta
    // Instancia el enemigo en la posición calculada
    GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    enemy.transform.SetParent(GameManager.instance.CurrentPlanet.transform); // Hace al enemigo hijo del planeta
}
}