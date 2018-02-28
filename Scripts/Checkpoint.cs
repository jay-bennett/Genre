using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    public GameObject playerController;
    public GameObject UIController;
    public GameObject achievementAudioController;
    public GameObject musicAudioController;

    public float x;
    public float y;

    public Vector2 position;

    public bool activated;

    public Sprite checkpoint_2;

    public AudioClip checkpointSound;

    void Start() {
        x = GetComponent<Transform>().position.x;
        y = GetComponent<Transform>().position.x;
        position = GetComponent<Transform>().position;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.name == "Player") {
            UIController.GetComponent<UIFunctions>().setHealth(3);
            if (!activated)
            {
                playerController.GetComponent<PlayerController>().currentCheckpoint = gameObject;
                GetComponent<SpriteRenderer>().sprite = checkpoint_2;
                activated = true;
                musicAudioController.GetComponent<AudioSource>().Pause();
                achievementAudioController.GetComponent<AudioSource>().clip = checkpointSound;
                achievementAudioController.GetComponent<AudioSource>().Play();
                musicAudioController.GetComponent<AudioSource>().UnPause();
                UIController.GetComponent<UIFunctions>().setScore(playerController.GetComponent<PlayerController>().score + 500);
            }
        }
    }

}
