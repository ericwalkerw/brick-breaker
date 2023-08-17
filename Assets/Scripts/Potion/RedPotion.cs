using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPotion : Potion
{
    public override void OnActive(IReceiveBuff xPotion)
    {
        base.OnActive(xPotion);
        xPotion.ApplyRedPotion();
    }
}
