using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D enemyRB;
    private SpriteRenderer sprite;
    [SerializeField] float enemySpeed = 3.5f;
    [SerializeField] Vector2 enemyDirection;

    public AreaDtController areaDtController;

    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        enemyDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        if (areaDtController.detectObj.Count > 0)
        {
            enemyDirection = (areaDtController.detectObj[0].transform.position - transform.position).normalized;

            enemyRB.MovePosition(enemyRB.position + enemyDirection * enemySpeed * Time.fixedDeltaTime);

            Flip(enemyDirection);
            
        }
    }

    void Flip(Vector2 enemyDir)
    {
        if(enemyDir.x < 0)
        {
            sprite.flipX = true;
        }
        if (enemyDir.x > 0)
        {
            sprite.flipX = false;
        }
    }
}
