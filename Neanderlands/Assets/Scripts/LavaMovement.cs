using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaMovement : MonoBehaviour
{
    [SerializeField]
    private float heightLimit = 10;
    Vector3 heightAdd = new Vector3(0f, 0.1f, 0f);

    private float startHeight = 0f;

    private void Start()
    {
        startHeight = this.transform.position.y;
        heightLimit += startHeight;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y >= heightLimit) {
            heightAdd = -heightAdd;
        }

        if (this.transform.position.y < startHeight)
        {
            heightAdd = -heightAdd;
        }

        this.transform.position += heightAdd * Time.deltaTime;
    }
}
