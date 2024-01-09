using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private bool _isGrounded;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Cek apakah karakter berada di atas tanah
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // Input untuk bergerak
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 moveDirection = new Vector2(horizontalInput, 0);
        _rigidbody2D.velocity = new Vector2(moveDirection.x * moveSpeed, _rigidbody2D.velocity.y);

        // Input untuk melompat
        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
        }
    }
}
