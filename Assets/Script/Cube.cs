using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public int id;
    private bool isCillision = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (!isCillision)
        {
            QuestionData Qdata = DataManager.Instance.QuestionDataID(id);
            UIQuest.Instance.UIquest.SetActive(true);
            UIQuest.Instance.ShowUIQuestion(Qdata);

            isCillision = true;
        }
        else
            return;

       
    }

}
