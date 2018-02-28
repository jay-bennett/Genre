using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour {

    public GameObject playerAudioController;
    public AudioClip hitSound;

    UIFunctions UIController;

    void Awake() {
        UIController = FindObjectOfType<UIFunctions>();
    }

	void OnTriggerEnter2D(Collider2D col) {
        if (col.name == "Player") {
            playerAudioController.GetComponent<AudioSource>().clip = hitSound;
            playerAudioController.GetComponent<AudioSource>().Play();
            UIController.setHealth(0);
        }
    }
}
