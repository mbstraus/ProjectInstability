using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField]
    public int HitPoints = 3;
    [SerializeField]
    public TextMeshProUGUI HpIndicator;
    [SerializeField]
    public AudioClip TakeDamageAudioClip;

    private SfxManager sfxManager;

    void Start() {
        HpIndicator.text = "HP: " + HitPoints;
        sfxManager = FindObjectOfType<SfxManager>();
    }

    void Update() {
        if (HitPoints <= 0) {
            // I'm just going to put this in here for now, hopefully replace it with an animation
            // but probably won't.
            SceneManager.LoadScene("Game Over");
        }
    }

    public void TakeDamage(int damageAmount) {
        HitPoints -= damageAmount;
        HpIndicator.text = "HP: " + HitPoints;
        sfxManager.PlayEffect(TakeDamageAudioClip);
    }
}
