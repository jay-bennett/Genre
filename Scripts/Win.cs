using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Win : MonoBehaviour {

	public GameObject achievementAudioController;
    public GameObject musicAudioController;
    public GameObject UIController;
    public GameObject playerController;
    public GameObject states;

    public Sprite win_2;

    public AudioClip winSound;

    public float newPosX;
    public float newPosY;

    bool activated = false;
    float time = 0f;

    public bool finalLevel = false;


    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == "Player")
        {
            GetComponent<SpriteRenderer>().sprite = win_2;

            UIController.GetComponent<UIFunctions>().setHealth(3);
            states.GetComponent<States>().characterState = CharacterState.Other;

            playerController.GetComponent<PlayerController>().setVelocity(0, 0);
            playerController.GetComponent<SpriteRenderer>().sprite = playerController.GetComponent<PlayerController>().char_s;

            musicAudioController.GetComponent<AudioSource>().Stop();
            achievementAudioController.GetComponent<AudioSource>().clip = winSound;
            achievementAudioController.GetComponent<AudioSource>().Play();

            activated = true;
        }
    }

    void Update() {
        if(activated) {
            time += Time.deltaTime;

            if (finalLevel) {
                if(time >= 3.0f) SceneManager.LoadScene("icredits");
            } else { 


                if (time >= 3.0f)
                {
                    playerController.GetComponent<PlayerController>().setPosition(newPosX, newPosY);
                    states.GetComponent<States>().characterState = CharacterState.Normal;
                    musicAudioController.GetComponent<AudioSource>().Play();
                    Destroy(gameObject);
                }
            }
        }
    }

}
