using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Asiba : MonoBehaviour {

    public GameObject Instpos;
    public GameObject Iron;
    GameObject instIron;

    Vector3 instpos;

    float deltime;
    bool one = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(instIron != null)
        {
            deltime += Time.deltaTime;
            if (deltime >= 3)
                Destroy(instIron);
        }
	}


    private void OnCollisionEnter2D(Collision2D col)
    {
        if((col.gameObject.tag == ("Player")) && (one == false))
        {
            instpos = Instpos.GetComponent<Transform>().position;
            instIron = Instantiate(Iron, instpos, Quaternion.identity);
            one = true;

        }
    }
}
