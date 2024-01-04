using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRB;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 direction;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        direction = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    }

    private void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + direction * speed * Time.fixedDeltaTime);
    }
}
