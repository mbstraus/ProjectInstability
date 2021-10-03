using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCeilingCollapse : MonoBehaviour {
    [SerializeField]
    public float SpawnRangeMinX = 0f;
    [SerializeField]
    public float SpawnRangeMaxX = 0f;
    [SerializeField]
    public float SpawnRangeMinY = 0f;
    [SerializeField]
    public float SpawnRangeMaxY = 0f;
    [SerializeField]
    public float SpawnCooldown = 15f;
    [SerializeField]
    public int ZonesToAddPerIncrease = 1;
    [SerializeField]
    public CeilingCollapse CeilingCollapsePrefab;
    [SerializeField]
    public float TimeBetweenCollapses = 0.25f;

    private float SpawnCooldownRemaining = 0f;
    private int ZonesPerCollapse = 1;
    private int queuedCollapses = 0;
    private float timeToNextCollapse = 0f;


    void Start() {
        SpawnCooldownRemaining = SpawnCooldown;
    }

    void Update() {
        if (SpawnCooldownRemaining <= 0f) {
            QueueCeilingCollapse();
            SpawnCooldownRemaining = SpawnCooldown;
        } else {
            SpawnCooldownRemaining -= Time.deltaTime;
        }
        if (queuedCollapses > 0) {
            if (timeToNextCollapse <= 0f) {
                DoCeilingCollapse();
                timeToNextCollapse = TimeBetweenCollapses;
            } else {
                timeToNextCollapse -= Time.deltaTime;
            }
        }
    }

    private void QueueCeilingCollapse() {
        queuedCollapses += ZonesPerCollapse;
        ZonesPerCollapse++;
    }

    private void DoCeilingCollapse() {
        Vector3 spawnLocation = new Vector3(Random.Range(SpawnRangeMinX, SpawnRangeMaxX),
            Random.Range(SpawnRangeMinY, SpawnRangeMaxY),
            0f);
        Instantiate(CeilingCollapsePrefab, spawnLocation, Quaternion.identity, gameObject.transform);
        queuedCollapses--;
    }
}
