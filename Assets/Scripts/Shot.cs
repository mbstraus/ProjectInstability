using UnityEngine;

public class Shot : MonoBehaviour
{
    private ShotMove shotMove;

    void Awake() {
        shotMove = GetComponentInChildren<ShotMove>();
    }

    public void SetShotDirection(Vector2 dir) {
        shotMove.ShotDirection = dir;
    }
}
