﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Grappin : MonoBehaviour
{

    public float compteur = 0;
    bool ok;
    [SerializeField]
    public Text text;


    [SerializeField]
    private KeyCode Key = KeyCode.G;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

    [SerializeField]
    private int maxDistance = 500;

    [SerializeField]
    private float speed = 50;

    [SerializeField]
    private Transform hand;

    [SerializeField]
    private LineRenderer LR;

    private Vector3 loc;
    private bool translate = false;
    private Rigidbody rb;

    private Collider collider;

    private void Start()
    {
        if (cam == null)
        {
            Debug.LogError("Grappin : No camera referenced");
            this.enabled = false;
        }
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    private void Update()
    {
        if ((Input.GetButtonDown("Jump") || Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical")) || (collider.gameObject.tag == "Ground") && translate)
        {
            translate = false;
            LR.enabled = false;
            rb.useGravity = true;
        }
        if (translate)
            Mouvement();

        Debug.Log(compteur + "A");

        if (Input.GetKeyDown(Key) && compteur <= 0)
        {
            Shoot();
            if (ok)
            {
                compteur = 15;
                ok = false;
            }
            //set le timer
            

        }
        compteur -= Time.deltaTime;

        if (compteur <= 0)
        {
            compteur = 0;
            Debug.Log(compteur + "C");
        }



    }

    private RaycastHit hit;

    private void Shoot()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, maxDistance, mask))
        {
            translate = true;
            loc = hit.point;
            LR.enabled = true;
            LR.SetPosition(1, loc);
            rb.useGravity = false;
            ok = true;
        }

    }

    private void Mouvement()
    {
        transform.position = Vector3.Lerp(transform.position, loc, speed * Time.deltaTime /*/ Vector3.Distance(transform.position, loc)*/);
        LR.SetPosition(0, hand.position);
        if (Vector3.Distance(transform.position, loc) < 2.5f)
        {
            translate = false;
            LR.enabled = false;
            rb.useGravity = true;
        }
    }
}