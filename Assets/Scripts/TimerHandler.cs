using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class TimerHandler : MonoBehaviour
{
    public TMP_Text lobbyStatus;
    public PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            photonView.RPC("lobbyStatusUpdate",RpcTarget.All);
        }    
    }

    [PunRPC]
    public void lobbyStatusUpdate()//int number, PhotonMessageInfo info) 
    { 
        StartCoroutine("timer");        
    }

    public IEnumerator timer()
    {
        lobbyStatus.text = "5";
        yield return new WaitForSeconds(1f);
        lobbyStatus.text = "4";
        yield return new WaitForSeconds(1f);
        lobbyStatus.text = "3";
        yield return new WaitForSeconds(1f);
        lobbyStatus.text = "2";
        yield return new WaitForSeconds(1f);
        lobbyStatus.text = "1";
    }
}
