using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arco : MonoBehaviour
{
    public float maxAngle = 45f;  // El �ngulo m�ximo que el jugador puede rotar el arco
    public float minAngle = -45f; // El �ngulo m�nimo que el jugador puede rotar el arco

    void Update()
    {
        // Obtener la posici�n del mouse en la pantalla
        Vector3 mousePos = Input.mousePosition;
        // Convertir la posici�n del mouse a coordenadas de la escena
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        // Obtener la direcci�n desde el arco hasta la posici�n del mouse
        Vector3 dir = worldPos - transform.position;
        // Calcular el �ngulo de rotaci�n en grados
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        // Limitar el �ngulo m�ximo y m�nimo
        angle = Mathf.Clamp(angle, minAngle, maxAngle);
        // Rotar el arco hacia el �ngulo calculado
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
