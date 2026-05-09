using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MessageBox : MonoBehaviour
{
    public static MessageBox Instance;

    public void Awake()
    {
        Instance = this;
    }

    public GameObject Messagebox;
    public TMP_Text title;
    public TMP_Text button;
    // Start is called before the first frame update
    void Start()
    {
        if (Messagebox!=null)
            Messagebox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MessageShow(string title, string button)
    {
        this.title.text = title;
        this.button.text = button;
    }

}
