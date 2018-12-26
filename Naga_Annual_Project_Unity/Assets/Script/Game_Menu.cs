using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameMenu : MonoBehaviour
{

    //Variables
    public int menu;
    public int option;
    public int currentScene;
    private GameObject repop;
    private GameObject player;

    //Pour selection en couleur des boutons
    public EventSystem eS;
    private GameObject storeSelected;


    // Use this for initialization
    void Start()
    {
        storeSelected = eS.firstSelectedGameObject;
    }

    void Update()
    {
        if(eS.currentSelectedGameObject != storeSelected)
        {
            if(eS.currentSelectedGameObject == null)
            {
                eS.SetSelectedGameObject(storeSelected);
            }

            else
            {
                storeSelected = eS.currentSelectedGameObject;
            }
        }

        else
        {
            storeSelected = eS.firstSelectedGameObject;
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene(menu);
    }

    public void Option ()
    {
        SceneManager.LoadScene(option);
    }

    public void Reload()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void Quit()
    {
        Debug.Log("Le jeu se ferme");
        Application.Quit();
    }

    public void Return()
    {
        repop = GameObject.FindGameObjectWithTag("Respawn");
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = repop.transform.position;
    }

}
