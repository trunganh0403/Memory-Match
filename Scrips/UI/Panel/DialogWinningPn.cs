using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogWinningPn : BasePanel
{
    private static DialogWinningPn instance;
    public static DialogWinningPn Instance { get => instance; }

    protected override void Awake()
    {
        if (DialogWinningPn.instance != null) Debug.LogError("Only 1 DialogWinningPn allow to exist");
        DialogWinningPn.instance = this;
    }

    public override void Close()
    {
        base.Close();
        CountdownTime.Instance.RestTime();
    }

}
