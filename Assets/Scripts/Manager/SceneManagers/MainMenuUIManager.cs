using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIManager : UIManager
{

    [SerializeField] protected Button  start, highscore;

    new
        // Start is called before the first frame update
        void Start()
    {
        start.onClick.AddListener(GameManager.Instance.loadGameScene);
        highscore.onClick.AddListener(GameManager.Instance.loadGameScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
