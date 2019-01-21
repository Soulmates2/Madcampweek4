using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoStartPosition : MonoBehaviour
{
    public Transform StartPosition;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = StartPosition.position;
    }

}
