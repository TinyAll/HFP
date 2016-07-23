using UnityEngine;
using System.Collections;

public class Polymerize : RandomPosition
{
    public float offsetRadiusDynamic = 0.5f;

    private CircleLifeSpawn lifeSpawn;

    private Vector3 positionOffsetStatic;


    public override void Start()
    {

        base.Start();

        lifeSpawn = transform.parent.GetComponent<CircleLifeSpawn>();

        //InvokeRepeating("distrubutePosition", 0, changePositionTime);
    }
    public override void OnEnter()
    {
        base.OnEnter();

        changePositionTime = lifeSpawn.getChangePositonTime();

        InvokeRepeating("distrubutePosition", 0, changePositionTime);

        var offsetRadiusStatic = lifeSpawn.offsetRadius;

        positionOffsetStatic = Random.insideUnitCircle * offsetRadiusStatic;
    }
    public override void distrubutePosition()
    {
        Vector3 position = lifeSpawn.position;

        Vector3 positionOffsetDynamic = Random.insideUnitCircle * offsetRadiusDynamic;

        changePosition(position + positionOffsetStatic + positionOffsetDynamic);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (enableMovement)
        {
            calculateMovement();
        }
    }
}
