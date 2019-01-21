using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftright : MonoBehaviour
{
    private int left = 0;
    // Update is called once per frame
    void Update()
    {
        if (left == 0)
        {
            transform.position += new Vector3(0, 0, 0.1f);
            if ((transform.position.z >= 335))
            {
               left = 1;
            }

        }

        if (left != 0)
        {
            transform.position -= new Vector3(0, 0, 0.1f);
            if ((transform.position.z <= 315))
            {
                left = 0;
            }
        }
        

    }
}
