using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBreak : MonoBehaviour
{
    [SerializeField]
    public Transform player;

    int hitCount = 0;
    double shake = 0.0f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnMouseDown()
    {
        //GetComponent<BoxCollider>().enabled = false;
        float dist = Vector3.Distance(gameObject.transform.position, player.position);
        if (dist <= 1.5f)
        {
            shake = 0.2f;
            hitCount++;
        }

    }

    private void Update()
    {
        //print(hitCount);
        Vector3 positionAdd = new Vector3(Random.Range((float)-shake, (float)shake), 0, Random.Range(-(float)shake, (float)shake));
        this.transform.position = this.transform.position + positionAdd;
        shake *= 0.8;
        if (hitCount >= 3) {
            Destroy(gameObject);
        }
    }
}
