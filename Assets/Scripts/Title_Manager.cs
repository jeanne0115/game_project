using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title_Manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Stage1Button()
    {
        SceneManager.LoadScene(1);
    }

    public void Stage2Button()
    {
        SceneManager.LoadScene(2);
    }

    public void Stage3Button()
    {
        SceneManager.LoadScene(3);
    }

    public void Stage4Button()
    {
        SceneManager.LoadScene(4);
    }
}
