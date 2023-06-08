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
