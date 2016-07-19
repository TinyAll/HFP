using UnityEngine;
using System.Collections;

public class DestroyBullet: DestroyBase
{
    public override void OnEnter()
    {
        base.OnEnter();

        GetComponent<DestroyWithOnTriggerExit>().execute(9000);
    }
}
