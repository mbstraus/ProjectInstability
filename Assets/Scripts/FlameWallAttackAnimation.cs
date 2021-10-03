using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameWallAttackAnimation : MonoBehaviour
{
    public void AnimationComplete() {
        Destroy(gameObject);
    }
}
