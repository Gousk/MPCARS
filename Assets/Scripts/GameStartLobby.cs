using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;

public class GameStartLobby : MonoBehaviour
{
    public TMP_Text player1Status;
    //public TMP_Text player2Status;
    public PhotonView photonView1;
    //public PhotonView photonView2;

    void Start() 
    {
        player1Status.text = "Not Ready";
        //player2Status.text = "Not Ready";    
    }

    void Update()
    {
        int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;

        if (playerCount == 1)
        {
            photonView1.RPC("player1UpdateText",RpcTarget.All);
        } 
        // else if (playerCount == 2) 
        // {
        //     photonView2.RPC("player2UpdateText",RpcTarget.All);    
        // }  
    }

    [PunRPC]
    public void player1UpdateText()//int number, PhotonMessageInfo info) 
    { 
        player1Status.text = "   Ready";
        player1Status.color = new Color(0, 255, 0, 255);
    }
    // [PunRPC]
    // public void player2UpdateText()//int number, PhotonMessageInfo info) 
    // { 
    //     player2Status.text = "Ready";
    //     player2Status.color = new Color(0, 255, 0, 255);
    // }
}
