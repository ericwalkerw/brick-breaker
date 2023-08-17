using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePotion : Potion
{
    public override void OnActive(IReceiveBuff xPotion)
    {
        base.OnActive(xPotion);
        xPotion.ApplyBluePotion();
    }
}
