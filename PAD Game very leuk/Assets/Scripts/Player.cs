using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class Player : MonoBehaviour

{
    //Serialize because we want to have this in the editor/inspector.
    [SerializeField] public LayerMask groundLayerMask;

    private CircleCollider2D circleCollider2d;
    private Rigidbody2D player;

    public AudioClip JumpSound;
    public AudioClip HitSound;

    public float moveSpeed = 6f;
    public float increaseSpeed = 1f;
    public float jumpVelocity = 5f;
    public float maxSpeed = 10f;

    public float airTime = .2f;
    private float airCounter;

    public int playerLives = 3;
    public Text Lives;

    public Transform ScreenShakeManager;

    public GameObject isDeadPanel;

    private void Awake()
    {
        player = transform.GetComponent<Rigidbody2D>();
        circleCollider2d = transform.GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        //Display the lives of the player.
        Lives.text = "LIVES: " + playerLives;

        //The speed of the player is the moveSpeed, but it increases with the time, 
        //maxSpeed is the maximum speed of the player.
        if (moveSpeed < maxSpeed)
        {
            moveSpeed = moveSpeed + increaseSpeed * 0.0002f;
        }
        else moveSpeed = maxSpeed;

        //checks if the player is on the ground and adds an airTime to allow the player to jump a little bit after going off the ground
        if (IsGrounded())
        {
            airCounter = airTime;
        } else
        {
            airCounter -= Time.deltaTime;
        }

        //Moves the player on the x-as
         player.velocity = new Vector2(+moveSpeed, player.velocity.y);

        //When key is released jump length will lower, gives difference in jump length depending on how long you hold the jump button
        if(Input.GetButtonUp("Jump") && player.velocity.y > 0)
        {
            player.velocity = new Vector2(player.velocity.x, player.velocity.y * .5f);
        }

        //Check if the player is on the ground or if hangcounter > 0 before you are able to jump
        if ((IsGrounded() || airCounter > 0f)&& Input.GetKeyDown(KeyCode.Space) )
        {
            //this will add a velocity of 'jumpVelocity' to the Y of the Rigidbody2D from the Object this script is used on.
            player.velocity = Vector2.up * jumpVelocity;

            //this will add a JumpSound when you can jump, it's from the SoundManager script.
            SoundManager.Instance.PlayEffect(JumpSound);

        }
        //The speed of the player so we can track it in the console.
        //Debug.Log(moveSpeed);
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Player gets -1 lives when it hit's a gameObject with the tag "Spike".
        if (collision.gameObject.tag == "Spike")
        {
            playerLives -= 1;
            SoundManager.Instance.PlayEffect(HitSound);

            //Screen will shake.
            ScreenShakeManager.GetComponent<ScreenShake>().needToShake();
        }

        //Player dies when lives are 0 (or less) or when it enters the "DeadZone" (name of a gameObject with a collider).
        if (playerLives <= 0 || collision.gameObject.name == "DeadZone")
        {
            //Screen will shake.
            ScreenShakeManager.GetComponent<ScreenShake>().needToShake();

            SoundManager.Instance.PlayEffect(HitSound);

            //The DeathPanel (which is picked in the inspector) will be active.
            isDeadPanel.SetActive(true);

            //moveSpeed will be 0.
            moveSpeed = 0;
            increaseSpeed = 0;

            //the lives cannot go below 0.
            playerLives = 0;
        }
    }
}
