using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title_Manager : MonoBehaviour {

    public static int select_stage = 1;
    public GameObject player;

    Vector3 player_pos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
		if(select_stage == 1)
        {
            player_pos = player.GetComponent<Transform>().position;
            player_pos = new Vector3(366, 569, 0);
            player.GetComponent<Transform>().position = player_pos;
        }
        else if (select_stage == 2)
        {
            player_pos = player.GetComponent<Transform>().position;
            player_pos = new Vector3(366, 237, 0);
            player.GetComponent<Transform>().position = player_pos;
        }
        else if (select_stage == 3)
        {
            player_pos = player.GetComponent<Transform>().position;
            player_pos = new Vector3(924, 569, 0);
            player.GetComponent<Transform>().position = player_pos;
        }
        else if (select_stage == 4)
        {
            player_pos = player.GetComponent<Transform>().position;
            player_pos = new Vector3(924, 237, 0);
            player.GetComponent<Transform>().position = player_pos;
        }
    }

    public void Stage1Button()
    {
        select_stage = 1; 
        SceneManager.LoadScene(1);
    }

    public void Stage2Button()
    {
        select_stage = 2;
        SceneManager.LoadScene(2);
    }

    public void Stage3Button()
    {
        select_stage = 3;
        SceneManager.LoadScene(3);
    }

    public void Stage4Button()
    {
        select_stage = 4;
        SceneManager.LoadScene(4);
    }
}
