using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Velocidad inicial de la flecha
    public float velocidad = 10f;

    // Ángulo de lanzamiento de la flecha
    public float angulo = 45f;

    // Gravedad que se aplicará a la flecha
    public float gravedad = 9.8f;

    // Rigidbody2D de la flecha
    private Rigidbody2D rigidbody2D;

    // Vector de velocidad inicial de la flecha
    private Vector2 velocidadInicial;

    // Inicialización
    private void Start()
    {
        // Obtiene el Rigidbody2D de la flecha
        rigidbody2D = GetComponent<Rigidbody2D>();

        // Calcula el vector de velocidad inicial
        velocidadInicial = new Vector2(velocidad * Mathf.Cos(angulo), velocidad * Mathf.Sin(angulo));

        // Desactiva la gravedad para que la aplique el script
        rigidbody2D.gravityScale = 0f;
    }

    // Actualización
   /*
    private void Update()
    {
        // Aplica la gravedad manualmente
        rigidbody2D.AddForce(new Vector2(0, -gravedad));

        // Actualiza la posición de la flecha en función de la velocidad y el tiempo transcurrido
        transform.position += velocidadInicial * Time.deltaTime;
    }
    */

    // Detección de colisiones
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Aquí puedes agregar la lógica para manejar la colisión de la flecha con otros objetos
    }
}
