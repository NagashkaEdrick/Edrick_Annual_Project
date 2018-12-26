using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenu : MonoBehaviour
{

    //Variables
    public GameObject EscapeMenu;
    public GameObject uiPlayer;
    
    void Awake()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!EscapeMenu.activeInHierarchy)
        {

            if (Input.GetButtonDown("Escape"))
            {
                EscapeMenu.SetActive(true);
                uiPlayer.SetActive(false);
                Time.timeScale = 0;
            }

        }

        else if(EscapeMenu.activeInHierarchy)
        {

            if (Input.GetButtonDown("Escape") || Input.GetButtonDown("Cancel"))
            {
                EscapeMenu.SetActive(false);
                uiPlayer.SetActive(true);
                Time.timeScale = 1;
            }

        }
    }
}
