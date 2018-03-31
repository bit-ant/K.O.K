using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;

    public int turn = 5;

    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow) && (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow)))
        {
            transform.Rotate(Vector3.forward * speed * turn * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow)))
        {
            transform.Rotate(Vector3.back * speed * turn * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, -1, 0) * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
        }
    }
}
