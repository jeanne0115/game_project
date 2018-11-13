using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Asiba : MonoBehaviour {

    public GameObject Instpos;
    public GameObject Iron;

    Vector3 instpos;

    float deltime;
    bool one = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnCollisionEnter2D(Collision2D col)
    {
        if((col.gameObject.tag == ("Player")) && (one == false))
        {
            instpos = Instpos.GetComponent<Transform>().position;
            Instantiate(Iron, instpos, Quaternion.identity);
            one = true;

        }
    }
}
