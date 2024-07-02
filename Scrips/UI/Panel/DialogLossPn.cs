using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogLossPn : BasePanel
{
    private static DialogLossPn instance;
    public static DialogLossPn Instance { get => instance; }

    protected override void Awake()
    {
        if (DialogLossPn.instance != null) Debug.LogError("Only 1 DialogLoss allow to exist");
        DialogLossPn.instance = this;
    }

    public override void Close()
    {
        base.Close();
    }

}
