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

    private void Start() 
    {
        Vector3 spawnPos1 = playerSpawn1.position;
        Vector3 spawnPos2 = playerSpawn2.position;

        if (PhotonNetwork.IsMasterClient)
        {
            GameObject player1 = PhotonNetwork.Instantiate(player1Prefab.name, spawnPos1, Quaternion.identity);
            player1.GetComponent<CarController>().enabled = false;
            player1.transform.Rotate(0, 90, 0);
        }
        else
        {
            GameObject player2 = PhotonNetwork.Instantiate(player2Prefab.name, spawnPos2, Quaternion.identity);
            player2.GetComponent<CarController>().enabled = false;
            player2.transform.Rotate(0, -90, 0);
        }         
    }
}
