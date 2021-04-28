using UnityEngine;

public class Slidable : MonoBehaviour
{
    
    [SerializeField]
    private PhysicsMaterial2D material;

    private Collider2D coll;

    private int defaultLayer = LayerMask.NameToLayer("Default");

    void Awake()
    {
        coll = GetComponent<Collider2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        gameObject.layer = defaultLayer;

        coll.sharedMaterial = material;
    }

}
