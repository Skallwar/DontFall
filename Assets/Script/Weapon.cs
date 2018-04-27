﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Weapon : MonoBehaviour
{

    // Use this for initialization
    public int damage; //Store damage of the weapon
    public float coolDown;
    public Vector3 origin;
    public GameObject prefab;

    public virtual void Start()
    {
        //GameObject.Find("Game Manager").GetComponent<PhotonView>().ObservedComponents.Add(gameObject.transform);
    }

    public virtual void Fire()
    {
        
    }

    public virtual void OnTriggerStay(Collider collision)
    {
        
    }

    public void DesactivatePhysic()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    public void ActivatePhysic()
    {
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }

    public string PrefabName()
    {
        return prefab.name;
    }

    public virtual void ApplyDamage(GameObject gameObject)
    {
        gameObject.GetComponent<PhotonView>().RPC("TakeDamage", PhotonTargets.All, damage);   //Apply damage
    }
}
