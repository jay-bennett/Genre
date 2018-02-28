using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CollectCoin : MonoBehaviour {

    public GameObject playerController;
    public GameObject UIController;
    public GameObject coinAudioController;

    void OnTriggerEnter2D(Collider2D col) {
        if(col.name == "Player")
        {
            Destroy(gameObject);

            UIController.GetComponent<UIFunctions>().setScore(playerController.GetComponent<PlayerController>().score += 100);
            UIController.GetComponent<UIFunctions>().setCoins(playerController.GetComponent<PlayerController>().coins += 1);
            coinAudioController.GetComponent<AudioSource>().Play();
        }
    }
}
