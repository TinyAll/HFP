using UnityEngine;
using System.Collections;

public class PlayerBehavior : LifeBehavior
{

    public enum MODE
    {
        None,
        PlayerMode1,
        PlayerMode2,
        PlayerMode3
    }

    public MODE mode;

    public override void Start()
    {
        base.Start();

        if (mode != MODE.None)
        {
            var type = mode.ToString();

            setMode(type);
        }
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
}
