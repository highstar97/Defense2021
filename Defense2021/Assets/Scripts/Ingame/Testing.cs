using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ob1;
    public void TestClick()
    {
        Destroy(ob1, 0);
    }
}
