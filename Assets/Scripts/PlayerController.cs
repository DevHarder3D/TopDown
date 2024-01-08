using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private Animator playerAnim;
    [SerializeField] private float speed;
    [SerializeField] private float initialSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private Vector2 direction;

    private bool isAttack = false;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();

        initialSpeed = speed;
    }

    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(direction.sqrMagnitude > 0)
        {
            playerAnim.SetInteger("Movement", 1);
        }
        else
        {
            playerAnim.SetInteger("Movement", 0);
        }

        Flip();

        PlayerRun();

        Attack();

        if(isAttack)
        {
            playerAnim.SetInteger("Movement", 2);
        }
    }

    private void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + direction.normalized * speed * Time.fixedDeltaTime);
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

    void PlayerRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
        }
    }

    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl) || Input.GetMouseButtonDown(0))
        {
            isAttack = true;
            speed = 0;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetMouseButtonUp(0))
        {
            isAttack = false;
            speed = initialSpeed;
        }
    }
}
