using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrenger : MonoBehaviour
{
    List<Transform> children;
    // Start is called before the first frame update
    void Start()
    {
        children = new List<Transform>();

        UpdateChildren();
    }

    // Update is called once per frame
    public void UpdateChildren()
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            if (i == children.Count)
            {
                children.Add(null);
            }

            var child = transform.GetChild(i);

            if (child != children[i])
            {
                children[i] = child;
            }
        }
        children.RemoveRange(transform.childCount, children.Count - transform.childCount);
    }

    public int GetIndexByPosition(Transform unit, int skipindex = -1)
    {
        int result = 0;
        for (int i = 0; i < children.Count; i++)
        {
            if (unit.position.x < children[i].position.x)
                break;
            else if (skipindex != i)
                result++;

        }
        return result;
    }

    public void SwapUnit(int index01, int index02)
    {
        Central.Swap(children[index01], children[index02]);
        UpdateChildren();
    }
    void Update()
    {

    }
}