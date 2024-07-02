using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BasePanel : GameMonoBehaviour
{
    [SerializeField] protected bool isOpen = false;
    public bool IsOpen => isOpen;

    protected override void Start()
    {
        base.Start();
        this.Close();
    }

    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if (this.isOpen) Open();
        else Close();
    }
    public virtual void Open()
    {
        
        this.gameObject.SetActive(true);
        CountdownTime.Instance.IsCountdownFinished = true;
    }

    public virtual void Close()
    {
        this.gameObject.SetActive(false);
        CountdownTime.Instance.IsCountdownFinished = false;
    }

}
