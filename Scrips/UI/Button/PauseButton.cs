using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : BaseButton
{
    protected override void OnClick()
    {
        MenuPn.Instance.Toggle();
    }
}
