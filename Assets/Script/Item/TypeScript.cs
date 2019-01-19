using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeScript : MonoBehaviour
{
    public string type;
    public bool isPlayer = false;
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTypeScript(string str)
    {
        type = str;
        if (str.Equals("others") || str.Equals("player"))
        {
            isPlayer = true;
        }

    }
    public string GetTypeScript()
    {
        return type;
    }
    public bool IsPlayer()
    {
        return isPlayer;
    }
}
