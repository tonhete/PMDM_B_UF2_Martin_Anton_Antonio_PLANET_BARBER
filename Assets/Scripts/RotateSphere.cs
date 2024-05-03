
using UnityEngine;

public class RotateSphere : MonoBehaviour
{
    public bool canRotate = true;
    public float StrafeSpeed;
    public float rotationSpeed = 30f;
    public Transform player;
    private Transform planeta;
    public float surfaceOffset = 0.1f;
    public GameObject monolito;
    

    void Start()
    {
        planeta = GameManager.instance.CurrentPlanet.transform;
        InitializePlayerPosition();
        //Invoke("MonolitoRandom",5f);
         ScheduleMonolito();
    }

    void Update()
    {
        RotatePlanetBasedOnInput();
    }
    public void PauseRotation()
    {
        canRotate = false;
    }

    public void ResumeRotation()
    {
        canRotate = true;
    }

//configura posicion inicial del player en el planeta
    private void InitializePlayerPosition()
    {
        if (planeta != null && player != null)
        {
            float planetRadius = planeta.GetComponent<SphereCollider>().radius * planeta.localScale.x;
            Vector3 startPosition = new Vector3(0, planetRadius + surfaceOffset, 0);
            player.position = planeta.position + startPosition;
            player.LookAt(planeta.position);
            player.Rotate(90, 0, 0);
        }
    }
    //rotar el planeta para simular movimiento jugador.
    private void RotatePlanetBasedOnInput()
    {
        if (canRotate)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical") * -1;
            
            planeta.Rotate(vertical * rotationSpeed * Time.deltaTime, -horizontal * rotationSpeed * Time.deltaTime * StrafeSpeed, 0, Space.World);
      
        }
    }

    //temporizador para la aparicion del monolito
    void ScheduleMonolito()
    {

        // Cancela cualquier invocación anterior para evitar múltiples monolitos
        CancelInvoke("MonolitoRandom");
        float delay = (GameManager.instance.currentPhase *2)+8f;  // Aumenta el retardo inicial de salida del monolito
        Invoke("MonolitoRandom", delay);
    }

    void MonolitoRandom()
    {
        float planetRadius = planeta.GetComponent<SphereCollider>().radius * planeta.localScale.x;
        // Genera un punto aleatorio en la superficie de una esfera
        Vector3 pointOnSphere = Random.onUnitSphere * planetRadius;

        // orientacion correctamente con respecto al planeta
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, pointOnSphere.normalized);

        // Instancia el monolito en el punto generado con la orientación adecuada
        GameObject mono = Instantiate(monolito, pointOnSphere + transform.position, rotation);
        mono.transform.localScale = mono.transform.localScale * (GameManager.instance.planetSizeIncrement);
        mono.transform.SetParent(planeta);
    }
}








