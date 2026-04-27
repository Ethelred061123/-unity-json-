using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    private TextAsset jsonFile;
    private List<ItemData> itemDatas = new List<ItemData>();
    void Awake()
    {
        Instance = this;

        jsonFile = Resources.Load<TextAsset>("jieshao");

        if (jsonFile != null)
        {
            jieshao wrapper = JsonUtility.FromJson<jieshao>(jsonFile.text);
            itemDatas = wrapper.items;
        }
    }

    public ItemData GetItemID(int id)
    {
        int idx = id - 1;
        if (idx >= 0 && idx < itemDatas.Count)
        { 
            return itemDatas[idx];
        }
        return null;
    }

}
