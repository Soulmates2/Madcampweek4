using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GoCircuitRace()
    {
        SceneManager.LoadScene("CircuitRaceMenu");
    }
    public void GoSingleRace()
    {
        SceneManager.LoadScene("SingleRaceMenu");
    }
    public void GoMultiRace()
    {
        SceneManager.LoadScene("MultiRaceMenu");
    }
    public void GoMakeCar()
    {
        SceneManager.LoadScene("MakeCar");
    }
    public void GoOption()
    {
        SceneManager.LoadScene("Option");
    }
    public void GoQuit()
    {
        Application.Quit();
    }
}
