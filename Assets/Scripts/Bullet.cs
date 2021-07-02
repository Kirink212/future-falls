using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 2;
    public float maxLifeTime = 4;
    public string shotBy;

    Rigidbody2D bulletBody;
    Vector2 direction = new Vector2(1, 0);
    float timer = 0;

    /// <summary>
    /// Sets the direction.
    /// </summary>
    /// <param name="dirX">Dir x.</param>
    /// <param name="dirY">Dir y.</param>
    public void SetDirection(float dirX, float dirY) {
        direction.x = dirX;
        direction.y = dirY;
    }

    /// <summary>
    /// Sets the shot by.
    /// </summary>
    /// <param name="someone">Someone.</param>
    public void SetShotBy(string someone) {
        shotBy = someone;
    }

    /// <summary>
    /// Gets the shot by.
    /// </summary>
    /// <returns>The shot by.</returns>
    public string GetShotBy() {
        return shotBy;
    }

    // Use this for initialization
    void Start() {
        bulletBody = GetComponent<Rigidbody2D>();
        speed = 10;
        maxLifeTime = 2;
    }
	
	// Update is called once per frame
	void Update() {
        Vector2 position = bulletBody.position;
        float dt = Time.deltaTime;

        timer += dt;

        position.x += speed * direction.x * dt;
        position.y += speed * direction.y * dt;

        bulletBody.MovePosition(position);

        if (timer > maxLifeTime) {
            Destroy(gameObject);
        }
    }
}
