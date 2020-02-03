﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestItem : ItemClass
{
    [SerializeField] string Name, Description;
    [SerializeField] float AmountToRestore;
    PlayerMovement PM;
    FloatValue PlayerHpFloatValue;
    // Start is called before the first frame update
    void Start()
    {
        PM = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        ItemName = Name;
        ItemDescription = Description;
        PlayerHpFloatValue = PM.currentHealth;
        PlayerHpFloatValue.RuntimeValue -= 3;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void UseItem()
    {
        PlayerHpFloatValue.RuntimeValue += AmountToRestore;
        if (PlayerHpFloatValue.RuntimeValue > PlayerHpFloatValue.initialValue)
        {
            PlayerHpFloatValue.RuntimeValue = PlayerHpFloatValue.initialValue;
        }
    }
}