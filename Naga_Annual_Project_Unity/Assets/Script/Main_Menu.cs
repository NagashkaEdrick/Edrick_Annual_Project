using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    //Variables
    [SerializeField]
    private int play = 1;
    [SerializeField]
    private int exercices = 2;

    public EventSystem eS;
    private GameObject storeSelected;


    // Use this for initialization
    void Start()
    {
        storeSelected = eS.firstSelectedGameObject;
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

    public void Play()
    {
        SceneManager.LoadScene(play);
    }

    public void Exercices()
    {
        SceneManager.LoadScene(exercices);
    }

    public void Quit()
    {
        Debug.Log("Le jeu se ferme");
        Application.Quit();
    }

}
