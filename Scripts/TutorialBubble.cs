using UnityEngine;
using System.Collections;

public class TutorialBubble : MonoBehaviour {

    public string text;
    public float timeDelay;

    public GameObject UIController;

    public bool setNormal = false;
    public bool setInvader = false;

    public int currentLevel = 0;

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.name == "Player") {
            if (setNormal) FindObjectOfType<States>().characterState = CharacterState.Normal;
            if (setInvader) FindObjectOfType<States>().characterState = CharacterState.Invader;
            Globals.currentLevel = currentLevel;
            UIController.GetComponent<UIFunctions>().drawText(text, timeDelay);
        }
    }

}
