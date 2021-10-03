using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SystemPanel : MonoBehaviour {

    private MusicManager musicManager;
    private SfxManager sfxManager;
    [SerializeField]
    public Slider slider;
    [SerializeField]
    public AudioClip MenuBoopClip;

    private void Start() {
        musicManager = FindObjectOfType<MusicManager>();
        sfxManager = FindObjectOfType<SfxManager>();
        slider.value = musicManager.GetCurrentVolume();
    }

    public void StartGame() {
        sfxManager.PlayEffect(MenuBoopClip);
        SceneManager.LoadScene("Boss Room");
    }

    public void AdjustVolume() {
        musicManager.SetVolume(slider.value);
        sfxManager.SetVolume(slider.value);
    }
}
