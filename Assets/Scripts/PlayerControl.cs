using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float xDirection;
    public int xSpeed;
    public int health;
    private Rigidbody2D _compRigidbody2D;
    private SpriteRenderer _compSpriteRenderer;
    private SpriteRenderer obstacleSpriteRenderer;
    public int verticalForce = 8;
    private bool jump;
    public int jumps;
    private int maxJumps = 2;

    
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

        if (_compSpriteRenderer.color != obstacleSpriteRenderer.color)
        {
            health = health - 1;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
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
