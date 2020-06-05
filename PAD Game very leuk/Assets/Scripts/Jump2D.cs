using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Jump2D : MonoBehaviour

{
    [SerializeField] public LayerMask groundLayerMask;
    public float jumpVelocity = 10;
    private BoxCollider2D boxCollider2d;
    private Rigidbody2D rigidbody2d;

    private void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            //this will add a velocity of 'jumpVelocity' to the Y of the Rigidbody2D from the Component this script is used on
            rigidbody2d.velocity = Vector2.up * jumpVelocity; 
        }
    }

    public bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, groundLayerMask);
        return raycastHit2d.collider != null;
    }
}
