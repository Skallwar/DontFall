﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class CubeDeath : MonoBehaviour
{
    public GameObject Deathmenu;
    public Pausemenu pause;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PhotonView phV = other.GetComponent<PhotonView>();
            if (phV.isMine)
            {
                pause.enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                PhotonNetwork.Destroy(phV);
                Deathmenu.SetActive(true);
                
            }

        }
        else if(other.tag == "Bullet")
        {
            PhotonView phV = other.GetComponent<PhotonView>();
            if (phV.isMine)
                PhotonNetwork.Destroy(phV);
        }
    }
}
