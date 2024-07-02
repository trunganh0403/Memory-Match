using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : GameMonoBehaviour
{
    [SerializeField] protected Button button;

    protected override void Start()
    {
        base.Start();
        this.AddOnClickEven();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadButton();
    }

    protected virtual void LoadButton()
    {
        if (button != null) return;
        button = GetComponent<Button>();
        Debug.Log(transform.name + ": LoadButton", gameObject);
    }

    protected virtual void AddOnClickEven()
    {
        button.onClick.AddListener(this.OnClick);
    }

    protected abstract void OnClick();
}
