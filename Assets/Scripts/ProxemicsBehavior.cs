using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProxemicsBehavior : MonoBehaviour {

    public Enemy relatedEnemy;
    public float[] proxemicValues;
    public PlayerController currentPlayer;

    string[] proxemicStates;
    float maxProxemicsTimer = 0.5f;
    float proxemicsTimer = 0;
    List<GameObject> otherEnemies;

    private void Awake() {
        otherEnemies = new List<GameObject>();
    }

    // Use this for initialization
    void Start () {
        SetCurrentPlayer(null);
        proxemicValues = new float[3] { 0.7f, 0.45f, 0.25f };
        proxemicStates = new string[3] { "is_social", "is_personal", "is_intimate" };
    }
	
	// Update is called once per frame
	void Update () {
        float dt = Time.deltaTime;

        if (currentPlayer && proxemicsTimer > maxProxemicsTimer) {
            Vector2 playerPos = currentPlayer.gameObject.transform.position;
            float playerWidth = currentPlayer.width;
            float playerHeight = currentPlayer.height;
            playerPos.x += playerWidth / 2;
            playerPos.y += playerHeight / 2;

            Vector2 enemyPos = relatedEnemy.gameObject.transform.position;
            float playerDist = Vector2.Distance(playerPos, enemyPos);
            string currProxState = "";

            //Debug.Log(currProxState);
            for (int i=0; i< proxemicValues.Length; i++) {
                float currProxVal = proxemicValues[i];

                if (playerDist <= currProxVal) {
                    currProxState = proxemicStates[i];
                }
            }

            relatedEnemy.DispatchPlayerState(currProxState);

            if (currentPlayer.healthBar.fillAmount < 1) { 
                relatedEnemy.DispatchPlayerState("is_injured");
            }

            for (int i=0; i < otherEnemies.Count; i++) {
                GameObject obj = otherEnemies[i];
                Enemy enemy = obj.gameObject.GetComponent<Enemy>();
                if (enemy.hasBeenShot) {
                    relatedEnemy.DispatchPlayerState("is_harming");
                }
            }

            proxemicsTimer = 0;
        }

        proxemicsTimer += dt;
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
        if (collision.CompareTag("Player")) {
            currentPlayer = collision.GetComponent<PlayerController>();
        }
        else if (collision.CompareTag("Bullet")) {
            relatedEnemy.DispatchPlayerState("is_shooting");
        }
        else if (collision.CompareTag("Enemy")) {
            GameObject currEnemy = collision.gameObject;
            if (currEnemy) {
                otherEnemies.Add(currEnemy);
            }
        }
    }

    /// <summary>
    /// Identify collision exiting.
    /// </summary>
    /// <param name="collision">Who exited the trigger collision.</param>
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            SetCurrentPlayer(null);
        }
        else if (collision.CompareTag("Bullet")) {
            relatedEnemy.DispatchPlayerState("is_shooting");
        }
        else if (collision.CompareTag("Enemy")) {
            GameObject currEnemy = collision.gameObject;
            otherEnemies.Remove(currEnemy);
        }
    }


    /// <summary>
    /// Draw selected object's gizmos.
    /// </summary>
    void OnDrawGizmosSelected() {
        // Display the proxemics radius when the obj is selected in scene
        for (int i=0; i < proxemicValues.Length; i++) {
            float currRadius = proxemicValues[i];

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, currRadius);
        }
    }
}
