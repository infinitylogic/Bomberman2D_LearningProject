﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDrop : MonoBehaviour {

    [SerializeField] private GameObject bomb;
    private Vector2 pos;
    public static int cantidadBombas;
    [SerializeField] private int cantMaxBombas;
    private Collider2D[] hitColliders;
    private void Awake()
    {
        this.SetCantidadBombas();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && PuedeColocarBomba())
        {
            
            pos = this.transform.position;
            pos.x = Mathf.Round(pos.x);
            pos.y = Mathf.Round(pos.y);
            hitColliders = Physics2D.OverlapCircleAll(pos, 0.1f);
            if ((hitColliders.Length <= 1)) //You don't have someone with a collider here
            {
                cantidadBombas--;
                Instantiate(bomb, pos, Quaternion.identity);
            }
            
        }
	}

    bool PuedeColocarBomba()
    {
        return cantidadBombas > 0;
    }

    private void SetCantidadBombas()
    {
        cantidadBombas += cantMaxBombas;
        cantMaxBombas = 0;
    }
}