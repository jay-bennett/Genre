using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour {

    public GameObject player;
    public GameObject playerAudioController;

    public GameObject UIController;
    public GameObject heartPrefab;

    public AudioClip hitSound;

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.name.Contains("Bullet")) {
            Destroy(gameObject);
            Destroy(col.gameObject);

            player.GetComponent<PlayerController>().bulletList.Remove(col.gameObject);

            if (!Globals.invaderCredits)
            {
                UIController.GetComponent<UIFunctions>().setScore(player.GetComponent<PlayerController>().score += 50);

                int x = Random.Range(0, 10);

                if (x >= 0 && x <= 1)
                { //10% chance
                    GameObject heart = Instantiate(heartPrefab);
                    heart.GetComponent<Transform>().position = new Vector2(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y + 1.0f);
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            Destroy(gameObject);
            if (!Globals.invaderCredits)
            {
                playerAudioController.GetComponent<AudioSource>().clip = hitSound;
                playerAudioController.GetComponent<AudioSource>().Play();
                UIController.GetComponent<UIFunctions>().setHealth(player.GetComponent<PlayerController>().health - 1);
            }
        }
    }
}
