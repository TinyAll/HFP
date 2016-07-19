using UnityEngine;
using System.Collections;

public class ShootByUser : Shoot
{
    public Transform cameraTransform;

    protected virtual void OnEnable()
    {
         Lean.LeanTouch.OnFingerTap += OnShooting;
    }

    protected virtual void OnDisable()
    {
        Lean.LeanTouch.OnFingerTap -= OnShooting;
    }


    public void OnShooting(Lean.LeanFinger finger)
    {
        if (finger.IsOverGui == false)
        {
            var position = finger.GetWorldPosition(-cameraTransform.position.z);

            base.shoot(position);
        }
    }
}
