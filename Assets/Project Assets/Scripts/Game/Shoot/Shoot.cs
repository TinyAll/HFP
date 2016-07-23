using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    public PoolManager pools;

    public enum WEAPONS { Bullet, Fishingnet, BulletWithFishingnet }; // available weapons for easy access

    public WEAPONS weapon;

    public Transform startPoint;

    public float bulletSpeed = 1;

    private Vector3 oldPosition;

    private Vector3 currentVelocity;

    private AttackBehaviorBase attackBehaviorBase;

    public virtual void Start()
    {
        attackBehaviorBase = GetComponent<AttackBehaviorBase>();

        pools.CreatePool("Weapon/", WEAPONS.Bullet.ToString(), 10);
        pools.CreatePool("Weapon/", WEAPONS.Fishingnet.ToString(), 10);
        pools.CreatePool("Weapon/", WEAPONS.BulletWithFishingnet.ToString(), 10);
    }

    public virtual void Update()
    {
        currentVelocity = (transform.position - oldPosition) / Time.deltaTime;

        oldPosition = transform.position;
    }
	public virtual void shoot(Vector3 shootPoint)
    {
        Vector3 pos = startPoint.position;

        pos.z = 0;

        var type = weapon.ToString();

        var weaponGameObj = pools.GetObjectFromPool(type); // Loader.LoadGameObject("Weapon/" + type);

        weaponGameObj.name = type;

        weaponGameObj.transform.position = pos;

        var weaponBehavior = weaponGameObj.GetComponent<WeaponBehavior>();

        attackBehaviorBase.useWeapon(weaponBehavior);

        weaponBehavior.init(attackBehaviorBase,shootPoint, currentVelocity);
    }
    public void setWeapon(string name)
    {
        weapon = (WEAPONS) System.Enum.Parse(typeof(WEAPONS), name);
    }
}
