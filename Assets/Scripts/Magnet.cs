﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour{
    private PlayerController player;
    private void Start()
    {
        player = PlayerController.instance;
    }
}
