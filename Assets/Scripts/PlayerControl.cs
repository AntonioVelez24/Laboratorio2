using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float xDirection;
    public int xSpeed;
    public int health;
    private Rigidbody2D _compRigidbody2D;

    // Start is called before the first frame update
    void Awake()
    {
        _compRigidbody2D= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xDirection = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        _compRigidbody2D.velocity = new Vector3(xSpeed * xDirection, _compRigidbody2D.velocity.y);
    }
}
