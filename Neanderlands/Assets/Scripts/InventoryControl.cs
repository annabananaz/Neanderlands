using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;



public class InventoryControl : MonoBehaviour

{

    [SerializeField]

    private GameObject pickaxeFind, torchFind, playerPickaxe, playerTorch;



    //Generic stuff for the Toolbox

    public int currentTool = 1;

    public bool Hands = true;

    public bool PickAxe = false;

    public bool Torch = false;



    //ui elements for each tool

    public Graphic hands;

    public Graphic pick;

    public Graphic torch;

    public Graphic handsBG;

    public Graphic pickBG;

    public Graphic torchBG;



    void Awake()

    {

        //only hands are visible

        handsBG.color = Color.white;

        pickBG.color = Color.black;

        pick.CrossFadeAlpha(0, 0.0f, false);

        torchBG.color = Color.black;

        torch.CrossFadeAlpha(0, 0.0f, false);

    }



    // Update is called once per frame

    void Update()

    {

        PickUpTool();

        //Mechanic for Switching between tools

        if (Input.GetKeyDown("1"))

        {

            currentTool = 1;

            handsBG.color = Color.white;

            pickBG.color = Color.black;

            torchBG.color = Color.black;

            print("Current Tool is Hands");

        }

        if (Input.GetKeyDown("2") && PickAxe == true)

        {

            currentTool = 2;

            handsBG.color = Color.black;

            pickBG.color = Color.white;

            torchBG.color = Color.black;

            print("Current Tool is PickAxe");

        }

        if (Input.GetKeyDown("3") && Torch == true)

        {

            currentTool = 3;

            handsBG.color = Color.black;

            pickBG.color = Color.black;

            torchBG.color = Color.white;

            print("Current Tool is Torch");

        }



        switch (currentTool)
        {

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

                pick.CrossFadeAlpha(1, 0.0f, false);

                handsBG.color = Color.black;

                pickBG.color = Color.white;

                torchBG.color = Color.black;

                pickaxeFind.SetActive(false);

            }



            float distTorch = Vector3.Distance(gameObject.transform.position, torchFind.transform.position);

            if (distTorch <= 1.5f)

            {

                Torch = true;

                currentTool = 3;

                torch.CrossFadeAlpha(1, 0.0f, false);

                handsBG.color = Color.black;

                pickBG.color = Color.black;

                torchBG.color = Color.white;

                torchFind.SetActive(false);

            }



        }

    }

}