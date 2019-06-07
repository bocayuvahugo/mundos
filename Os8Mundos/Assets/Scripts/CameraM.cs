using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraM : MonoBehaviour
{
    public int currentWorld;
    float speed = 1;
    Vector3 mouseOldPosition;
    void Start()
    {
        if (currentWorld <= 3)
        {
            this.transform.Rotate(23, -190, 0);
            this.transform.position = new Vector3(-15, 28, 50);
        }
        else
        {
            this.transform.position = new Vector3(-3, 3, 9);
            this.transform.Rotate(0, -190, 0);
        }
    }
    void Update()
    {
        if (currentWorld >= 4)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(0, 0, +speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(0, 0, -speed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-speed, 0, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(+speed, 0, 0);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Translate(0, +speed, 0);
            }
            if (Input.GetKey(KeyCode.E))
            {
                transform.Translate(0, -speed, 0);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Rotate(transform.rotation.x - 2, 0, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Rotate(transform.rotation.x + 2, 0, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0, transform.rotation.y - 2, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0, transform.rotation.y + 2, 0);
            }
        }

    }
}
