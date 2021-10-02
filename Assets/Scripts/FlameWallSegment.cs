using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameWallSegment : MonoBehaviour
{
    [SerializeField]
    public int HitPoints = 1;
    [SerializeField]
    private LineAttackMarker lineAttackMarker;
    public bool IsActive { get; set; }

    private bool isAttacking = false;
    private float timeToNextAttack = 0f;

    void Awake() {
        IsActive = true;
    }

    void Update() {
        if (HitPoints <= 0) {
            IsActive = false;
        }
        if (IsActive && isAttacking) {
            if (timeToNextAttack <= 0f) {
                lineAttackMarker.gameObject.SetActive(true);
                isAttacking = false;
            } else {
                timeToNextAttack -= Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player Shot") && IsActive) {
            HitPoints--;
        }
    }

    public void DoFlameWallLineAttack(float delay) {
        if (IsActive) {
            isAttacking = true;
            timeToNextAttack = delay;
        }
    }
}
