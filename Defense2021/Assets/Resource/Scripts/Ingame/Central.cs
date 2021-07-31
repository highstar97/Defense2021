using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Central : MonoBehaviour
{
    public Transform invisible;

    List<Arrenger> arrengers;
    // Start is called before the first frame update
    void Start()
    {
        arrengers = new List<Arrenger>();

        var arrs = transform.GetComponentsInChildren<Arrenger>();

        for (int i = 0; i < arrs.Length; i++)
        {
            arrengers.Add(arrs[i]);

        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void Swap(Transform sour, Transform dest)
    {
        Transform sourParent = sour.parent;
        Transform destParent = dest.parent;

        int sourIndex = sour.GetSiblingIndex();
        int destIndex = dest.GetSiblingIndex();

        sour.SetParent(destParent);
        sour.SetSiblingIndex(destIndex);

        dest.SetParent(sourParent);
        dest.SetSiblingIndex(sourIndex);


    }

    void SwapUnit(Transform sour, Transform dest)
    {

        Swap(sour, dest);
        arrengers.ForEach(t => t.UpdateChildren());
    }

    bool ContainPos(RectTransform rt, Vector2 pos)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(rt, pos);
    }

    void BeginDrag(Transform unit)
    {
        Debug.Log("BeginDrag:" + unit.name);
        SwapUnit(invisible, unit);
    }
    void Drag(Transform unit)
    {
        Debug.Log("Drag:" + unit.name);
        var whichArrangerCard = arrengers.Find(t => ContainPos(t.transform as RectTransform, unit.position));
        if (whichArrangerCard == null)
        { }
        else
        {
            int invisibleUnitIndex = invisible.GetSiblingIndex();
            int targetIndex = whichArrangerCard.GetIndexByPosition(unit, invisibleUnitIndex);
            if (invisibleUnitIndex != whichArrangerCard.GetIndexByPosition(unit, invisibleUnitIndex))
            {
                whichArrangerCard.SwapUnit(invisibleUnitIndex, targetIndex);
            }
        }
    }
    void EndDrag(Transform unit)
    {
        Debug.Log("EndDrag:" + unit.name);
        SwapUnit(invisible, unit);
    }
}