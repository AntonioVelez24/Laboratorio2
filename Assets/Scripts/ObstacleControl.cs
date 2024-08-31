using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour
{
    public int speed;
    private Rigidbody2D _compRigidbody2D;
    
    void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (transform.position.x <= -9.40)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        _compRigidbody2D.velocity = new Vector2(speed * -1, 0);
    }
}
