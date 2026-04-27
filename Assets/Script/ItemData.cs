using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemData 
{
    public int image;
    public string title;
    public string description;
}

[Serializable]
public class jieshao
{
    public List<ItemData> items;
}
