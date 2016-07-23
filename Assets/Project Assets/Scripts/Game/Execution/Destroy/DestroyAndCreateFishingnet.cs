using UnityEngine;
using System.Collections;

public class DestroyAndCreateFishingnet : DestroyBase
{
    public GameObject fishingnet;

    public override void OnEnter()
    {
        base.OnEnter();

        var fn = Instantiate(fishingnet, transform.position, Quaternion.identity)as GameObject;

        fn.name = fishingnet.name;

        fn.GetComponent<WeaponBehavior>().init(GetComponent<WeaponBehavior>().attackObj);

        attackBehaviorBase.destroyWithOnTriggerExit();
    }
}
