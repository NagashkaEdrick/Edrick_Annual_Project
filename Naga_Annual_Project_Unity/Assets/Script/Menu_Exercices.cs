using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Menu_Exercices : MonoBehaviour
{

    //Variables
    public string retour;
    public string ex01;
    public string ex02;
    public string ex03;

    //Pour selection en couleur des boutons
    public EventSystem eS;
    private GameObject storeSelected;
    [SerializeField]
    private GameObject premierChoix;

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

    }

    public void Retour()
    {
        SceneManager.LoadScene(retour);
    }

    public void Ex01()
    {
        SceneManager.LoadScene(ex01);
    }

    public void Ex02()
    {
        SceneManager.LoadScene(ex02);
    }

    public void Ex03()
    {
        SceneManager.LoadScene(ex03);
    }

}