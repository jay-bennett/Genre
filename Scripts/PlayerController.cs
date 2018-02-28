using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;

    public bool grounded = true;
    public bool super = false;
    public bool invincible = false;
    public bool stopFlying = false;

    public int score = 0;
    public int coins = 0;
    public int health = 3;
    public int lives = 5;
    
    public List<GameObject> bulletList = new List<GameObject>();

    SpriteRenderer sr;
    public Sprite char_s;
    public Sprite char_l;
    public Sprite char_r;
    public Sprite fly_s;
    public Sprite fly_l;
    public Sprite fly_r;

    public GameObject bulletPrefab;
    public GameObject UIController;
    public GameObject jumpAudioController;
    public GameObject shootAudioController;
    public GameObject playerAudioController;
    public GameObject currentCheckpoint;

    public AudioClip jump1;
    public AudioClip shootSound;
    public AudioClip dieSound;
    public AudioClip gameOverSound;

    public Canvas canvas;
    public Canvas GOCanvas;

    public PauseGame pauseObject;

    public States states;
    
    public void setVelocity(float x, float y) { GetComponent<Rigidbody2D>().velocity = new Vector2(x, y); }
    public void setVelocity(Vector2 vel) { GetComponent<Rigidbody2D>().velocity = vel; }
    public void setPosition(float x, float y) { GetComponent<Transform>().position = new Vector2(x, y); }
    public void setPosition(Vector2 pos) { GetComponent<Transform>().position = pos; }

    public float getVelX() { return GetComponent<Rigidbody2D>().velocity.x; }
    public float getVelY() { return GetComponent<Rigidbody2D>().velocity.y; }
    public Vector2 getVelocity() { return GetComponent<Rigidbody2D>().velocity; }

    public float getPosX() { return GetComponent<Transform>().position.x; }
    public float getPosY() { return GetComponent<Transform>().position.y; }
    public Vector2 getPosition() { return GetComponent<Transform>().position; }

    public void jump() {
        grounded = false;
        setVelocity(getVelX(), jumpHeight);
        jumpAudioController.GetComponent<AudioSource>().Play();
    }

    public void shoot() {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.GetComponent<Transform>().position = new Vector2(getPosX(), getPosY() + 1.0f);
        bulletList.Add(bullet);

        if (!super)
        {
            if (bulletList.Count > 3)
            {
                Destroy(bulletList[0]);
                bulletList.RemoveAt(0);
            }
        }
        shootAudioController.GetComponent<AudioSource>().Play();
    }

    public void updateBullets() {
        foreach (GameObject x in bulletList) {
            x.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 7.5f);
        }
    }

    public void killPlayer() {
        states.GetComponent<States>().characterState = CharacterState.Normal;

        if (lives != 0) {
            setVelocity(0f, 0f);
            setPosition(currentCheckpoint.GetComponent<Checkpoint>().position);
            UIController.GetComponent<UIFunctions>().setLives(lives - 1);
            UIController.GetComponent<UIFunctions>().setHealth(3);
            playerAudioController.GetComponent<AudioSource>().clip = dieSound;
            playerAudioController.GetComponent<AudioSource>().Play();
            
        } else {
            playerAudioController.GetComponent<AudioSource>().clip = gameOverSound;
            playerAudioController.GetComponent<AudioSource>().Play();

            pauseObject.GOPause();
            GOCanvas.enabled = true;            
        }
    }

    void Start() {
        sr = GetComponent<SpriteRenderer>();
        pauseObject = GetComponent<PauseGame>();
        GOCanvas.enabled = false;

        Globals.difficulty = Difficulty.Easy;



	}

    void Update()
    {
        if (!pauseObject.isPaused())
        {
            if ( (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse1)) && (Globals.currentLevel != 2 && Globals.currentLevel != 3))
            {
                if (SceneManager.GetActiveScene().name != "icredits")
                {
                    if (states.characterState == CharacterState.Normal)
                    {
                        states.characterState = CharacterState.Invader;
                    }
                    else {
                        states.characterState = CharacterState.Normal;

                        foreach (GameObject x in bulletList) { Destroy(x); }

                        bulletList.Clear();
                    }
                }
            }

            if (states.characterState == CharacterState.Normal)
            {

                if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Mouse0)) && grounded)
                {
                    jump();
                }

                if (Input.GetKey(KeyCode.A))
                {
                    setVelocity(-moveSpeed, getVelY());
                    sr.sprite = char_l;
                }

                if (Input.GetKey(KeyCode.D))
                {
                    setVelocity(moveSpeed, getVelY());
                    sr.sprite = char_r;
                }

                if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)) sr.sprite = char_s;

                if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && grounded) setVelocity(0, getVelY());
            }

            if (states.characterState == CharacterState.Invader)
            {


                if (Globals.invaderCredits)
                {
                    setVelocity(getVelX(), 3f);
                    //Camera camera = FindObjectOfType<Camera>();
                    //camera.GetComponent<Transform>().position = new Vector2(0 - getPosX(), 0);
                } 
                else if (!Globals.invaderCredits)
                {
                    setVelocity(getVelX(), 5f);
                }

                updateBullets();
                if (super) shoot();

                if (Input.GetKey(KeyCode.A))
                {
                    setVelocity(-moveSpeed, getVelY());
                    sr.sprite = fly_l;
                }

                if (Input.GetKey(KeyCode.D))
                {
                    setVelocity(moveSpeed, getVelY());
                    sr.sprite = fly_r;
                }

                if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)) sr.sprite = fly_s;

                if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)) setVelocity(0, getVelY());

                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Mouse0))
                {
                    shoot();
                }

            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseObject.togglePause();
        }
    }
}
