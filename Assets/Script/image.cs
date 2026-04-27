using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class image : MonoBehaviour
{
    public int idx;

    public GameObject ui;

    void OnMouseDown()
    {
        if (UIMain.Instance != null)
        {
            UIMain.Instance.RefreshUI(idx);
            if (ui != null)
                ui.SetActive(true);
        }
    }
}
