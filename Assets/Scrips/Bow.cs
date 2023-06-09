using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public Vector2 Direction;
    public float force;

    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 bowPos = transform.position;

        Direction = MousePos - bowPos;

        faceMouse();

        /*
        for (int i = 0; i < numberOfPoints; i++)
        {
            Points[i].transform.position = PointPosition(i * 0.1f);
        }
         */
    }
    void faceMouse()
    {
        transform.right = Direction;
    }

    Vector2 PointPosition(float t)
    {
        Vector2 currentPointPos = (Vector2)transform.position + (Direction.normalized * force * t) + 0.5f * Physics2D.gravity * (t * t);

        return currentPointPos;
    }

    

}
