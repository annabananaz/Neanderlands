using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomHealth : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private PlayerController playerControl;

    int mushroomAddHealth = 15;

    // Update is called once per frame
    void Update()
    {
        if (PickUpMushroom()) {
            playerControl.health += mushroomAddHealth;
            Destroy(gameObject);
        }
    }

    private bool PickUpMushroom()
    {
        //GetComponent<BoxCollider>().enabled = false;
        if (Input.GetKeyDown(KeyCode.E))
        {
            float distPlayer = Vector3.Distance(gameObject.transform.position, player.transform.position);
            if (distPlayer <= 1.5f)
            {
                return true;
            }

        }
        return false;
    }
}
