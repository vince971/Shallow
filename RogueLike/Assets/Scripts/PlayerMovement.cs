using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// The player speed
    /// </summary>
    public float speed = 0.5f;

    /// <summary>
    /// The player direction
    /// </summary>
    private Vector2 direction;

    /// <summary>
    /// The player Animator
    /// </summary>
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        this.GetInput();
        this.Move();
    }

    private void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (direction.x != 0 || direction.y != 0)
        {
            this.SetAnimatorMovement(direction);
        }
        else
        {
            // Stop the WalkAnimator which is layer 1
            this.animator.SetLayerWeight(1, 0);
        }
    }

    /// <summary>
    /// Get which key has been pressed
    /// </summary>
    private void GetInput()
    {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
    }

    /// <summary>
    /// Set the Animator Movement
    /// </summary>
    /// <param name="direction"></param>
    private void SetAnimatorMovement(Vector2 direction)
    {
        // Start the Walk animator
        this.animator.SetLayerWeight(1, 1); 

        this.animator.SetFloat("xDirection", direction.x);
        this.animator.SetFloat("yDirection", direction.y);
    }
}
