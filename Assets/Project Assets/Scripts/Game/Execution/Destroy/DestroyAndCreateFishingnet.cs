using UnityEngine;
using System.Collections;

public class DestroyAndCreateFishingnet : DestroyBase
{
    //public GameObject fishingnet;

    public override void OnEnter()
    {
        base.OnEnter();

        var pools = attackBehaviorBase.pools;

        var fn = pools.GetObjectFromPool("Fishingnet");
        //var fn = Instantiate(fishingnet, transform.position, Quaternion.identity)as GameObject;
        fn.GetComponent<AttackBehaviorBase>().spawner = attackBehaviorBase.spawner;

        fn.transform.position = gameObject.transform.position;

        fn.transform.parent = attackBehaviorBase.spawner.transform;
        //fn.name = fishingnet.name;

        fn.GetComponent<WeaponBehavior>().init(GetComponent<WeaponBehavior>().attackObj);

        attackBehaviorBase.destroyWithOnTriggerExit();
    }
}
