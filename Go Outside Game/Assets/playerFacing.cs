﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFacing : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {
      //  player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
    }
}
