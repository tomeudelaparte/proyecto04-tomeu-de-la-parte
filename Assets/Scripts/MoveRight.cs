using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    private float xRange = 10;
    private float speed = 5;

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if(transform.position.x >= xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, 0);
            speed *= -1;
        }

        if (transform.position.x <= -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, 0);
            speed *= -1;
        }
    }
}
