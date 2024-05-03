
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class GameManager : MonoBehaviour

{
   private RotateSphere rotateSphereScript;
    
    public bool isPaused = false; // controla el estado de pausa
    public GameObject pauseImage;
    public Texture2D cursorTexture; //Sprite del cursor
    public Vector2 hotSpot = Vector2.zero; // Punto de activación del cursor
    public static GameManager instance;
    public GameObject planetPrefab; // prefab del planeta 
    private GameObject currentPlanet;// instancia actual del planeta
    public int currentPhase = 1; //fase actual
    public float CrecePlanetaXFase; //contolar cuanto crece planeta por nivel. (redundante-mirar)
    public float planetSizeIncrement = 1.0f; //mirar
    //public Vector3 additionalRotation;
    public GameObject playerPrefab; // prefab del jugador
    private GameObject currentPlayer; // instancia actual del jugador
    public int vidas = 3; // Inicializa las vidas del jugador a 3
    public Text textoNivel;
    public Text textoVidas;
    public Text textoPuntos;
    public int score;
    public int maxScore;
    public int maxScoreH;
    public Text maxScoreText;
    public GameObject CurrentPlayer
    

    {
        get { return currentPlayer; }
    }

    private bool gameHasStarted = false;

    // acceso público a la instancia actual del planeta
    public GameObject CurrentPlanet
    {
        get { return currentPlanet; }
    }

    void Update()
    {
        // presionar una tecla para iniciar el juego
        if (!gameHasStarted)
        {
            gameHasStarted = true;
            CreateNewPlanet();
            CreatePlayer();
            PosicionPlayer();

        }
        // controlar la pausa
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }


        if (SceneManager.GetActiveScene().name == "GameOver" && Input.anyKeyDown)
    {
        // Carga la escena de inicio si estamos en gameOver
        SceneManager.LoadScene("StartScene");
        gameHasStarted = false;
    }
    }
    //quitar el cursor del raton
    void OnDisable()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
    void Start()
    {
        // cursor personalizado,crea el primer planeta e inicia vidas
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
        ActualizarTextoVidas();
        textoNivel.text=""+currentPhase;
        maxScoreH = PlayerPrefs.GetInt("MaxScore");
        maxScore=maxScoreH;
        maxScoreText.text = maxScoreH.ToString();

    }


//singleton
void Awake()
{
    if (instance == null)
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    else
    {
        
        Destroy(this.gameObject);
        return;
    }
    

  
    
}


    //al pasar de fase...
    public void NextPhase()
    {
        
        Destroy(GameManager.instance.currentPlanet);
        currentPlanet = null; // Limpia la referencia después de destruir
        

        currentPhase++;
        planetSizeIncrement += CrecePlanetaXFase;
        // Crea un nuevo planeta con un tamaño mayor
        Debug.Log("Fase actual después de incrementar: " + currentPhase);
        CreateNewPlanet();
        PosicionPlayer();
        if (textoNivel != null)
        textoNivel.text = ""+currentPhase;
    }


  
    void CreateNewPlanet()
    {
        if (planetPrefab != null)
        {
            // Instancia un nuevo planeta
            currentPlanet = Instantiate(planetPrefab, Vector3.zero, Quaternion.identity);
            currentPlanet.transform.localScale = new Vector3(100f, 100f, 100f) * planetSizeIncrement; // Ejemplo de escala
            rotateSphereScript = currentPlanet.GetComponent<RotateSphere>(); 

        }
    }



    void CreatePlayer() //lo dicho
    {
        if (playerPrefab != null)
        {
            currentPlayer = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
           if (rotateSphereScript != null)
        {
        }  

        }

    }


    public void PosicionPlayer() //lo dicho otra vez
    {
        if (currentPlanet != null && currentPlayer != null)
        {
            SphereCollider planetCollider = currentPlanet.GetComponent<SphereCollider>();
            if (planetCollider == null) return; // Asegúrate de que el planeta tenga un SphereCollider

            // Calcula el radio del planeta considerando el collider y la escala actual del planeta
            float planetRadius = planetCollider.radius * Mathf.Max(currentPlanet.transform.localScale.x, currentPlanet.transform.localScale.y, currentPlanet.transform.localScale.z);

            // offset para que el player esté un poco elevado sobre la superficie del planeta
            float surfaceOffset = 0.5f;

            // Calcula la nueva posición del jugador justo encima del planeta
            Vector3 startPosition = new Vector3(0, planetRadius + surfaceOffset, 0);
            currentPlayer.transform.position = currentPlanet.transform.position + startPosition;

            // Orienta al jugador hacia el centro del planeta
            //currentPlayer.transform.LookAt(currentPlanet.transform.position);
            //currentPlayer.transform.Rotate(0, 0, 0);

        }
    }
    public void PerderVida()
    {
        vidas--;
        ActualizarTextoVidas();

        if (vidas <= 0)
        {
            instance.DestruirTodosLosEnemigos();
            //para que no se mueva el planeta mientras se pierde vida
            rotateSphereScript.canRotate=false;
            Invoke("GameOver",2f);

        }
        else
        {
            instance.DestruirTodosLosEnemigos();
            rotateSphereScript.canRotate=false;
            Invoke("ReiniciarFase", 1.0f);
        }
    }
   

    void GameOver()
    {
        vidas=3;
        ActualizarTextoVidas();
        score=0;
        textoNivel.text="1";
        textoPuntos.text="0";
        if(score>maxScoreH){
        maxScoreH = score;
        PlayerPrefs.SetInt("MaxScore", maxScoreH);
        PlayerPrefs.Save();
        maxScoreText.text = "" + maxScoreH;
        rotateSphereScript.canRotate=true;
        }
        SceneManager.LoadScene("GameOver");  // 
    }
    
    void ReiniciarFase()
    {
        Destroy(GameManager.instance.currentPlanet);
        currentPlanet = null;
        CreateNewPlanet();
        PosicionPlayer();
        rotateSphereScript.canRotate=true;
    }

    void ActualizarTextoVidas()
    {
        if (textoVidas != null)
            textoVidas.text = vidas.ToString();
    }

    public void DestruirTodosLosEnemigos()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("EnemyBola");
        foreach (GameObject enemigo in enemigos)
        {
            Destroy(enemigo);
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0; // Detiene el tiempo del juego, lo que pausa todo lo que dependa de Time.deltaTime
        pauseImage.SetActive(true); // Muestra el texto de pausa.
    }
    void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }
    void ResumeGame()
    {
        Time.timeScale = 1; // Restablece 
        pauseImage.SetActive(false); 
    }

   public void AddScore(int pointsToAdd)
{
    score += pointsToAdd;
    textoPuntos.text = "" + score; 
    if (score>maxScore){
        maxScoreText.text = "" + score;
        }
}

//cuando se reinicia el juego despues del gameover, para evitar problemas lo llama desde la escena gameOver.
public static void DestroySingleton()
{
    if (instance != null)
    {
        Destroy(instance.gameObject);
        instance = null;
    }
}
    
}


