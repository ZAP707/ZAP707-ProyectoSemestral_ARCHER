using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arco : MonoBehaviour
{
    public float maxAngle = 45f;  // El ángulo máximo que el jugador puede rotar el arco
    public float minAngle = -45f; // El ángulo mínimo que el jugador puede rotar el arco

    void Update()
    {
        // Obtener la posición del mouse en la pantalla
        Vector3 mousePos = Input.mousePosition;
        // Convertir la posición del mouse a coordenadas de la escena
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        // Obtener la dirección desde el arco hasta la posición del mouse
        Vector3 dir = worldPos - transform.position;
        // Calcular el ángulo de rotación en grados
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        // Limitar el ángulo máximo y mínimo
        angle = Mathf.Clamp(angle, minAngle, maxAngle);
        // Rotar el arco hacia el ángulo calculado
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
