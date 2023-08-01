using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager: MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] protected TextMeshProUGUI scoreP1;
    [SerializeField] protected TextMeshProUGUI scoreP2;
    [SerializeField] protected TextMeshProUGUI scoreP3;
    [SerializeField] protected TextMeshProUGUI scoreP4;
    [SerializeField] protected TextMeshProUGUI timerText;


    public void Awake()
    {
        Instance = this; 
    }

    public void Start()
    {
       
    }
}
