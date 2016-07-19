using UnityEngine;
using System.Collections;

public class AttackBehaviorBase : MonoBehaviour {

    public int HP;

    public int ATK;

    public int coinValue;

    public enum MODE{
        None,
        PlayerMode1,
        PlayerMode2,
        PlayerMode3
    }

    public MODE mode;

    private Mission mission;

    public virtual void Awake()
    {
        gameObject.AddComponent<MovementData>();

        gameObject.AddComponent<DestroyWithOnTriggerExit>();
    }
    public virtual void Start()
    {
        mission = GetComponent<Mission>();

        if(mode != MODE.None)
        {
            var type = mode.ToString();

            setMode(type);
        }
        Invoke("nextFrame", 0);
    }
    public void setMode(string type)
    {
        var mode = gameObject.transform.FindChild("Mode");

        if (mode)
        {
            Destroy(mode.gameObject);
        }
        var modeGameObj = Loader.LoadGameObject("Mode/" + type);

        modeGameObj.name = "Mode";

        modeGameObj.transform.parent = gameObject.transform;

        modeGameObj.transform.position = gameObject.transform.position;

        modeGameObj.transform.rotation = gameObject.transform.rotation;
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
