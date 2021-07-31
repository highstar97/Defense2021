using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform root;
    public GameObject pref;
    public Transform parent;
    //private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        root = transform.root;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        root.BroadcastMessage("BeginDrag", transform, SendMessageOptions.DontRequireReceiver);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        transform.position = eventData.position;
        root.BroadcastMessage("Drag", transform, SendMessageOptions.DontRequireReceiver);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        root.BroadcastMessage("EndDrag", transform, SendMessageOptions.DontRequireReceiver);
        Function_Instantiate();
    }

    private void Function_Instantiate()
    {
        Vector2 mousePos = Input.mousePosition;
        GameObject inst = Instantiate(pref, parent);
        inst.transform.position = mousePos;

    }
}