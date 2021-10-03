using UnityEngine;
using TMPro;

public class TipsPanel : MonoBehaviour
{
    private string[] Tips = new string[] {
        "Tip: You have sent your trusty fire-fighting robot into a burning (and seriously unstable) house. Your goal - put out the fire before it spreads any further!",
        "Tip: To move, use the W (up), A (left), S (down), and D (right) keys.  To shoot, use the arrow keys (of course there's not much point in shooting anywhere put left, at least in this version).",
        "Tip: Shoot at the flames on the left-hand side of the screen.  Once a flame reaches 0 HP, it will turn into a puddle!  But leave it alone too long...",
        "Tip: The flames will attack you occasionally, indicated by the big scary red lines on the screen.  Remember, don't stand in the red!",
        "Tip: You are in a collapsing building, remember... so beware of the collapsing roof!",
        "Tip: Once the red on the floor disappears, it is safe to move into that spot, even while the animation is still playing (I've been playing way too much Final Fantasy XIV...)",
        "Tip: You only have 3 HP, and no means of recovery, so don't stand in the red!",
        "Tip: I wouldn't recommend standing in multiple red areas at the same time... it might be hazardous to your health.",
        "Tip: When in doubt, git gud."
    };
    private int CurrentTip = 0;

    private SfxManager sfxManager;
    [SerializeField]
    public TextMeshProUGUI TipsText;
    [SerializeField]
    public AudioClip MenuBoopClip;

    // Start is called before the first frame update
    void Start()
    {
        TipsText.text = Tips[CurrentTip];
        sfxManager = FindObjectOfType<SfxManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextTip() {
        CurrentTip++;
        if (CurrentTip >= Tips.Length) {
            CurrentTip = 0;
        }
        TipsText.text = Tips[CurrentTip];
        sfxManager.PlayEffect(MenuBoopClip);
    }

    public void PreviousTip() {
        CurrentTip--;
        if (CurrentTip < 0) {
            CurrentTip = Tips.Length - 1;
        }
        TipsText.text = Tips[CurrentTip];
        sfxManager.PlayEffect(MenuBoopClip);
    }
}
