using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CharacterMoveScripts : NetworkBehaviour
{
    public Camera PlayerCamera;
    public Vector3 speed;
    float aaaa;
    public Rigidbody PlayerRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        RpcCameraOff();
    }

    [ClientRpc]
    void RpcCameraOff()
    {
        if (!hasAuthority)
        {
            PlayerCamera.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hasAuthority)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(new Vector3(0, -Time.deltaTime * 80.0f, 0));
            }


            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(new Vector3(0, Time.deltaTime * 80.0f, 0));
            }


            if (Input.GetKey(KeyCode.UpArrow))
            {
                Debug.Log("aaaa");
                if (aaaa <= 0.5f)
                {
                    Debug.Log("aaaa");
                    aaaa += 0.003f;
                    transform.position += (transform.forward) * aaaa;
                    //speed += new Vector3(0, 0, 0.1f);
                    //PlayerRigidBody.velocity = speed;
                    //PlayerRigidBody.AddForce(0, 0, 80f * Time.deltaTime);
                    //transform.GetComponent<Rigidbody>().AddForce(0,0, 80f * Time.deltaTime);
                    Debug.Log("aaaa");
                }
                else
                {
                    transform.position += (transform.forward) * aaaa;
                }
            }
            else
            {
                if (aaaa > 0)
                {
                    aaaa -= 0.003f;
                    transform.position += (transform.forward) * aaaa;
                }
            }


            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position -= (transform.forward) * 0.25f;
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
