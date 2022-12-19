using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU : MonoBehaviour
{

    [SerializeField]
    GameObject bola;

    public float speed = 1.75f, initialSpeed;

    void Start () {
        initialSpeed = speed;
    }

    void Update()
    {
        if (transform.position.y < bola.transform.position.y - .55f) {
            transform.position += Vector3.up * speed * Time.deltaTime;

        } else if (transform.position.y > bola.transform.position.y + .55f) {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

        if (transform.position.y > 3.8f) {
            transform.position = new Vector3 (transform.position.x, 3.79f, transform.position.z);
        } else if (transform.position.y < -3.8f) {
            transform.position = new Vector3 (transform.position.x, -3.79f, transform.position.z);
        }

        if (Marcador.instance.scored == true) {
            speed = initialSpeed;
        }
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        speed += (float) Mathf.Sqrt (speed) / (speed + 1.5f);
    }    
}
