using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

    public Canvas canvas;
    
    bool paused;

    public void togglePause() {
        paused = !paused;

        canvas.enabled = !canvas.enabled;

        if(paused)
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        else
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void pause() {
        paused = true;
        canvas.enabled = true;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void GOPause() {
        paused = true;
        canvas.enabled = false;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public bool isPaused() {
        return paused;
    }

    void Start()
    {
        canvas.enabled = false;
    }

}
