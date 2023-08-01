using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUIManager : UIManager
{

    [SerializeField] protected TextMeshProUGUI winnerText;
    [SerializeField] protected TextMeshProUGUI loserText;
    [SerializeField] protected Button mainMenu, retry;

    new
        // Start is called before the first frame update
        void Start()
    {
        mainMenu.onClick.AddListener(GameManager.Instance.loadMainMenu);
        retry.onClick.AddListener(GameManager.Instance.loadGameScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void announceWinner()
    {
        StatManager.Instance.chooseWinner();
        winnerText.text = string.Format("{0} won.", StatManager.Instance.winner);
    }

    public void announceLoser()
    {
        StatManager.Instance.chooseLoser();
        loserText.text = string.Format("{0} lost.", StatManager.Instance.loser);
    }

}
