using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monkeysmove : MonoBehaviour
{
    private int left = 0;
    // Update is called once per frame
    void Update()
    {
        if (left == 0)
        {
            transform.position += new Vector3(0.2f, 0, 0);
            if (transform.position.x >= 413)
            {
                left = 1;
            }

        }

        if (left != 0)
        {
            transform.position -= new Vector3(0.2f, 0, 0);
            if (transform.position.x <= 367)
            {
                left = 0;
            }
        }


    }
}
