using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIphone : MonoBehaviour
{
    public static UIphone instance;
    void Awake()
    {
        instance = this;
    }

    public GameObject UI;


}
