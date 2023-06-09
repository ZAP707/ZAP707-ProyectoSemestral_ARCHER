using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool hasHit = false;

    // Referencia al objeto colisionado
    private Transform collidedObject;

    // Referencia al Rigidbody2D del objeto colisionado
    private Rigidbody2D collidedObjectRb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasHit)
        {
            // Si la flecha ha impactado con un objeto, seguimos su posición
            transform.position = collidedObject.position;
        }
    }

    void FixedUpdate()
    {
        if (!hasHit)
        {
            // Si la flecha no ha impactado, seguimos el movimiento
            TrackMovement();
        }
    }

    void TrackMovement()
    {
        Vector2 direction = rb.velocity;
        if (direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!hasHit)
        {
            // Si la flecha ha impactado, almacenamos la información del objeto colisionado
            hasHit = true;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.isKinematic = true;

            collidedObject = col.transform;
            collidedObjectRb = col.gameObject.GetComponent<Rigidbody2D>();

            // Hacemos que la flecha sea hija del objeto colisionado
            transform.SetParent(collidedObject);

            // Desactivamos el collider de la flecha para evitar interacciones adicionales
            GetComponent<Collider2D>().enabled = false;

            // Desactivamos el Rigidbody2D de la flecha para evitar comportamiento físico no deseado
            rb.simulated = false;

            // Cambiamos la gravedad del objeto colisionado para que la flecha se mantenga en su lugar
            if (collidedObjectRb != null)
            {
                collidedObjectRb.gravityScale = 0f;
            }
        }
    }
}






//Script original
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    Rigidbody2D rb;

    bool hasHit = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
     
        if (hasHit == false)
        { 
         trackMovement();
        }
    }

    void trackMovement()
    {
        Vector2 direcction = rb.velocity;

        float angle = Mathf.Atan2(direcction.y, direcction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        hasHit = true;
        
       // rb.velocity = Vector2.zero;
       // rb.isKinematic = true;
         
    }
}
 */
