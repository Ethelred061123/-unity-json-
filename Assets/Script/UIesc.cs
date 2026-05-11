using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIesc : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
