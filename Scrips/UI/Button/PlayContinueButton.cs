using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayContinueButton : BaseButton
{
    protected override void OnClick()
    {
        LevelManager.Instance.NextLevel();
        DialogWinningPn.Instance.Close();
    }
}
