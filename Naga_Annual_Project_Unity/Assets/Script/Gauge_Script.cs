using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class Gauge_Script : MonoBehaviour
{

    //Variables
    Image gaugeLP;

    private float percentLife;

	// Use this for initialization
	void Start ()
    {
		gaugeLP = this.GetComponent<Image>();
        percentLife = 1F;
    }
	
	// Update is called once per frame
	void Update ()
    {
        percentLife = GameObject.Find("Player").GetComponent<Foxy_Life>().percentLife;
        gaugeLP.fillAmount = percentLife;
	}
}
