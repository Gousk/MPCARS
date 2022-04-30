using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;

public class GameStartLobby1 : MonoBehaviour
{
    public Canvas canvas;
    public TMP_Text player1Status;
    public TMP_Text player2Status;
    //public PhotonView photonView1;
    public PhotonView photonView2;
    GameObject Player1;
    GameObject Player2;
    public bool gameStarted = false;

    void Start() 
    {
        //player1Status.text = "Not Ready";
        player2Status.text = "Not Ready";    
    }

    void Update()
    {
        int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;

        // if (playerCount == 1)
        // {
        //     photonView1.RPC("player1UpdateText",RpcTarget.All);
        // } 
        if (playerCount == 2) 
        {
            photonView2.RPC("player2UpdateText",RpcTarget.All);
               
        }

        if (playerCount == 2)
        { 
            Invoke("StartGame", 5f);
        }  
    }

    // [PunRPC]
    // public void player1UpdateText()//int number, PhotonMessageInfo info) 
    // { 
    //     player1Status.text = "Ready";
    //     player1Status.color = new Color(0, 255, 0, 255);
    // }
    [PunRPC]
    public void player2UpdateText()//int number, PhotonMessageInfo info) 
    { 
        player2Status.text = "   Ready";
        player2Status.color = new Color(0, 255, 0, 255);
    }

    void StartGame()
    {
        Player1 = GameObject.FindGameObjectWithTag("Fire");
        Player2 = GameObject.FindGameObjectWithTag("Car");
        Player1.GetComponent<CarController>().enabled = true;
        Player2.GetComponent<CarController>().enabled = true;
        canvas.enabled = false;  
    }
}
