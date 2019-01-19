using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class CircuitRaceTimeCheck : MonoBehaviour
{
    public Text NowLap; // 몇바퀴째인지
    public Text CurrentLapTime; // 나머지는 시간...
    public Text LastLapTime;
    public Text BestLapTime;
    bool Is_MyCharacter;

    private Stopwatch sw;

    // Start is called before the first frame update
    void Start()
    {
        NowLap = GameObject.FindWithTag("NowLap").GetComponent<Text>();
        CurrentLapTime = GameObject.FindWithTag("CurrentLapTime").GetComponent<Text>();
        LastLapTime = GameObject.FindWithTag("LastLapTime").GetComponent<Text>();
        BestLapTime = GameObject.FindWithTag("BestLapTime").GetComponent<Text>();
        sw = new Stopwatch();
        sw.Start();
    }

    // Update is called once per frame
    void Update()
    {
        NowLap.text = "Now Lap : " + (sw.ElapsedMilliseconds/1000).ToString() + "s";
    }
}
