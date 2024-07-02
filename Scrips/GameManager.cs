using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GameMonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get => instance; }

    [SerializeField] protected CardFlip firstRevealed;
    [SerializeField] protected CardFlip secondRevealed;
    [SerializeField] private int isScore;

    public int IsScore { get => isScore; set => isScore=value; }

    protected override void Awake()
    {
        if (GameManager.instance != null) Debug.LogError("Only 1 GameManager allow to exist");
        GameManager.instance = this;
    }

    public bool CanFlip()
    {
        return secondRevealed == null;
    }

    public void CardRevealed(CardFlip card)
    {
        if (firstRevealed == null)
        {
            firstRevealed = card;
        }
        else
        {
            secondRevealed = card;
            StartCoroutine(CheckMatch());
        }
    }

    public virtual void SetCardNull()
    {
        this.firstRevealed = null;
        this.secondRevealed = null;
    }

    private IEnumerator CheckMatch()
    {
        if (firstRevealed.Icon.sprite == secondRevealed.Icon.sprite)
        {
            AudioManager.Instance.PlayCorrectAnswerSound();
            isScore +=1;
            yield return new WaitForSeconds(1f);
            firstRevealed.HideCard();
            secondRevealed.HideCard();
        }
        else
        {
            AudioManager.Instance.PlayWrongAnswerSound();
            // Nếu không trùng khớp, lật lại cả hai card
            yield return new WaitForSeconds(1.0f);
            Debug.Log("không trùng khớp");
            firstRevealed.CardIdle();
            secondRevealed.CardIdle();
        }

        this.SetCardNull();
    }
}
