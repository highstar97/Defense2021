using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform root;
    private Camera mainCamera;
    public GameObject pref;
    public GameObject waringpanel;
    GoldManager goldManager;

    void Start()
    {
        goldManager = GameObject.Find("Gold Manager").GetComponent<GoldManager>();
        root = transform.root;
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        root.BroadcastMessage("BeginDrag", transform, SendMessageOptions.DontRequireReceiver);
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        root.BroadcastMessage("Drag", transform, SendMessageOptions.DontRequireReceiver);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        root.BroadcastMessage("EndDrag", transform, SendMessageOptions.DontRequireReceiver);
        Function_Instantiate();
    }

    private void Function_Instantiate()
    {
        if (goldManager.gold >= goldManager.Enemyprice)
        {
            if (Input.GetMouseButtonUp(0))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 10000f))
                {
                    Vector3 targetPos = new Vector3(hit.point.x, 0f, hit.point.z);
                    GameObject enemy = (GameObject)Instantiate(pref, targetPos, Quaternion.identity);
                    goldManager.gold -= goldManager.Enemyprice;
                }
            }
        }
        else
        {
            waringpanel.SetActive(true);
            Invoke("enablewarning", 1);
        }
    }
    public void enablewarning()
    {
        waringpanel.SetActive(false);
    }
}