using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingCollapseAnimation : MonoBehaviour
{
    public void AnimationComplete() {
        Destroy(gameObject);
    }
}
