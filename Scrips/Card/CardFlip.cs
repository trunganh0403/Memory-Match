using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class CardFlip : GameMonoBehaviour
{
    [SerializeField] protected Image frontImage; 
    [SerializeField] protected Image backImage;  
    [SerializeField] protected Image icon;
    [SerializeField] protected bool isFlipped = false;
    [SerializeField] protected int layerIndex = 0;
    public Image Icon => icon;
    private Animator animator;

    protected override void Start()
    {
        //this.ResetCard();

        animator = GetComponent<Animator>();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFrontImage();
        this.LoadBackImage();
        this.LoadIcon();
    }

    protected virtual void LoadFrontImage()
    {
        if (this.frontImage != null) return;
        this.frontImage = transform.Find("FrontSprite").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadFrontImage", gameObject);
    }

    protected virtual void LoadBackImage()
    {
        if (this.backImage != null) return;
        this.backImage = transform.Find("BackSprite").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadBackImage", gameObject);
    }

    protected virtual void LoadIcon()
    {
        if (this.icon != null) return;
        this.icon = transform.Find("Icon").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadIcon", gameObject);
    }

    public void OnMouseDown()
    {
        if (!CompareTag("Card")) return;
        if (PanelManger.Instance.IsAnyPanelActive()) return;
 
        if (!GameManager.Instance.CanFlip()) return;

        if (!this.isFlipped)
        {          
            GameManager.Instance.CardRevealed(this);
            this.CardFlips();
        }
    }

    public void CardFlips()
    {
        isFlipped = !isFlipped;
        animator.SetTrigger(TagAnimation.CardFlip);     

    } 
    
    public void CardIdle()
    {
        isFlipped = !isFlipped;
        animator.SetTrigger(TagAnimation.CardIdle);     

    }

    public void HideCard()
    {
        animator.SetTrigger("SmokeAppear");
    }

    public void ResetCard()
    {

        if (isFlipped == false) return;
        Debug.Log("ResetCard");
        isFlipped = false;
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(layerIndex);
        GameManager.Instance.IsScore = 0;
        if (stateInfo.IsName(TagAnimation.CardFlip))
        {
            animator.SetTrigger(TagAnimation.CardIdle);
            GameManager.Instance.SetCardNull();
        }
        if (stateInfo.IsName(TagAnimation.SmokeAppear))
        {
            animator.SetTrigger(TagAnimation.RestCard);
            GameManager.Instance.SetCardNull();
        }

    }
}
