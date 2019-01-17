using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenuScript : MonoBehaviour
{
    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
