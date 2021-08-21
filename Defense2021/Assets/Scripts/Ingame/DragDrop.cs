using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform root;
    private Camera mainCamera;
    private Vector3 targetPos;
    public GameObject pref;
    public Transform parent;
    public GameObject waringpanel;
    ObjectSpawn obspawn;
    //private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        obspawn = GameObject.Find("Canvas").GetComponent<ObjectSpawn>();
        root = transform.root;
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void enablewarning()
    {
        waringpanel.SetActive(false);
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
        //Vector2 mousePos = Input.mousePosition;
        //GameObject inst = Instantiate(pref, parent);
        //inst.transform.position = mousePos;
        if (obspawn.gold >= 300)
        {
            if (Input.GetMouseButtonUp(0))
            {

                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 10000f))
                {
                    targetPos = new Vector3(hit.point.x, 0f, hit.point.z);
                    GameObject enemy = (GameObject)Instantiate(pref, targetPos, Quaternion.identity);
                    obspawn.gold -= 300;
                }
            }
        }
        else
        {
            waringpanel.SetActive(true);
            Invoke("enablewarning", 1);
        }


    }
}