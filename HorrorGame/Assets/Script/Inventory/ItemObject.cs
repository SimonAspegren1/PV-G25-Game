﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Food,
    Medkit
}
public class ItemObject : MonoBehaviour
{
    public GameObject prefab;
    public ItemType Type;
    [TextArea(15, 20)]
    public string description;
}
