using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlancoPrefab : MonoBehaviour
{
    public GameObject Blanco;
    public Transform zonaLimitada;
    public float tiempoLimite = 10f;
    public int puntosPorAcierto = 5;

    private float tiempoRestante;
    private GameObject BlancoActual;

    private void Start()
    {
        tiempoRestante = tiempoLimite;
        GenerarBlanco();
    }

    private void Update()
    {
        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 0f)
        {
            // El tiempo límite ha expirado, generar nuevo blanco
            GenerarBlanco();
        }

        if (Input.GetMouseButtonDown(0))
        {
            // Disparo de flecha
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject == BlancoActual)
                {
                    // Flecha ha acertado el blanco
                    Destroy(BlancoActual);
                    SumarPuntos(puntosPorAcierto);
                }

                // La flecha ha impactado en otro objeto (opcional: agregar lógica adicional)
                Destroy(hit.collider.gameObject);
            }
        }
    }

    private void GenerarBlanco()
    {
        if (BlancoActual != null)
        {
            // Destruir el blanco anterior si aún está presente
            Destroy(BlancoActual);
        }

        // Generar un nuevo blanco en una posición aleatoria dentro de la zona limitada
        Vector2 posicion = GetRandomPositionInZone();
        BlancoActual = Instantiate(Blanco, posicion, Quaternion.identity);

        // Reiniciar el tiempo restante
        tiempoRestante = tiempoLimite;
    }

    private Vector2 GetRandomPositionInZone()
    {
        Bounds zoneBounds = zonaLimitada.GetComponent<Renderer>().bounds;
        float randomX = Random.Range(zoneBounds.min.x, zoneBounds.max.x);
        float randomY = Random.Range(zoneBounds.min.y, zoneBounds.max.y);
        return new Vector2(randomX, randomY);
    }

    private void SumarPuntos(int cantidad)
    {
        // Agregar puntos al marcador (agrega tu propia lógica para manejar el marcador)
    }
}
