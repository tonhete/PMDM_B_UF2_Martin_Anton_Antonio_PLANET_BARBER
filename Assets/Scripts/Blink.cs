using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour
{
    public Light spotLight; // Referencia a la luz
    public float onTime = 1f; //segundos que la luz permanece encendida
    public float offTime = 1f; // segundos que la luz permanece apagada

    private void Start()
    {
        
        StartCoroutine(FlashLight());
    }

    IEnumerator FlashLight()
    {
        // Bucle infinito
        while (true)
        {
           
            spotLight.enabled = true;
            
            yield return new WaitForSeconds(onTime);
           
            spotLight.enabled = false;
           
            yield return new WaitForSeconds(offTime);
        }
    }
}
