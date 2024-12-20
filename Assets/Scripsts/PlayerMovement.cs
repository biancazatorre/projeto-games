using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movemntSpeed;
    [SerializeField] private bool isAI;
    [SerializeField] private bool is2ndPlayer;
    [SerializeField] private GameObject ball;

    private Rigidbody2D rb;
    private Vector2 playerMove;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }


    void Update()
    {
        if (isAI)
        {
            AIControl();
        }
        else
        {
            PlayerControl();
        }
    }

    private void PlayerControl ()
    {
        if (is2ndPlayer)
        {
            playerMove = new Vector2(0, Input.GetAxisRaw("Vertical2"));
        }
        else
        {
            playerMove = new Vector2(0, Input.GetAxisRaw("Vertical"));
        }
    }
    private void AIControl()
    {
        if (ball.transform.position.y > transform.position.y + 0.5f)
        {
            playerMove = new Vector2(0, 1);
        }
        else if (ball.transform.position.y < transform.position.y - 0.5f)
        {
            playerMove = new Vector2(0, -1);
        }
        else
        {
            playerMove = new Vector2(0, 0);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = playerMove * movemntSpeed;
    }
}
