using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ToggleButton : BaseButton
{
    [SerializeField] protected Transform loading;
    [SerializeField] protected Transform gamePlay;
    [SerializeField] protected bool isGamePlayActive = true;

    protected override void OnClick()
    {
        StartCoroutine(DelayedOnClick());
    }

    private IEnumerator DelayedOnClick()
    {
        yield return new WaitForSeconds(0.15f); // Chờ 1 giây

        isGamePlayActive = ShouldGamePlayBeActive();
        gamePlay.gameObject.SetActive(isGamePlayActive);
        loading.gameObject.SetActive(!isGamePlayActive);
       // DialogLossPn.Instance.Close();
    }

    protected abstract bool ShouldGamePlayBeActive();

}
