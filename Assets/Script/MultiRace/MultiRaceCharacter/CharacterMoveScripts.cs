using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


[NetworkSettings(sendInterval = 0.016f)]
public class CharacterMoveScripts : NetworkBehaviour
{
    public Camera PlayerCamera;
    public Vector3 speed;
    float Accel;
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
    void LateUpdate()
    {
        if (hasAuthority)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(new Vector3(0, -Time.deltaTime * 80.0f, 0) * Accel);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(new Vector3(0, Time.deltaTime * 80.0f, 0) * Accel);
            }


            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (Accel <= 0.5f)
                {
                    Accel += 0.003f;
                    transform.position += (transform.forward) * Accel;
                    //speed += new Vector3(0, 0, 0.1f);
                    //PlayerRigidBody.velocity = speed;
                    //PlayerRigidBody.AddForce(0, 0, 80f * Time.deltaTime);
                    //transform.GetComponent<Rigidbody>().AddForce(0,0, 80f * Time.deltaTime);
                }
                else
                {
                    transform.position += (transform.forward) * Accel;
                }
            }
            else
            {
                if (Accel > 0)
                {
                    Accel -= 0.003f;
                    transform.position += (transform.forward) * Accel;
                }
            }


            if (Input.GetKey(KeyCode.DownArrow))
            {
                if(Accel > 0f)
                {
                    Accel -= 0.001f;
                    
                }
                else if (Accel < 0f && Accel >= -0.3f)
                {
                    Accel -= 0.001f;
                    transform.position += (transform.forward) * Accel;
                }                    
            }
            else
            {
                if (Accel < 0)
                {
                    Accel += 0.001f;
                    transform.position += (transform.forward) * Accel;
                }
            }

        }
    }
}
