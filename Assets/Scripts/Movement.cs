using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 15f;
    float valueX;
    float valueZ;
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            if (transform.gameObject.tag == "Player1")
            {
                valueX = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
                valueZ = Input.GetAxis("Horizontal") * Time.deltaTime * -moveSpeed;
            }
            else if (transform.gameObject.tag == "Player2")
            {
                valueX = Input.GetAxis("Vertical") * Time.deltaTime * -moveSpeed;
                valueZ = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed; 
            }

            transform.Translate(valueX,0,valueZ);
        }
    }
}
