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
    public float TimeBetweenZoneIncrease = 30f;
    [SerializeField]
    public int ZonesToAddPerIncrease = 1;
    [SerializeField]
    public CeilingCollapse CeilingCollapsePrefab;

    private float SpawnCooldownRemaining = 0f;
    private float TimeToZoneIncrease = 0f;
    private int ZonesPerCollapse = 1;


    void Start() {
        SpawnCooldownRemaining = SpawnCooldown;
        TimeToZoneIncrease = TimeBetweenZoneIncrease;
    }

    void Update() {
        if (SpawnCooldownRemaining <= 0f) {
            SpawnCeilingCollapse();
            SpawnCooldownRemaining = SpawnCooldown;
        } else {
            SpawnCooldownRemaining -= Time.deltaTime;
        }
        if (TimeToZoneIncrease <= 0f) {
            ZonesPerCollapse += ZonesToAddPerIncrease;
            TimeToZoneIncrease = TimeBetweenZoneIncrease;
        } else {
            TimeToZoneIncrease -= Time.deltaTime;
        }

    }

    private void SpawnCeilingCollapse() {
        for (var i = 0; i < ZonesPerCollapse; i++) {
            Vector3 spawnLocation = new Vector3(Random.Range(SpawnRangeMinX, SpawnRangeMaxX),
                Random.Range(SpawnRangeMinY, SpawnRangeMaxY),
                0f);
            Instantiate(CeilingCollapsePrefab, spawnLocation, Quaternion.identity, gameObject.transform);
        }
    }
}
