using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThis : MonoBehaviour
{
    public float DestroyTime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyThisObject", DestroyTime);
    }
       
    public void DestroyThisObject()
    {
        Destroy(gameObject);
    }
}

    
