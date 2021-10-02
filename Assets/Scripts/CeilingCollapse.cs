using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingCollapse : MonoBehaviour
{
    private Animator animator;
    private PlayerStatus collidingObject;
    [SerializeField]
    public CeilingCollapseAnimation AttackAnimationPrefab;

    void Start() {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoAttack() {
        if (collidingObject != null) {
            collidingObject.TakeDamage(1);
        }
        Instantiate(AttackAnimationPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        collidingObject = collision.gameObject.GetComponent<PlayerStatus>();
    }

    private void OnTriggerExit2D(Collider2D collision) {
        collidingObject = null;
    }
}
