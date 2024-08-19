using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5;
    [SerializeField] private float horizontalMultiplier = 2;
    private float horizontalInput;
    private bool alive = true;
    public float speedIncreasePerPoint = 0.5f;

    [SerializeField] float moveForward;
    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask groundMask;

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
            Debug.Log("hi");
        }
        
        if (transform.position.y < -1)
        {
            Die();
        }
    }


    void FixedUpdate()
    {
        
      //  Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        Vector3 forwardMove = new Vector3(0, 0, moveForward);
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
        
       

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

    }

    public void Die ()
    {
        alive = false;
        Invoke("Restart", 1);
    }

    void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);
        
        if(isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }

   

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

 
}