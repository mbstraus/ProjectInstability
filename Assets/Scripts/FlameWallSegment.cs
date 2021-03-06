using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameWallSegment : MonoBehaviour
{
    [SerializeField]
    public int MaxHitPoints = 1;
    [SerializeField]
    public float HitPointHealCooldownSec = 5f;
    [SerializeField]
    public LineAttackMarker lineAttackMarker;
    [SerializeField]
    private AudioClip DouseClip;
    [SerializeField]
    private AudioClip RekindleClip;

    private SfxManager sfxManager;
    private bool isAttacking = false;
    private float timeToNextAttack = 0f;
    private float timeToHitPointHeal = 0f;
    private Animator animator;
    public int HitPoints = 99;

    void Awake() {
        animator = GetComponent<Animator>();
        HitPoints = MaxHitPoints;
        timeToHitPointHeal = HitPointHealCooldownSec;
    }

    private void Start() {
        sfxManager = FindObjectOfType<SfxManager>();
    }

    void Update() {
        if (HitPoints <= 0) {
            animator.SetBool("Is Doused", true);
        } else {
            animator.SetBool("Is Doused", false);
        }
        if (isAttacking) {
            if (timeToNextAttack <= 0f) {
                lineAttackMarker.gameObject.SetActive(true);
                isAttacking = false;
            } else {
                timeToNextAttack -= Time.deltaTime;
            }
        }
        if (timeToHitPointHeal <= 0f) {
            if (HitPoints == 0) {
                sfxManager.PlayEffect(RekindleClip);
            }
            HitPoints = Mathf.Min(HitPoints + 1, MaxHitPoints);
            timeToHitPointHeal = HitPointHealCooldownSec;
        } else {
            timeToHitPointHeal -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player Shot")) {
            HitPoints = Mathf.Max(HitPoints - 1, 0);
            timeToHitPointHeal = HitPointHealCooldownSec;
            if (HitPoints <= 0) {
                sfxManager.PlayEffect(DouseClip);
            }
        }
    }

    public void DoFlameWallLineAttack(float delay) {
        isAttacking = true;
        timeToNextAttack = delay;
    }
}
