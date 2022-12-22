using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement: MonoBehaviour {

    [SerializeField]
    KeyCode buttonUp;

    [SerializeField]
    KeyCode buttonDown;

    public float speed = 6f, initialSpeed;

    void Start () {
        initialSpeed = speed;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKey (buttonUp)) {
            transform.position += Vector3.up * speed * Time.deltaTime;
        } else if (Input.GetKey (buttonDown)) {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

        if (transform.position.y > 3.8f) {
            transform.position = new Vector3 (transform.position.x, 3.79f, transform.position.z);
        } else if (transform.position.y < -3.8f) {
            transform.position = new Vector3 (transform.position.x, -3.79f, transform.position.z);
        }

        if (Marcador.instance.scored == true) {
            speed = initialSpeed;
            Marcador.instance.scored = false;
        }
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if (speed < 8f) {
            speed += (float) Mathf.Sqrt (speed) / (speed + 1);
        }
    }
}
