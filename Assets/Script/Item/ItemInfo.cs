using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    public TypeScript type;
    public GameObject item;
    string name;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            type = item.GetComponent<TypeScript>();
            type.SetTypeScript("item");
        }
        catch
        {

        }
    }
    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void SetName(string name)
    {
        this.name = name;
    }
}
