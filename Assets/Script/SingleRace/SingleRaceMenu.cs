﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleRaceMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoMainMenu()
    {
        var CircuitRaceManager = GameObject.FindWithTag("CupRaceManager");
        Destroy(CircuitRaceManager);
        SceneManager.LoadScene("MainMenu");
    }
}
