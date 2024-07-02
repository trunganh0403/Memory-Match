using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : ToggleButton
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLoading();
        this.LoadGamePlay();
    }

    protected virtual void LoadLoading()
    {
        if (loading != null) return;
        loading = transform.parent.parent.GetComponent<Transform>();
        Debug.Log(transform.name + ": LoadLoading", gameObject);
    }

    protected virtual void LoadGamePlay()
    {
        if (gamePlay != null) return;
        gamePlay = transform.parent.parent.parent.Find("GamePlay").transform;
        Debug.Log(transform.name + ": LoadGamePlay", gameObject);
    }

    protected override bool ShouldGamePlayBeActive()
    {
        return true;
    }
}
