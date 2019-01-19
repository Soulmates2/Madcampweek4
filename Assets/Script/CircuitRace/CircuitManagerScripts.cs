using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CircuitManagerScripts : MonoBehaviour
{
    public Image CarImage;
    public Image MapImage;

    public Sprite[] CarImageSet;
    public Sprite[] MapImageSet;

    public int CarKind = 0;
    public int MapKind = 0;

    private void Start()
    {
        DontDestroyOnLoad(this);
        CarImage.sprite = CarImageSet[CarKind];
        MapImage.sprite = MapImageSet[MapKind];
    }


    public void OnClickMapLeft()
    {
        MapKind--;
        if (MapKind < 0)
        {
            MapKind = MapImageSet.Length - 1;
        }
        MapImage.sprite = MapImageSet[MapKind];
    }

    public void OnClickMapRight()
    {
        MapKind++;
        if (MapKind > MapImageSet.Length - 1)
        {
            MapKind = 0;
        }
        MapImage.sprite = MapImageSet[MapKind];
    }

    public void OnClickCarLeft()
    {
        CarKind--;
        if(CarKind < 0)
        {
            CarKind = CarImageSet.Length - 1;
        }
        CarImage.sprite = CarImageSet[CarKind];
    }

    public void OnClickCarRight()
    {
        CarKind++;
        if (CarKind > CarImageSet.Length - 1)
        {
            CarKind = 0;
        }
        CarImage.sprite = CarImageSet[CarKind];
    }

    public void OnClickStart()
    {
        SceneManager.LoadScene("CircuitRaceScene");
    }


}
