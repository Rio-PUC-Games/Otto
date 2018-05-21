﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public GameObject Player;
    //[Tooltip("Se for -1 ele usará a distância atual da camera")]
    //public Vector3 distanciaPlayer = new Vector3(-1,-1,-1);

    private Vector3 _offset;
    internal static object main;

    // Use this for initialization
    void Start () {

        _offset = transform.position - Player.transform.position;

    }

    // Update is called once per frame
    void Update () {
        followPlayer();
	}

    private void followPlayer()
    {
        this.transform.position = Player.transform.position + _offset;
    }

}
