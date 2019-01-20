using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    private Rigidbody TireRigidBody;
    private Rigidbody PlayerRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        TireRigidBody = GetComponent<Rigidbody>();
        PlayerRigidBody = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            TireRigidBody.AddForce(-PlayerRigidBody.transform.forward);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            TireRigidBody.AddForce(PlayerRigidBody.transform.forward);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            TireRigidBody.transform.Rotate(0.0f, 0.0f, 1.0f, Space.Self);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            TireRigidBody.transform.Rotate(0.0f, 0.0f, -1.0f, Space.Self);
        }

    }
}
