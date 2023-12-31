using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    int onOff = 0;
    bool isMute;
    GameObject on;
    void Start()
    {
        
        GameObject on = GameObject.Find("ON");
    }
    public void PlayGame()
    {

        SceneManager.LoadScene("Velder - Cloud City");
    }
    public void Options()
    {

        SceneManager.LoadScene("Option");
    }
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
    public void Fullscreen()
    {

        if (Screen.fullScreenMode == FullScreenMode.Windowed)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }
    

    public void Sound()
    {
        GameObject on = GameObject.Find("ON");
        if (onOff == 0)
        {
            on.GetComponent<TMPro.TextMeshProUGUI>().text = "On";
            onOff = 1;
        }
        else
        {
            on.GetComponent<TMPro.TextMeshProUGUI>().text = "Off";
            onOff = 0;
        }
        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;
    }
    public void Back()
    {

        SceneManager.LoadScene("Menu");
    }

}
