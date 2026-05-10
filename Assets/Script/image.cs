using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class image : MonoBehaviour
{
    public int idx;

    public GameObject ui;

    void OnMouseDown()
    {
        if (UIMain.Instance != null && UIQuest.Instance.UIquest.activeSelf == false && UIMain.Instance.UI.activeSelf == false)
        {
            UIMain.Instance.RefreshUI(idx);
            if (ui != null)
                ui.SetActive(true);
        }
    }
}
