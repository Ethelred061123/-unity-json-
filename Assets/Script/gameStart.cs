using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameStart : MonoBehaviour
{
    private Button start;
    void Start()
    {
        start = GetComponent<Button>();
        start.onClick.AddListener(Startgame);
    }

    void Startgame()
    {
        SceneManager.LoadScene("Demo");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
