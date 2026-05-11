using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    private TextAsset jsonFile;
    private List<ItemData> itemDatas = new List<ItemData>();

    private TextAsset questJson;
    private List<QuestionData> QuestionDatas = new List<QuestionData>();
    void Awake()
    {
        Instance = this;

        jsonFile = Resources.Load<TextAsset>("jieshao");
        questJson = Resources.Load<TextAsset>("Question");

        if (jsonFile != null)
        {
            jieshao wrapper = JsonUtility.FromJson<jieshao>(jsonFile.text);
            itemDatas = wrapper.items;
        }
        if (questJson != null)
        {
            Question qJ = JsonUtility.FromJson<Question>(questJson.text);
            QuestionDatas = qJ.QuestionItem;
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

    public QuestionData QuestionDataID(int id)
    {
        int idx = id - 1;
        if (idx >= 0 && idx < QuestionDatas.Count)
        {
            return QuestionDatas[idx];
        }
        return null;
    }

}
