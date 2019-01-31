using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenu : MonoBehaviour
{

    //Variables
    public GameObject escapeMenu;
    public GameObject recommencer;
    
    void Awake()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!escapeMenu.activeInHierarchy)
        {

            if (Input.GetButtonDown("Cancel"))
            {
                escapeMenu.SetActive(true);
                Time.timeScale = 0;
            }

        }

        else if(escapeMenu.activeInHierarchy && !recommencer.activeInHierarchy)
        {

            if (Input.GetButtonDown("Cancel"))
            {
                recommencer.SetActive(false);
                escapeMenu.SetActive(false);
                Time.timeScale = 1;
            }

        }
    }
}
