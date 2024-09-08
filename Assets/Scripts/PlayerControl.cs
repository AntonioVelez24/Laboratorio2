using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerControl : MonoBehaviour
{
    private float xDirection;
    public int xSpeed;
    public int health = 10;
    private int score;
    private Rigidbody2D _compRigidbody2D;
    private SpriteRenderer _compSpriteRenderer;
    private SpriteRenderer obstacleSpriteRenderer;
    public int verticalForce = 8;
    private bool jump;
    public int jumps;
    private int maxJumps = 2;

    public static event Action<int> OnPlayerDamaged;
    public static event Action<int> OnPlayerScore;

    void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
        _compSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        jumps = maxJumps;
    }
    // Update is called once per frame
    void Update()
    {
        xDirection = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && jumps > 0) 
        {
            jumps = jumps - 1;
            jump = true;
        }
    }
    private void FixedUpdate()
    {
        if (jump)
        {
            jump = false;
            _compRigidbody2D.AddForce(Vector2.up * verticalForce, ForceMode2D.Impulse);                    
        }
        
        _compRigidbody2D.velocity = new Vector3(xSpeed * xDirection, _compRigidbody2D.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        obstacleSpriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();

        if (collision.gameObject.CompareTag("Obstacle")&&_compSpriteRenderer.color != obstacleSpriteRenderer.color) 
        {
            health = health - 1;
            OnPlayerDamaged?.Invoke(health);

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Heart"))
        {
            health = Mathf.Clamp(health + 1, 0, 10);
            OnPlayerDamaged?.Invoke(health);
            Destroy(collision.gameObject);
            return;
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            score = score + 100;
            OnPlayerScore?.Invoke(score);
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {        
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumps = maxJumps;           
        }        
    }
}
