﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player : MonoBehaviour

{
    //Serialize because we want to have this in the editor/inspector.
    [SerializeField] public LayerMask groundLayerMask;
    [SerializeField] public LayerMask deadLayerMask;

    private CircleCollider2D circleCollider2d;
    private Rigidbody2D rigidbody2d;

    public AudioClip JumpSound;

    public float moveSpeed = 6f;
    public float jumpVelocity = 5;
    public float x = 0;

    private void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        circleCollider2d = transform.GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (rigidbody2d.position.y < -6)
        {
            SceneManager.LoadScene("End");
        }

        rigidbody2d.velocity = new Vector2(+moveSpeed, rigidbody2d.velocity.y);

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            //this will add a velocity of 'jumpVelocity' to the Y of the Rigidbody2D from the Object this script is used on.
            rigidbody2d.velocity = Vector2.up * jumpVelocity;

            //this will add a JumpSound when you can jump, it's from the SoundManager script.
            SoundManager.Instance.PlayEffect(JumpSound);

        }
    }

    public bool IsGrounded()
    {

        // Raycast because we want to check if the ground is below, BoxCast because if it's only a raycast there only is a line in the middle of the sprite so it can't jump when it's on an edge.
        // bounds.center = center from boxCollider of the object.
        // bounds.size = size from boxCollider of the object.
        // 0f = rotation.
        // Vector2.down because we want to check if there is something there (so we have to move a tiny bit downwards), '.1f' is the down force. 
        // groundLayerMask is the Tagline which you can set the ground on.

        RaycastHit2D raycastHit2d = Physics2D.BoxCast(circleCollider2d.bounds.center, circleCollider2d.bounds.size, 0f, Vector2.down, .1f, groundLayerMask);
        return raycastHit2d.collider != null;
    }
}