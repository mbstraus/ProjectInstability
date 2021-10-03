using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField]
    public float ShotSpeed = 5f;
    public Vector2 ShotDirection = Vector2.up;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + ShotDirection * ShotSpeed * Time.fixedDeltaTime);
    }

    void destroyShot() {
        Destroy(transform.parent.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        animator.SetBool("Is Destroying", true);
    }
}
