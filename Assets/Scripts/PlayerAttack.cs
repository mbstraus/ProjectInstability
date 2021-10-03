using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    public Shot ShotPrefab;
    [SerializeField]
    public Transform ShotParent;
    [SerializeField]
    public float ShotCooldown = 0.1f;
    [SerializeField]
    public AudioClip AttackAudioClip;

    private SfxManager sfxManager;
    private float shotCooldownRemaining = 0f;
    private Vector2 shotDirection = Vector2.zero;

    private void Start() {
        sfxManager = FindObjectOfType<SfxManager>();
    }

    private void Update() { 
        if (shotCooldownRemaining > 0f) {
            shotCooldownRemaining -= Time.deltaTime;
        } else if (shotDirection != Vector2.zero) {
            Shot shot = Instantiate(ShotPrefab, transform.position, Quaternion.identity, ShotParent);
            shot.SetShotDirection(shotDirection);
            shotCooldownRemaining = ShotCooldown;
            sfxManager.PlayEffect(AttackAudioClip);
        }
    }

    public void Fire(InputAction.CallbackContext callbackContext) {
        shotDirection = callbackContext.ReadValue<Vector2>();
    }
}
