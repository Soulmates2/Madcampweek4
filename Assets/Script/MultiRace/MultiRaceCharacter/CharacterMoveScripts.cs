using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CharacterMoveScripts : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasAuthority)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(new Vector3(0, -Time.deltaTime * 40.0f, 0));
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(new Vector3(0, Time.deltaTime * 40.0f, 0));
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += (transform.forward) * 0.5f;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position -= (transform.forward) * 0.5f;
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += (transform.up) * 0.5f;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= (transform.up) * 0.5f;
            }
        }
    }
}
