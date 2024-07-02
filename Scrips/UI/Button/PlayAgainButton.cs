using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAgainButton : BaseButton
{
    protected override void OnClick()
    {
        if(DialogWinningPn.Instance.gameObject.activeSelf == true)
        {
            DialogWinningPn.Instance.Close();
            CountdownTime.Instance.RestTime();
            return;
        }
       

        if (DialogLossPn.Instance.gameObject.activeSelf  == true)
        {
            DialogLossPn.Instance.Close();
            CountdownTime.Instance.RestTime();
            return;
        }
            
    }
}
