using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIMain : MonoBehaviour
{
    public static UIMain Instance;
    void Awake()
    {
        Instance = this;  
    }

    private TMP_Text title;
    private TMP_Text text;
    private Image image;

    public GameObject UI;
    void Start()
    {
        title = GameObject.Find("Title").GetComponent<TMP_Text>();
        text = GameObject.Find("Content").GetComponent<TMP_Text>();
        image = GameObject.Find("Image").GetComponent<Image>();
        UI = GameObject.Find("showMessage");
        if (UI != null)
            UI.SetActive(false);
    }

    public void RefreshUI(int id)
    {
        ItemData data = DataManager.Instance.GetItemID(id);

        if (data != null)
        {
            title.text = data.title;

            text.text = data.description.Replace("\\n", "\n");

            Sprite sp = Resources.Load<Sprite>("Images/" + data.image);
            if (sp != null) image.sprite = sp;
        }
    }

}
