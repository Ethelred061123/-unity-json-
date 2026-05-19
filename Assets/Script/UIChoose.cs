using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIChoose : MonoBehaviour
{
    public GameObject ChoosePrefab;

    public Button phone;
    public Button pc;

    public Button gameStart;
    // Start is called before the first frame update
    void Start()
    {
        ChoosePrefab.gameObject.SetActive(false);
        gameStart.onClick.AddListener(OnClickDown);
    }

    private void OnClickDown()
    {
        ChoosePrefab.gameObject.SetActive(true);
        

    }

    public void OnPhone()
    {
        SceneManager.LoadScene("cahngjin");
        UIphone.instance.UI.SetActive(true);
    }

    public void OnPC()
    {
        SceneManager.LoadScene("cahngjin");
        UIphone.instance.UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
