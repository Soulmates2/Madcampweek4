using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class downup : MonoBehaviour
{
    private int up = 1;
    // Update is called once per frame
    void Update()
    {
        if (up == 0)
        {
            transform.position += new Vector3(0, 0.1f, 0);
            if ((transform.position.y >= 5))
            {
                up = 1;
            }

        }

        if (up != 0)
        {
            transform.position -= new Vector3(0, 0.1f, 0);
            if ((transform.position.y <= -20))
            {
                up = 0;
            }
        }


        //if (transform.position.y < 5 && transform.position.y > -15)
        //{
        //    transform.position -= new Vector3(0, 0.1f, 0);
        //}
        //if (transform.position.y > -15 && transform.position.y < 5)
        //{
        //    transform.position += new Vector3(0, 0.2f, 0);
        //}


    }
}
