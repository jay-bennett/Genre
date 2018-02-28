using UnityEngine;
using System.Collections;

public class OrbCollision : MonoBehaviour {

    public GameObject states;
    public GameObject playerController;

    public int orbMode;

	void OnTriggerEnter2D(Collider2D col) {

        if(col.gameObject.name == "Player") {
            if (orbMode == 0)
                states.GetComponent<States>().characterState = CharacterState.Normal;
            else if (orbMode == 1)
                states.GetComponent<States>().characterState = CharacterState.Invader;
        }

    }
}
