using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject player1Prefab;
    public GameObject player2Prefab;
    public Transform playerSpawn1;
    public Transform playerSpawn2;
    GameObject player1;
    GameObject player2;

    private void Start() 
    {
        Vector3 spawnPos1 = playerSpawn1.position;
        Vector3 spawnPos2 = playerSpawn2.position;

        if (PhotonNetwork.IsMasterClient)
        {
            player1 = PhotonNetwork.Instantiate(player1Prefab.name, spawnPos1, Quaternion.identity) as GameObject;
            player1.GetComponent<Movement>().enabled = false;
        }
        else
        {
            player2 = PhotonNetwork.Instantiate(player2Prefab.name, spawnPos2, Quaternion.identity) as GameObject;
            player2.GetComponent<Movement>().enabled = false;
        }         
    }
}
