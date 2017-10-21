using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public float[] pos = new float[2];
    public List<Slot> links;
    public List<Slot> walkableNext;
    public bool visited;

    public int id;
    public Slot previous;

    public GameObject wallTop;
    public GameObject wallBot;
    public GameObject wallLeft;
    public GameObject wallRight;

    void Awake()
    {
        wallTop = transform.GetChild(0).gameObject;
        wallBot = transform.GetChild(1).gameObject;
        wallRight = transform.GetChild(2).gameObject;
        wallLeft = transform.GetChild(3).gameObject;
    }

    public void RemoveWalls(Slot b)
    {
        RectTransform tA = GetComponent<RectTransform>();
        RectTransform tB = b.GetComponent<RectTransform>();

        if (tA.localPosition.x > tB.localPosition.x)
        {
            Destroy(wallLeft);
            Destroy(b.wallRight);
        }
        else if (tA.localPosition.x < tB.localPosition.x)
        {
            Destroy(b.wallLeft);
            Destroy(wallRight);
        }

        else if (tA.localPosition.y < tB.localPosition.y)
        {
            Destroy(b.wallBot);
            Destroy(wallTop);
        }
        else if (tA.localPosition.y > tB.localPosition.y)
        {
            Destroy(wallBot);
            Destroy(b.wallTop);
        }
    }
}
