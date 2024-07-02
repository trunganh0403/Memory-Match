using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardCtrl : GameMonoBehaviour
{
    [SerializeField] protected CardFlip card;
    public CardFlip Card => card;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCardFlip();

    }

    protected virtual void LoadCardFlip()
    {
        if (this.card != null) return;
        this.card = GetComponentInChildren<CardFlip>();
        Debug.Log(transform.name + ": LoadCardFlip", gameObject);
    }
}
