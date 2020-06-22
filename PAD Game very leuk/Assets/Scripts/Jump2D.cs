using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Jump2D : MonoBehaviour

{
    //Serialize because we want to have this in the editor/inspector.
    [SerializeField] public LayerMask groundLayerMask;


    public float moveSpeed = 6f;
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

        rigidbody2d.velocity = new Vector2(+moveSpeed, rigidbody2d.velocity.y);
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            //this will add a velocity of 'jumpVelocity' to the Y of the Rigidbody2D from the Object this script is used on.
            rigidbody2d.velocity = Vector2.up * jumpVelocity; 
        }
    }

    public bool IsGrounded()
    {

        // Raycast because of checking the ground, BoxCast because if it's only a raycast there only is a line in the middle of the sprite so it can't jump when it's on an edge.
        // bounds.center = center from boxCollider of the object.
        // bounds.size = size from boxCollider of the object.
        // 0f = rotation.
        // Vector2.down because we want to check if there is something there (so we have to move a tiny bit downwards), '.1f' is the down force. 
        // groundLayerMask is the Tagline which you can set the ground on.

        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, groundLayerMask);
        return raycastHit2d.collider != null;
    }
}
