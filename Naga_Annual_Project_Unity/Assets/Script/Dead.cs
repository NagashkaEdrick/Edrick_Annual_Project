using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour {

    private GameObject repop;
    private GameObject player;
    private Animator anim;
    private float fallTime = 0.5f;


	// Use this for initialization
	void Start () {
        repop = GameObject.FindGameObjectWithTag("Respawn");
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();
    }
	

	private void OnTriggerEnter2D(Collider2D deadzone)
    {
		if(deadzone.gameObject.tag == "Player")
        {
            anim.SetTrigger("Hurt");
            StartCoroutine(Deadfall());
        }
	}

    IEnumerator Deadfall()
    {
        yield return new WaitForSeconds(fallTime);

        player.transform.position = repop.transform.position;
    }


}
