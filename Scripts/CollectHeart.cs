using UnityEngine;
using System.Collections;

public class CollectHeart : MonoBehaviour {

    public PlayerController playerController;
    public UIFunctions UIController;

    void Start() {
        playerController = FindObjectOfType<PlayerController>();
        UIController = FindObjectOfType<UIFunctions>();
    }

	void OnTriggerEnter2D(Collider2D col) {
        if (playerController.health != 3 && playerController.health > 0 && col.gameObject.name == "Player") {
            Destroy(gameObject);
            UIController.setHealth(playerController.health + 1);
        }
    }
}
