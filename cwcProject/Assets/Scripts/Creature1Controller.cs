using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature1Controller : MonoBehaviour {
    // TODO CURRENT ISSUE WHEN TWO PLAYERS COLLIDE, VELOCITY DOESN'T RESET FOR FLYING GUY.

    // Control fields
    private float horizontalInput;
    private float verticalInput;
    public float speed = 10f;

    // Location fields
    private float xBounds = 15f;
    private float yUpperBounds = 20f;
    private float yLowerBounds = 0f;

    // Physics
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start() {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        // Movement
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Keep the player in bounds
        if (transform.position.x < -xBounds) {
            transform.position = new Vector3(-xBounds, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xBounds) {
            transform.position = new Vector3(xBounds, transform.position.y, transform.position.z);
        }
        if (transform.position.y > yUpperBounds) {
            transform.position = new Vector3(transform.position.x, yUpperBounds, transform.position.z);
        }
        if (transform.position.y < yLowerBounds) {
            transform.position = new Vector3(transform.position.x, yLowerBounds, transform.position.z);
        }
        if (transform.position.y < 0) {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }
}
