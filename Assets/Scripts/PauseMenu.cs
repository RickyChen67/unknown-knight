using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    int onOff = 0;
    bool isMute;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject OptionsMenu;
    [SerializeField] GameObject InventoryMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool isActive = pauseMenu.activeSelf;
            if (isActive)
                Time.timeScale = 1f;
            else
                Time.timeScale = 0f;

            pauseMenu.SetActive(!isActive);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            bool isActive = InventoryMenu.activeSelf;
            if (isActive)
                Time.timeScale = 1f;
            else
                Time.timeScale = 0f;

            InventoryMenu.SetActive(!isActive);
        }

    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Inventory()
    {
        InventoryMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Time.timeScale = 1f;
        Debug.Log("Quit!");
        Application.Quit();
    }
    public void Options()
    {
        OptionsMenu.SetActive(true);
        pauseMenu.SetActive(false);
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
    public void BackOptions()
    {

        OptionsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void BackInventory()
    {

        InventoryMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}

