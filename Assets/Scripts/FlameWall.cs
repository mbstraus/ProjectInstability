using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameWall : MonoBehaviour
{
    [SerializeField]
    public float flameWallLineCooldownMinSec = 25f;
    [SerializeField]
    public float flameWallLineCooldownMaxSec = 35f;
    [SerializeField]
    public float timeBetweenLineSegments = 1f;

    private FlameWallSegment[] flameWallSegments;
    private float flameWallLineCooldownRemaining = 0f;

    // Start is called before the first frame update
    void Awake() {
        flameWallSegments = GetComponentsInChildren<FlameWallSegment>();
    }

    private void OnEnable() {
        StartFlameWallLineCooldown(0f);
    }

    // Update is called once per frame
    void Update() {
        if (flameWallLineCooldownRemaining <= 0f) {
            DoFlameWallLineAttack();
        } else {
            flameWallLineCooldownRemaining -= Time.deltaTime;
        }
    }

    private void StartFlameWallLineCooldown(float additionalTime) {
        flameWallLineCooldownRemaining = Random.Range(flameWallLineCooldownMinSec, flameWallLineCooldownMaxSec) + additionalTime;
    }

    private void DoFlameWallLineAttack() {
        float attackDelay = 0f;
        foreach (var segment in flameWallSegments) {
            segment.DoFlameWallLineAttack(attackDelay);
            attackDelay += timeBetweenLineSegments;
        }
        StartFlameWallLineCooldown(attackDelay + timeBetweenLineSegments);
    }
}
