using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroductionScreen : MonoBehaviour
{
    public AudioSource audioSource;
    public TMP_Text dialogText;
    public void StartIntro()
    {
        audioSource = this.GetComponent<AudioSource>();
        StartCoroutine(StartIntroduction());
    }

    IEnumerator StartIntroduction()
    {
        yield return new WaitForSeconds(18);
        SceneManager.LoadScene("Ruben - Starting Village");
    }
}
