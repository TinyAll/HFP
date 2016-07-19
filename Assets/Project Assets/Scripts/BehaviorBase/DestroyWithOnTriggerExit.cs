using UnityEngine;
using System.Collections;

public class DestroyWithOnTriggerExit : MonoBehaviour
{
    public bool isDestroy = false;

    private int _z;

    public void execute(int z)
    {
        transform.position = Vector3.up * z;

        isDestroy = true;
    }

    public void execute(int z, float time)
    {
        _z = z;

        Invoke("invokeFuc", time);
    }

    void invokeFuc()
    {
        execute(_z);
    }

    void FixedUpdate()
    {
        if (isDestroy)
        {
            Destroy(gameObject);
        }
    }
}
