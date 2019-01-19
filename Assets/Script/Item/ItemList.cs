using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList
{
    private static string [] list_of_item = { "none", "Image/MulitiGamePlay/MultiGamePlay" };
    // Start is called before the first frame update    
    public static string GetItemName(int i)
    {
        return list_of_item[i];
    }
}
