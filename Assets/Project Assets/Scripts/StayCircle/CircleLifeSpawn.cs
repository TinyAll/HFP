using UnityEngine;
using System.Collections;

public class CircleLifeSpawn : MonoBehaviour {

	public GameObject fish;

    public Transform distanceObject;

    public float spawnDistance = 50;

    public float dispearDistance = 100;

    public float spawnIntervalTimer = 0.01f;

    private float intervalTimer = 0;

    public int count = 0;

    private int amount = 0;

    public float changePositionTime = 2;

    public float changePositionTimeOffset = 0.2f;

    public float stayCircleRadius = 15;

    public float spawnCircleRadius = 5;

    [HideInInspector]
    public Vector3 position;

    public float offsetRadius = 2;

    public bool drawRange = false;

    private Vector3[] paths = new Vector3[11];

    private bool isLifeActive = false;

    void Start () {

        intervalTimer = spawnIntervalTimer;

        amount = count;

        position = transform.position;

        InvokeRepeating("distrubutePosition", 0, changePositionTime);
    }

    void Update()
    {
        float sqrDistance = (position - distanceObject.position).sqrMagnitude;

        if (sqrDistance < spawnDistance * spawnDistance)
        {
            if (amount > 0)
            {
                intervalTimer -= Time.deltaTime;

                if(intervalTimer < 0)
                {
                    intervalTimer = spawnIntervalTimer;

                    //distrubutePosition();

                    position = Random.insideUnitCircle * spawnCircleRadius;

                    position += transform.position;

                    var obj = (GameObject)Instantiate(fish, position, Quaternion.identity);

                    obj.name = fish.name;

                    obj.transform.SetParent(transform, true);

                    amount--;

                    isLifeActive = true;
                }
            }
            else
            {
                if (!isLifeActive)
                {
                    isLifeActive = !isLifeActive;

                    foreach (Transform item in transform)
                    {
                        item.gameObject.SetActive(isLifeActive);
                    }
                }
            }
        }
        else if(sqrDistance > dispearDistance* dispearDistance)
        {
            if (isLifeActive)
            {
                isLifeActive = !isLifeActive;

                foreach(Transform item in transform)
                {
                    item.gameObject.SetActive(isLifeActive);
                }
            }
        }
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
