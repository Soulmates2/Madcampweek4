using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            var CircuitRaceManager = GameObject.FindWithTag("CircuitRaceManager");
            if(CircuitRaceManager != null)
            {
                Destroy(CircuitRaceManager);
            }
            var CupRaceManager = GameObject.FindWithTag("CupRaceManager");
            if(CupRaceManager != null)
            {
                Destroy(CircuitRaceManager);
            }
            MenuBackGroundMusicScript a = MenuBackGroundMusicScript.instance;
            a.menu = true;
            a.RandomPlay();
            SceneManager.LoadScene("MainMenu");
        }   
    }
}
