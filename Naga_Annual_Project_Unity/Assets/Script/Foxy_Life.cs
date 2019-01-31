using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Foxy_Life : MonoBehaviour
{

    //Varriables
    [HideInInspector]
    public float percentLife;
    private int basicLifePoints = 100;
    //[SerializeField]
    private float currentLife;

	// Use this for initialization
	void Start ()
    {
        currentLife = basicLifePoints;
	}
	
	// Update is called once per frame
	void Update ()
    {
        percentLife = currentLife / basicLifePoints;

        if (currentLife <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }
}
