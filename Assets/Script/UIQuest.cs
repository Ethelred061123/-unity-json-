using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Collections.Concurrent;

public class UIQuest : MonoBehaviour
{
    public static UIQuest Instance;
    void Awake()
    {
        Instance = this;
    }

    public GameObject UIquest;
    public TMP_Text content;
    public Button a;
    public Button b;
    public Button c;
    public Button d;
    private int answer;
    private int times = 0;
    private QuestionData crrentQuestion;
    // Start is called before the first frame update
    void Start()
    {
        UIquest.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowUIQuestion(QuestionData Qdata)
    {
        crrentQuestion = Qdata;
        content.text = Qdata.question;
        a.GetComponentInChildren<TMP_Text>().text = Qdata.option1;
        b.GetComponentInChildren<TMP_Text>().text = Qdata.option2;
        c.GetComponentInChildren<TMP_Text>().text = Qdata.option3;
        d.GetComponentInChildren<TMP_Text>().text = Qdata.option4;
        answer = Qdata.answer;
    }

    public void OnButtonDown(int a)
    {
        if (MessageBox.Instance.Messagebox != null)
        {
            MessageBox.Instance.Messagebox.SetActive(true);
            if (a == answer)
            {
                MessageBox.Instance.MessageShow("回答正确", "确定");

                times++;
                if (times == 2)
                {
                    UIquest.SetActive(false);
                    times = 0;
                    return;
                }
                ShowUIQuestion(DataManager.Instance.QuestionDataID(crrentQuestion.Id + 1));
            }
            else
            {
                MessageBox.Instance.MessageShow($"回答错误，正确答案是{answer}个选项", "确定");
            }
        }

    }

}
