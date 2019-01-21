using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearRace : MonoBehaviour
{
    public GameObject WinText;

    private void OnTriggerEnter(Collider other)
    {
        WinText.SetActive(true);
        Invoke("GoMainMenu", 10.0f);
    }

    void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
 
}
