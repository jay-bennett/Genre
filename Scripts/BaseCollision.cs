using UnityEngine;
using System.Collections;

public class BaseCollision : MonoBehaviour {

    PlayerController player;
    public GameObject oneWayBase;

    public int oneWayID;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Player") {
            if (gameObject.name.Contains("onesided"))
            {
                if (oneWayID == 0) {
                    oneWayBase.GetComponent<BoxCollider2D>().isTrigger = false;
                } else {
                    oneWayBase.GetComponent<BoxCollider2D>().isTrigger = true;
                }
            }
            else {
                //player.setVelocity(player.getVelX(), 0);
                if (!player.grounded) player.grounded = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == "Player")
        {
            if (gameObject.name.Contains("onesided"))
            {
                if (oneWayID == 0)
                {
                    oneWayBase.GetComponent<BoxCollider2D>().isTrigger = false;
                }
                else {
                    oneWayBase.GetComponent<BoxCollider2D>().isTrigger = true;
                }
            }
        }
    }
}
