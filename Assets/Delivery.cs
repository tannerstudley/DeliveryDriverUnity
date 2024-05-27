using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(0, 255, 0, 255);
    [SerializeField] Color32 noPackageColor = new Color32(255, 255, 255, 255);

    [SerializeField] bool hasPackage = false;
    [SerializeField] float destroyDelay = 0.01f;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("I FUCKIN COLLIDED LMAO");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Package") && !hasPackage)
        {
            Destroy(collision.gameObject, destroyDelay);
            hasPackage = true;
            Debug.Log("Package picked up.");
            spriteRenderer.color = hasPackageColor;
        }

        if(collision.tag.Equals("Customer") && hasPackage)
        {
            hasPackage = false;
            Debug.Log("Package delivered");
            spriteRenderer.color = noPackageColor;
        }
    }
}
