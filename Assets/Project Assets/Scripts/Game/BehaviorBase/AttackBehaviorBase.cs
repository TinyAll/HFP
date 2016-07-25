using UnityEngine;
using System.Collections;

abstract public class AttackBehaviorBase : MonoBehaviour {

    public int HP;

    public int ATK;

    public int coinValue;

    public int destroyDeep;

    bool isDestroy = false;

    private Mission mission;

    public PoolManager pools;

    [HideInInspector]
    public SpawnerBase spawner;

    public virtual void Awake()
    {
        if (!GetComponent<MovementData>())
        {
            gameObject.AddComponent<MovementData>();
        }

        //gameObject.AddComponent<DestroyWithOnTriggerExit>();
    }
    public virtual void Start()
    {
        mission = GetComponent<Mission>();

       
        Invoke("nextFrame", 0);
    }
    
    public virtual void nextFrame()
    {
        
    }

    public void destroyWithOnTriggerExit()
    {
        transform.position = Vector3.up * destroyDeep;

        isDestroy = true;
    }
    public void destroyWithOnTriggerExit(float time)
    {
        isDestroy = false;
        CancelInvoke("destroyWithOnTriggerExit");
        Invoke("destroyWithOnTriggerExit", time);
    }
    void FixedUpdate()
    {
        if (isDestroy)
        {
            pools.ReturnObjectToPool(gameObject.name, gameObject);

            isDestroy = false;
            //Destroy(gameObject);
        }
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
