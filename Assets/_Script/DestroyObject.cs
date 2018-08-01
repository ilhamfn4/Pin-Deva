using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {

    private PointSpawner pointSpawner;

    private void Awake()
    {
        pointSpawner = FindObjectOfType<PointSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Point")) 
        {
            Destroy(collision.gameObject);
            pointSpawner.SpawnPoint();
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Pin"))
        {
            Destroy(collision.gameObject);
        }

    }

}
