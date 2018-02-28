using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour {

    public GameObject mainCanvas;
    public GameObject optionsCanvas;

    public void startGame() {
        SceneManager.LoadScene("game");
    }

    public void loadOptions() {
        mainCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
    }

    public void loadCredits() {
        SceneManager.LoadScene("credits");
        Globals.invaderCredits = true;
    }

    public void loadMenu() {
        SceneManager.LoadScene("main");
    }

    public void exitGame() {
        Application.Quit();
    }

}