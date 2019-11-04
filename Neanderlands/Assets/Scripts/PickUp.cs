using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField]
    public Transform dest;

    bool pickedUp = false;

    void OnMouseDown()
    {
        //GetComponent<BoxCollider>().enabled = false;
        pickedUp = true;
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = dest.position;
        this.transform.parent = GameObject.Find("HoldDestination").transform;
    }

    void OnMouseUp()
    {
        pickedUp = false;
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        //GetComponent<BoxCollider>().enabled = true;
    }

    private void Update()
    {
        if (pickedUp && this.transform.position != dest.position)
        {
            pickedUp = false;
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
