using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CameraFollow : MonoBehaviour

{
    public Transform target; // El jugador
    public float height = 10f; // Altura sobre el jugador
    public float rotationDamping = 5f;
    public float zoomSpeed = 4f; // Velocidad de acercamiento/alejamiento
    public float minZoom = 5f; // Distancia mínima de zoom
    public float maxZoom = 20f; // Distancia máxima de zoom



      public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void Update()
    {
        // Zoom de la cámara con la rueda del ratón
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        height -= scroll * zoomSpeed;
        height = Mathf.Clamp(height, minZoom, maxZoom);

        // Salir del juego al presionar Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void LateUpdate()
    {
        // Actualizar la posición para mantener la altura
       Vector3 newPos = target.position + Vector3.up * height;
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * zoomSpeed);

        // para mirar hacia abajo al player.
        transform.LookAt(target.position);
        {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
    }
}


