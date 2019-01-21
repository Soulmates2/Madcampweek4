using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRespone : MonoBehaviour
{
    private bool IsITItem = false;
    public GameObject[] Item;
    // Start is called before the first frame update
    void Start()
    {
        ItemMake();
    }

    // Update is called once per frame
    void Update()
    {
         
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (IsITItem)
        {
            IsITItem = false;
            Invoke("ItemMake", 10.0f);
        }
    }

    public void ItemMake()
    {
        if (!IsITItem)
        {
            IsITItem = true;
            var i = Instantiate(Item[Random.Range(0, Item.Length)], transform.position, Quaternion.Euler(0, 0, 45));
            i.transform.parent = transform;
        }
    }

}
