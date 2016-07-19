using UnityEngine;
using System.Collections;

public class DestroyThing : DestroyBase
{
    public override void OnEnter()
    {
        base.OnEnter();

        GetComponent<DestroyWithOnTriggerExit>().execute(9500);
    }
}