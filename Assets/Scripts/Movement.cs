using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);    
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }
}
