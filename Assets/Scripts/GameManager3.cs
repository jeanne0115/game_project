using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager3 : MonoBehaviour
{

    public GameObject Player;
    public GameObject kuriaText;
    public GameObject SubCamera;
    public GameObject TitleButton;
    public GameObject RetryButton;
    public GameObject IsiButton;

    public GameObject RightButton;
    public GameObject LeftButton;
    public GameObject RightAsiba;
    public GameObject LeftAsiba;
    public GameObject Die_Kanban;
    public GameObject Safe_Kanban;

    public bool endFlg = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (endFlg == true)
                SceneManager.LoadScene(0);
        }

        if((LeftButton.GetComponent<Renderer>().material.color == LeftAsiba.GetComponent<Renderer>().material.color)
            &&(RightButton.GetComponent<Renderer>().material.color == RightAsiba.GetComponent<Renderer>().material.color))
        {
            Die_Kanban.SetActive(false);
            Safe_Kanban.SetActive(true);
        }
        else
        {
            Die_Kanban.SetActive(true);
            Safe_Kanban.SetActive(false);
        }
    }


    public void PushButtonTouseki()
    {
        Player.GetComponent<Player_Controller>().Touseki();
    }

    public void PushTitle()
    {
        SceneManager.LoadScene(0);
    }

    public void PushReTry()
    {
        SceneManager.LoadScene(3);
    }


    public void Kuria()
    {
        endFlg = true;
        SubCamera.SetActive(true);
        Destroy(Player);
        kuriaText.SetActive(true);
        IsiButton.SetActive(false);
    }

    public void Die()
    {
        SubCamera.SetActive(true);
        Destroy(Player);
        IsiButton.SetActive(false);
        RetryButton.SetActive(true);
        TitleButton.SetActive(true);

    }
}
