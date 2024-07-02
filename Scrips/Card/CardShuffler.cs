using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardShuffler : GameMonoBehaviour
{
    [SerializeField] protected GridLayoutGroup gridLayoutGroup;
    [SerializeField] protected CardCtrl cardCtrl;
    [SerializeField] protected Button playAgainWinBt;
    [SerializeField] protected Button playAgainLossBt;
    //[SerializeField] protected Button homeLossBt;
    [SerializeField] protected Button homeMenuBt;
    [SerializeField] protected List<Transform> cards;
    [SerializeField] protected bool hasWon = false;

    protected override void Start()
    {
        ShuffleCards();
        playAgainWinBt.onClick.AddListener(ResetCards);
        playAgainLossBt.onClick.AddListener(ResetCards);
        //homeLossBt.onClick.AddListener(ResetCards);
        homeMenuBt.onClick.AddListener(ResetCards);
    }

    private void Update()
    {
        WinGame();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGridLayoutGroup();
        this.LoadListCards();
        this.LoadPlayAgainWinBt();
        this.LoadPlayAgainLossBt();
        //this.LoadHomeLossBt();
        this.LoadHomeMenuBt();
    }

    protected virtual void LoadGridLayoutGroup()
    {
        if (this.gridLayoutGroup != null) return;
        this.gridLayoutGroup = transform.GetComponent<GridLayoutGroup>();
        Debug.Log(transform.name + ": LoadGridLayoutGroup", gameObject);
    }

    protected virtual void LoadListCards()
    {
        if (this.cards.Count > 0) return;

        foreach (Transform card in transform)
        {
            this.cards.Add(card);
        }
        Debug.LogWarning(transform.name + ": LoadPrefabs", gameObject);
    }

    protected virtual void LoadPlayAgainWinBt()
    {
        if (this.playAgainWinBt != null) return;
        this.playAgainWinBt = transform.parent.parent.parent.Find("Dialog").Find("DialogWin").Find("BtPlayAgain").GetComponent<Button>();
        Debug.Log(transform.name + ": LoadplayAgainWinPn", gameObject);
    }
    
    protected virtual void LoadPlayAgainLossBt()
    {
        if (this.playAgainLossBt != null) return;
        this.playAgainLossBt = transform.parent.parent.parent.Find("Dialog").Find("DialogLoss").Find("BtPlayAgain").GetComponent<Button>();
        Debug.Log(transform.name + ": LoadPlayAgainLossPn", gameObject);
    }
    
    //protected virtual void LoadHomeLossBt()
    //{
    //    if (this.homeLossBt != null) return;
    //    this.homeLossBt = transform.parent.parent.parent.Find("Dialog").Find("DialogLoss").Find("BtHome").GetComponent<Button>();
    //    Debug.Log(transform.name + ": LoadHomeLossBt", gameObject);
    //}
    
    protected virtual void LoadHomeMenuBt()
    {
        if (this.homeMenuBt != null) return;
        this.homeMenuBt = transform.parent.parent.parent.Find("Dialog").Find("DialogMenu").Find("BtHome").GetComponent<Button>();
        Debug.Log(transform.name + ": LoadHomeMenuBt", gameObject);
    }

    protected virtual void ShuffleCards()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            int randomIndex = Random.Range(i, cards.Count);
            Transform temp = cards[randomIndex];
            cards[randomIndex] = cards[i];
            cards[i] = temp;
        }


        foreach (Transform card in cards)
        {
            card.SetAsLastSibling(); 
        }
    }

    void ResetCards()
    {
        hasWon = false;
        ShuffleCards();
        foreach (Transform cardd in cards)
        {
            cardCtrl =  cardd.GetComponent<CardCtrl>();
            cardCtrl.Card.ResetCard();
        }
    }

    protected virtual void WinGame()
    {
        if (hasWon) return;
        if (GameManager.Instance.IsScore < cards.Count / 2) return;

        StartCoroutine(DelayedWinGame());
    }

    private IEnumerator DelayedWinGame()
    {

        yield return new WaitForSeconds(1f);

        if (!hasWon) // Kiểm tra lại trước khi gọi hàm
        {
            DialogWinningPn.Instance.Open();
            hasWon = true; // Đánh dấu đã gọi hàm
        }

    }
}
