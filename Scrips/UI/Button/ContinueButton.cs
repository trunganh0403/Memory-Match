using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : BaseButton
{
    protected override void OnClick()
    {
        MenuPn.Instance.Close();
    }
}
