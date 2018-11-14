using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3_Leftkabe : MonoBehaviour {

    public GameObject Asiba;
    Color[] color = new Color[] { Color.red, Color.blue, Color.green };
    int colorNum = 0;

	// Use this for initialization
	void Start () {
        Asiba.GetComponent<Renderer>().material.color = Color.blue;
        gameObject.GetComponent<Renderer>().material.color = Color.green;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Isi")
        {
            gameObject.GetComponent<Renderer>().material.color = color[colorNum];
            colorNum++;
            if (colorNum >= 3)
                colorNum = 0;
        }
    }
}
