using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature2Controller : MonoBehaviour
{
    // Control fields
    private float horizontalInput;
    public float jumpForce = 10f;
    public float speed = 10f;

    // Location fields
    public bool onGround;
    public float bounds = 15;
    
    // Physics
    private Rigidbody playerRb;
    public float gravityModifier;
    public float foodBumpStrength = 10;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector3.right * speed * Time.deltaTime);

        // Keep the player in bounds
        if (transform.position.x < -bounds) {
            transform.position = new Vector3(-bounds, transform.position.y, transform.position.z);
        }
        if (transform.position.x > bounds) {
            transform.position = new Vector3(bounds, transform.position.y, transform.position.z);
        }

        // Jump
        if (Input.GetKeyDown("space") && onGround == true) {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
        } 
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            onGround = true;
        }
        if (collision.gameObject.CompareTag("Food1")) {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * foodBumpStrength, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Food2")) {
            Destroy(other.gameObject);
        } 
    }
}
