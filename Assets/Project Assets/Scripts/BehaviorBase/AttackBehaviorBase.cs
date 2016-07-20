using UnityEngine;
using System.Collections;

public class AttackBehaviorBase : MonoBehaviour {

    public int HP;

    public int ATK;

    public int coinValue;

   

    private Mission mission;

    public virtual void Awake()
    {
        gameObject.AddComponent<MovementData>();

        gameObject.AddComponent<DestroyWithOnTriggerExit>();
    }
    public virtual void Start()
    {
        mission = GetComponent<Mission>();

       
        Invoke("nextFrame", 0);
    }
    
    public virtual void nextFrame()
    {
        
    }
    public virtual void catchFish(AttackBehaviorBase catchAttackBehavior, WeaponBehavior weaponBehavior)
    {
        if (mission)
        {
            mission.ProcessUseWeaponCatchFish( weaponBehavior.name);
        }
        catchSomething(catchAttackBehavior);
    }
    public virtual void catchSomething(AttackBehaviorBase catchAttackBehavior)
    {
        coinValue += catchAttackBehavior.coinValue;

        if (mission)
        {
            mission.ProcessCatchSomething(catchAttackBehavior.gameObject.name);

            mission.ProcessEarnCoin(catchAttackBehavior.coinValue);
        }

    }
    public virtual void useWeapon(WeaponBehavior weaponBehavior)
    {
        coinValue -= weaponBehavior.coinValue;

        if (mission)
        {
            mission.ProcessConsumeWeapon(weaponBehavior.name);

            mission.ProcessConsumeCoinValue(weaponBehavior.coinValue);
        }
            
    }
}
