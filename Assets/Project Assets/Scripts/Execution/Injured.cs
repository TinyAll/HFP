using UnityEngine;
using System.Collections;

public class Injured : ExecutionBase
{
    public override void OnEnter()
    {
        base.OnEnter();

        var otherAttackBehaviorBase = currentOnEnterCollider.transform.parent.GetComponent<AttackBehaviorBase>();

        var weaponBehaviorBase = otherAttackBehaviorBase as WeaponBehavior;

        GetComponent<AttackBehaviorBase>().HP -= otherAttackBehaviorBase.ATK;

        if (GetComponent<AttackBehaviorBase>().HP <= 0)
        {
            weaponBehaviorBase.attackObj.GetComponent<AttackBehaviorBase>().catchFish(attackBehaviorBase, weaponBehaviorBase);

            attackBehaviorBase.coinValue = 0;

            GetComponent<DestroyWithOnTriggerExit>().execute(5000);
        }
    }
}
