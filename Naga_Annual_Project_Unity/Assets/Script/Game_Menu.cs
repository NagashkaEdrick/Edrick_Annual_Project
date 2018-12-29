using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Game_Menu : MonoBehaviour
{

    //Variables
    public int menu;
    public int option;
    public int currentScene;
    private GameObject repop;
    private GameObject player;
    public GameObject menuRecommencer;

    //Pour selection en couleur des boutons
    public EventSystem eS;
    private GameObject storeSelected;
    [SerializeField]
    private GameObject premierChoix;
    [SerializeField]
    private GameObject nonButton;

    // Use this for initialization
    void Start()
    {
        storeSelected = premierChoix;
    }

    void Update()
    {
        if (eS.currentSelectedGameObject != storeSelected)
        {
            if (eS.currentSelectedGameObject == null)
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

        if (Input.GetButtonDown("Cancel") && menuRecommencer.activeInHierarchy)
        {
            menuRecommencer.SetActive(false);
            eS.SetSelectedGameObject(premierChoix);
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene(menu);
    }

    public void Option()
    {
        SceneManager.LoadScene(option);
    }

    public void Return()
    {
        repop = GameObject.FindGameObjectWithTag("Respawn");
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = repop.transform.position;
    }

    public void Reload()
    {
        menuRecommencer.SetActive(true);
        eS.SetSelectedGameObject(nonButton);
    }

    public void ReloadYes()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void ReloadNo()
    {
        menuRecommencer.SetActive(false);
        eS.SetSelectedGameObject(premierChoix);
    }
}