using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl : MonoBehaviour
{
    [SerializeField]
    private GameObject pickaxeFind, torchFind, playerPickaxe, playerTorch;

    //Generic stuff for the Toolbox
    public int currentTool = 1;
    public bool Hands = true;
    public bool PickAxe = false;
    public bool Torch = false;

    // Update is called once per frame
    void Update()
    {
        PickUpTool();
        //Mechanic for Switching between tools
        if (Input.GetKeyDown("1"))
        {
            currentTool = 1;
            print("Current Tool is Hands");
        }
        if (Input.GetKeyDown("2") && PickAxe == true)
        {
            currentTool = 2;
            print("Current Tool is PickAxe");
        }
        if (Input.GetKeyDown("3") && Torch == true)
        {
            currentTool = 3;
            print("Current Tool is Torch");
        }

        switch (currentTool) {
            case 1:
                playerPickaxe.SetActive(false);
                playerTorch.SetActive(false);
                break;
            case 2:
                playerPickaxe.SetActive(true);
                playerTorch.SetActive(false);
                break;
            case 3:
                playerPickaxe.SetActive(false);
                playerTorch.SetActive(true);
                break;
        }
    }

    private void PickUpTool()
    {
        //GetComponent<BoxCollider>().enabled = false;
        if (Input.GetKeyDown(KeyCode.E))
        {
            float distPickaxe = Vector3.Distance(gameObject.transform.position, pickaxeFind.transform.position);
            if (distPickaxe <= 1.5f)
            {
                PickAxe = true;
                currentTool = 2;
                pickaxeFind.SetActive(false);
            }

            float distTorch = Vector3.Distance(gameObject.transform.position, torchFind.transform.position);
            if (distTorch <= 1.5f)
            {
                Torch = true;
                currentTool = 3;
                torchFind.SetActive(false);
            }

        }
    }
}
