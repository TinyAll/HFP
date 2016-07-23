using UnityEngine;
using System.Collections;

public class DestroyByTime : DestroyBase
{
    public float time=0;
    public override void OnEnter()
    {
        base.OnEnter();

        attackBehaviorBase.destroyWithOnTriggerExit(time);
    }
}
