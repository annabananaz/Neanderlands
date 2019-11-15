using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private const float V = 3.0f;
    [SerializeField]
    public Transform dest;

    [SerializeField]
    public Transform player;

    bool pickedUp = false;

    private void OnMouseDown()
    {
        //GetComponent<BoxCollider>().enabled = false;
        float dist = Vector3.Distance(gameObject.transform.position, player.position);
        if (dist <= V)
        {
            pickedUp = true;
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.position = dest.position;
            this.transform.parent = GameObject.Find("HoldDestination").transform;
        }
        
    }

    private void OnMouseUp()
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
