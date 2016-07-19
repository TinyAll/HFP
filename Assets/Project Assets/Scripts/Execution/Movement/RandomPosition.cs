﻿using UnityEngine;
using System.Collections;

public class RandomPosition : MovementBase
{
    public bool drawRange = false;

    public Vector3 center;

    public float changePositionTime;

    protected Vector3 oldMovement;

    protected Vector3 velocity = Vector3.zero;

    protected float passTime = 0;

    override public void Start()
    {
        base.Start();
    }
    public override void OnEnter()
    {
        base.OnEnter();
    }
    public override void OnExit()
    {
        base.OnExit();
        CancelInvoke("distrubutePosition");
    }
    public virtual void distrubutePosition()
    {

    }
    public void changePosition(Vector3 position)
    {
        oldMovement = velocity;

        passTime = 0;

        velocity = position - transform.position;

        var velocityManitude = velocity.magnitude;

        speed = velocityManitude / changePositionTime;

        velocity = velocity.normalized * speed;
    }

    public void calculateMovement()
    {
        passTime += Time.deltaTime;

        var v1 = Vector3.Lerp(oldMovement, Vector3.zero, passTime / changePositionTime);

        var v2 = Vector3.Lerp(Vector3.zero, velocity, passTime / changePositionTime);

        movement = v1 + v2;

        applayMovement(MotiveType.velocity, movement);
    }
}
