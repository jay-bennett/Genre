using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScrollCredits : MonoBehaviour {

    public Text text;
    public GameObject text2;
    public GameObject text3;

    public PlayerController player;

    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "icredits") Globals.invaderCredits = true;

        if (SceneManager.GetActiveScene().name == "credits")
        {
            text2.SetActive(false);
            text3.SetActive(false);
        }

        player = FindObjectOfType<PlayerController>();
    }

	void Update() {
        if (SceneManager.GetActiveScene().name != "icredits")
        {
            if (text.GetComponent<Transform>().position.y > Screen.height * 2)
            {
                text2.SetActive(true);
                text3.SetActive(true);
            }
            else if (text.GetComponent<Transform>().position.y <= Screen.height * 2)
            {

                text.GetComponent<Transform>().position = new Vector2(text.GetComponent<Transform>().position.x, text.GetComponent<Transform>().position.y + 0.75f);
            }
        }
        else {
            if(player.getPosY() >= 3.5) {
                player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
            }
        }
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Globals.invaderCredits = false;
            SceneManager.LoadScene("main");
        }
    }
}
