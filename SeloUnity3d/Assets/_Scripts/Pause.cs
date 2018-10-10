using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    //public GameObject menu;
    //AudioSource audio;

    void Start()
    {
        //audio = GetComponent<AudioSource>();
    }

    void Awake()
    {
        //menu.gameObject.SetActive(false);
    }

    void Update()
    {


        /* if ((CrossPlatformInputManager.GetButtonDown("Cancel"))==true)
         {
             if (menu.gameObject.activeInHierarchy == false)
             {
                 menu.gameObject.SetActive(true);
                 Time.timeScale = 0;
                 audio.Pause();
             }
             else
             {
                 menu.gameObject.SetActive(false);
                 Time.timeScale = 1;
                 audio.Play();
             } */

        if ((CrossPlatformInputManager.GetButtonDown("Cancel")) == true) { Time.timeScale = 1; SceneManager.LoadScene("MainScene"); }

        }
    }

