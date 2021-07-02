using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntimateSpaceBehavior : MonoBehaviour {

    public Enemy relatedEnemy;

    float maxProxemicsTimer = 1f;
    float proxemicsTimer = 0;
    PlayerController currentPlayer;
    PersonalSpaceBehavior personalSpace;
    SocialSpaceBehavior socialSpace;

    // Use this for initialization
    void Start () {
        SetCurrentPlayer(null);
    }
	
	// Update is called once per frame
	void Update () {
        //float dt = Time.deltaTime;

        //if (currentPlayer && proxemicsTimer > maxProxemicsTimer) {
        //    relatedEnemy.DispatchPlayerState("is_social");

        //    proxemicsTimer = 0;
        //}

        //proxemicsTimer += dt;
    }

    /// <summary>
    /// Sets the current player.
    /// </summary>
    /// <param name="pObj">PlayerController object.</param>
    public void SetCurrentPlayer(PlayerController pObj) {
        currentPlayer = pObj;
    }

    /// <summary>
    /// Identify collision entring.
    /// </summary>
    /// <param name="collision">Who entered the trigger collision.</param>
    private void OnTriggerEnter2D(Collider2D collision) {
        //if (collision.CompareTag("Player")) {
        //    currentPlayer = collision.GetComponent<PlayerController>();
        //    personalSpace.SetCurrentPlayer(null);
        //}
        //else 
        if (collision.CompareTag("Bullet")) {
            Bullet b = collision.GetComponent<Bullet>();
            if (b.GetShotBy() == "Player") {
                float maxHealth = relatedEnemy.maxHealth;
                relatedEnemy.healthBar.fillAmount -= 5 / maxHealth;
                relatedEnemy.hasBeenShot = true;
                relatedEnemy.DispatchPlayerState("is_attacking");
                Destroy(collision.gameObject);
            }
        }
    }

    /// <summary>
    /// Identify collision exiting.
    /// </summary>
    /// <param name="collision">Who exited the trigger collision.</param>
    private void OnTriggerExit2D(Collider2D collision) {
        //if (collision.CompareTag("Player")) {
        //    PlayerController player = collision.GetComponent<PlayerController>();
        //    SetCurrentPlayer(null);
        //    socialSpace.SetCurrentPlayer(player);
        //}
    }
}
