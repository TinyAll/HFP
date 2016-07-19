using UnityEngine;
using System.Collections;

public class CircleLifeSpawn : MonoBehaviour {

	public GameObject fish;

    public int count = 0;

    public float changePositionTime = 2;

    public float changePositionTimeOffset = 0.2f;

    public float stayCircleRadius = 15;

    [HideInInspector]
    public Vector3 position;

    public float offsetRadius = 2;

    public bool drawRange = false;

    private Vector3[] paths = new Vector3[11];

    void Start () {

        position = transform.position;

        for (int i = 0; i < count; i++)
        {
            distrubutePosition();

            var obj = (GameObject) Instantiate(fish, position, Quaternion.identity);

            obj.name = fish.name;

            obj.transform.SetParent(transform, true);
        }
        InvokeRepeating("distrubutePosition", 0, changePositionTime);
    }

    public float getChangePositonTime()
    {
        return changePositionTime+Random.Range(0, changePositionTimeOffset);
    }
    void distrubutePosition()
    {
        position = Random.insideUnitCircle * stayCircleRadius;

        position += transform.position;
    }

    void OnDrawGizmos()
    {
        if (drawRange)
        {
            for (int i = 0, k = 0; i <= 10; i++)
            {
                var r = 2 * Mathf.PI / 360;
                var x = Mathf.Sin(k * r) * stayCircleRadius;
                var y = Mathf.Cos(k * r) * stayCircleRadius;
                paths[i] = new Vector3(x, y, 0) + transform.position;
                k += 36;
            }
            iTween.DrawLine(paths, Color.yellow);
        }
    }
}
