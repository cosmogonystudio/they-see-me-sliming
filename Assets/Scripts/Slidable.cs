using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slidable : MonoBehaviour
{
    Collider2D coll;
    [SerializeField] private PhysicsMaterial2D material;

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        gameObject.tag = "Untagged";
        gameObject.layer = 0;
        coll.sharedMaterial = material;
    }
}
