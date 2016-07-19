using UnityEngine;
using System.Collections;
using System.Collections.Generic;//C# 包中的类
public class ExecutionBase : MonoBehaviour {

    public enum RangeType
    {
        autoStart = -1,

        EnemyRange,

        PlayerSwimmingRange,

        PlayerEscapeRange ,

        BulletHurtRange ,

        FishingnetEscapeRange ,

        PlayerHurtRange ,

        BulletEscapeRange,

        FishingnetHurtRange,

        PickUpRange,

        ThingsRange
    }
    public RangeType otherRange;

    private int otherLayer;

    public GameObject attackTriggerObject;

    private AttackTrigger trigger;

    protected float radius = 0;

    protected Dictionary<GameObject, SphereCollider> others;

    protected Collider currentOnEnterCollider;

    protected AttackBehaviorBase attackBehaviorBase;

    public virtual void Start()
    {
        attackBehaviorBase = gameObject.GetComponent<AttackBehaviorBase>();

        others = new Dictionary<GameObject, SphereCollider>();

        if (attackTriggerObject)
        {
            trigger = attackTriggerObject.GetComponent<AttackTrigger>();

            trigger.setCallback(OnTriggerEnterCallback, OnTriggerStayCallback, OnTriggerExitCallback);

            radius = attackTriggerObject.GetComponent<SphereCollider>().radius;
        }

        if(otherRange == RangeType.autoStart)
        {
            OnEnter();
        }

        otherLayer = LayerMask.NameToLayer(otherRange.ToString());
    }
    public virtual void OnTriggerEnterCallback(Collider other)
    {
        if(otherLayer == other.gameObject.layer)
        {
            others[other.gameObject] = (other as SphereCollider);

            currentOnEnterCollider = other;

            OnEnter();
        }
    }

    public virtual void OnTriggerStayCallback(Collider other)
    {
        if (otherLayer == other.gameObject.layer)
        {

        }
    }
    public virtual void OnTriggerExitCallback(Collider other)
    {
        if (otherLayer == other.gameObject.layer)
        {
            others.Remove(other.gameObject);

            OnExit();
        }
    }

    public virtual void OnEnter()
    {
    }
    public virtual void OnExit()
    {
    }

}
