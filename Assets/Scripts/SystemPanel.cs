using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemPanel : MonoBehaviour {

    public void StartGame() {
        SceneManager.LoadScene("Boss Room");
    }
}
