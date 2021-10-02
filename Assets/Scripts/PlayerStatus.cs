using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField]
    public int HitPoints = 3;

    void Start()
    {
        
    }

    void Update() {
        if (HitPoints <= 0) {
            Debug.Log("PLAYER DIED!");
        }
    }

    public void TakeDamage(int damageAmount) {
        HitPoints -= damageAmount;
    }
}
