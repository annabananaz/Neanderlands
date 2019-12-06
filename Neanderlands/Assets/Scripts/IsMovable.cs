using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsMovable : MonoBehaviour
{
	[SerializeField]
	InventoryControl inventoryControl;

    // Update is called once per frame
    void Update()
    {
		if (inventoryControl.currentTool == 1)
		{
			GetComponent<Rigidbody>().mass = 1;
		}
		else {
			GetComponent<Rigidbody>().mass = 1000;
		}       
    }
}
