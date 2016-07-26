using UnityEngine;
using System.Collections;

public class Injured : ExecutionBase
{
    public override void OnEnter()
    {
        base.OnEnter();

               //var weaponBehaviorBase = otherAttackBehaviorBase as WeaponBehavior;

        switch (attackBehaviorBase.catchType)
        {
            case AttackBehaviorBase.CatchType.ByHp:
                {
                    var otherAttackBehaviorBase = currentOnEnterCollider.transform.GetComponent<AttackBehaviorBase>();

                    otherAttackBehaviorBase = otherAttackBehaviorBase ? otherAttackBehaviorBase : currentOnEnterCollider.transform.parent.GetComponent<AttackBehaviorBase>();

                    attackBehaviorBase.HP -= otherAttackBehaviorBase.ATK;

                    if (GetComponent<AttackBehaviorBase>().HP <= 0)
                    {
                        //otherAttackBehaviorBase.injuredAttackBehavior.GetComponent<AttackBehaviorBase>().catchFish(attackBehaviorBase, otherAttackBehaviorBase);

                        //attackBehaviorBase.coinValue = 0;

                        attackBehaviorBase.destroyWithOnTriggerExit();
                    }

                    break;
                }
            case AttackBehaviorBase.CatchType.ByProbability:
                {
                    var random = Random.Range(0.0f, 1.0f);

                    if (attackBehaviorBase.Probability > random)
                    {
                        attackBehaviorBase.destroyWithOnTriggerExit();
                    }

                    break;
                }
        }
        
    }
}
