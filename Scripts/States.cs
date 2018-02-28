using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public enum CharacterState {
    Normal,
    Invader,
    Other
}

enum GameState {
    //Placeholder, may or may not use
}

public class States : MonoBehaviour {
    public CharacterState characterState = CharacterState.Invader;
	
    CharacterState getCharState() { return characterState; }
    void setCharState(CharacterState state) { characterState = state; }

    void Awake() {
        if(SceneManager.GetActiveScene().name == "icredits") {
            setCharState(CharacterState.Invader);
        }
    }
}
