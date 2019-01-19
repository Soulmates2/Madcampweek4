using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SingleCupChoice : MonoBehaviour
{
    public Image CarImage;
    public Image CupImage;

    public Sprite[] CarImageSet;
    public Sprite[] CupImageSet;

    public int CarKind = 0;
    public int CupKind = 0;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        CarImage.sprite = CarImageSet[CarKind];
        CupImage.sprite = CupImageSet[CupKind];
    }

    public void OnClickMapLeft()
    {
        CupKind--;
        if (CupKind < 0)
        {
            CupKind = CupImageSet.Length - 1;
        }
        CupImage.sprite = CupImageSet[CupKind];
    }

    public void OnClickMapRight()
    {
        CupKind++;
        if (CupKind > CupImageSet.Length - 1)
        {
            CupKind = 0;
        }
        CupImage.sprite = CupImageSet[CupKind];
    }

    public void OnClickCarLeft()
    {
        CarKind--;
        if (CarKind < 0)
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
        SceneManager.LoadScene("SingleRaceScene");
    }

}
