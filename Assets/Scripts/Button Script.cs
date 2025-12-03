using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ButtonScript : MonoBehaviour
{
    //public variable to reference the button text - set this up in the Unity editor
    public TMP_Text buttonText;
    //AudioSource audioSource;
    //public AudioClip sfx1;  // sound effect asset from sfx folder

    

    public void ButtonMethod()
    {
        buttonText.text = "Clicked!";

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("The button is working.");

        FindFirstObjectByType<AudioManager>().Play("Edited floop");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadSceneByName()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadNextInBuild()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /*
    void PlaySoundEffect()
    {
        audioSource.PlayOneShot(sfx1, 0.7f); // play audio clip with volume 0.7
    }
    */

    public void GoToFrontend()
    {
        SceneManager.LoadScene("Frontend");
    }

    public void GoToLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void GoToLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }

}
