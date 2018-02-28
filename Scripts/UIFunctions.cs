using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIFunctions : MonoBehaviour {

    public GameObject playerController;
    public GameObject scoreText;
    public GameObject coinText;
    public GameObject livesText;
    public GameObject customText;

    public GameObject heart1Image;
    public GameObject heart2Image;
    public GameObject heart3Image;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    float timeLength = 0;

    void Update() {
        if(customText.GetComponent<Text>().text != "") {
            timeLength -= Time.deltaTime;
            if(timeLength < 0) {
                customText.GetComponent<Text>().text = "";
            }
        }
    }

   public void setScore(int score) {
        string s = "Score: " + score.ToString();
        scoreText.GetComponent<Text>().text = s;
        playerController.GetComponent<PlayerController>().score = score;
    }

    public void setCoins(int coins)
    {
        string s = coins.ToString();
        coinText.GetComponent<Text>().text = s;
        playerController.GetComponent<PlayerController>().coins = coins;
    }

    public void setLives(int lives)
    {
        string s = lives.ToString();
        livesText.GetComponent<Text>().text = s;
        playerController.GetComponent<PlayerController>().lives = lives;
    }

    public void setHealth(int health) {
        playerController.GetComponent<PlayerController>().health = health;

        if (health == 0)
        {

            heart1Image.GetComponent<Image>().sprite = emptyHeart;
            heart2Image.GetComponent<Image>().sprite = emptyHeart;
            heart3Image.GetComponent<Image>().sprite = emptyHeart;
            playerController.GetComponent<PlayerController>().killPlayer();

        } else if (health == 1) {

            heart1Image.GetComponent<Image>().sprite = fullHeart;
            heart2Image.GetComponent<Image>().sprite = emptyHeart;
            heart3Image.GetComponent<Image>().sprite = emptyHeart;

        } else if (health == 2) {

            heart1Image.GetComponent<Image>().sprite = fullHeart;
            heart2Image.GetComponent<Image>().sprite = fullHeart;
            heart3Image.GetComponent<Image>().sprite = emptyHeart;

        } else if (health == 3) {

            heart1Image.GetComponent<Image>().sprite = fullHeart;
            heart2Image.GetComponent<Image>().sprite = fullHeart;
            heart3Image.GetComponent<Image>().sprite = fullHeart;

        }
    }

    public void drawText(string text, float length) {
        customText.GetComponent<Text>().text = text;
        timeLength = length;
    }
}
