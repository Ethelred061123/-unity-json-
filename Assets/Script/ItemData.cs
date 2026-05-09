using JetBrains.Annotations;
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
public class QuestionData
{
    public int Id;
    public string question;
    public string option1;
    public string option2;
    public string option3;
    public string option4;
    public int answer;
}


[Serializable]
public class jieshao
{
    public List<ItemData> items;
}

[Serializable]
public class Question
{
    public List<QuestionData> QuestionItem;
}
