using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private Animator playerAnim;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 direction;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        direction = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(direction.sqrMagnitude > 0)
        {
            playerAnim.SetInteger("Movement", 1);
        }
        else
        {
            playerAnim.SetInteger("Movement", 0);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + direction * speed * Time.fixedDeltaTime);
    }

    void Flip()
    {
        if (direction.x < 0)
        {
            transform.eulerAngles = new Vector2 (0, -180);
        }
        else if (direction.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0);
        }
    }
}
