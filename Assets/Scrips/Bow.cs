using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject FlechaSprite;
    public Transform PuntoDeDisparo;
    public float fuerzaDeDisparo = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DispararFlecha();
        }
    }

    void DispararFlecha()
    {
        GameObject flecha = Instantiate(FlechaSprite, PuntoDeDisparo.position, PuntoDeDisparo.rotation);
        Rigidbody2D rb = flecha.GetComponent<Rigidbody2D>();
        rb.AddForce(PuntoDeDisparo.right * fuerzaDeDisparo, ForceMode2D.Impulse);
    }
}
