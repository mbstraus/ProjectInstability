using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineAttackMarker : MonoBehaviour
{
    private Animator animator;
    private PlayerStatus collidingObject;
    [SerializeField]
    private FlameWallAttackAnimation AttackAnimationPrefab;
    [SerializeField]
    private AudioClip AttackClip;

    private SfxManager sfxManager;

    private void Awake() {
        animator = GetComponent<Animator>();
        sfxManager = FindObjectOfType<SfxManager>();
    }

    private void OnEnable() {
        animator.Play("LineAttack", -1, 0f);
    }

    public void DoAttack() {
        if (collidingObject != null) {
            collidingObject.TakeDamage(1);
        }
        gameObject.SetActive(false);
        Instantiate(AttackAnimationPrefab, gameObject.transform.parent);
        sfxManager.PlayEffect(AttackClip);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        collidingObject = collision.gameObject.GetComponent<PlayerStatus>();
    }

    private void OnTriggerExit2D(Collider2D collision) {
        collidingObject = null;
    }
}
