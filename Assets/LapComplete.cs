using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour
{
    public GameObject LapCompleteTrig;
    public GameObject HalfLapTrig;

    public GameObject MinuteDisplay;
    public GameObject SecondDisplay;
    public GameObject MilliDisplay;

    public GameObject LapTimeBox;

    private void OnTriggerEnter(Collider other)
    {
        if(LapNowTime.SecondCount <= 9)
        {
            SecondDisplay.GetComponent<Text>().text = "0" + LapNowTime.SecondCount + ".";
        } else
        {
            SecondDisplay.GetComponent<Text>().text = "" + LapNowTime.SecondCount + ".";
        }

        if(LapNowTime.MinuteCount <= 9)
        {
            MinuteDisplay.GetComponent<Text>().text = "0" + LapNowTime.MinuteCount + ".";
        } else
        {
            MinuteDisplay.GetComponent<Text>().text = "" + LapNowTime.MinuteCount + ".";
        }

        MilliDisplay.GetComponent<Text>().text = "" + LapNowTime.MilliCount;

        LapNowTime.MinuteCount = 0;
        LapNowTime.SecondCount = 0;
        LapNowTime.MilliCount = 0;

        HalfLapTrig.SetActive(true);
        LapCompleteTrig.SetActive(false);

    }

}
