using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveneddle : MonoBehaviour
{

    public GameObject neddle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            neddle.transform.Rotate(0.0f, 0.0f, -0.5f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            neddle.transform.Rotate(0.0f, 0.0f, 0.5f);
        }
    }
}
