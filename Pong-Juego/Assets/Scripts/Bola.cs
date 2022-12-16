using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bola: MonoBehaviour {

    //public static Bola behavior;
    int sentido = 1;
    public Vector3 direction;
    bool movement = true;
    float speed = 2f, initialSpeed;

    [SerializeField]
    GameObject scoreAnimation;

    // Start is called before the first frame update
    void Start () {
        initialSpeed = speed;
        ResetGoal ();

    }

    // Update is called once per frame
    void Update () {
        if (movement == true) {
            transform.position += direction * Time.deltaTime * speed;
        }
    }

    private void OnCollisionEnter2D (Collision2D collision) {

        Debug.Log ("Ha chocado con: " + collision.collider.gameObject.name);

        if (collision.gameObject.tag == "Player") {
            speed += (float) Mathf.Sqrt (speed) / speed;
            direction.x = -1f * direction.x;
            direction.y = Random.Range (-1f, 1f);
        }

        if (collision.gameObject.tag == "Borders") {
            direction.y = -1f * direction.y;
        }
    }

    private void OnTriggerEnter2D (Collider2D collision) {

        if (collision.gameObject.tag == "P1") {
            Marcador.instance.GolP2 ();
            sentido = -1;
            Scored ();

        } else if (collision.gameObject.tag == "P2") {
            Marcador.instance.GolP1 ();
            sentido = 1;
            Scored ();
        }
    }

    public void Scored () {
        transform.Translate (Vector3.zero, Space.World);
        movement = false;
        gameObject.GetComponent<SpriteRenderer> ().enabled = false;
        scoreAnimation.SetActive (true);
        LeanTween.rotate (scoreAnimation, new Vector3 (0f, 360f, 0f), 1f).setEaseOutCubic ();
        LeanTween.moveLocalY (scoreAnimation, 0f, .75f).setEaseOutCubic ();
        LeanTween.scale (scoreAnimation, Vector3.one * 3f, 1.5f).setEaseOutCubic ().setOnComplete (() => {
            LeanTween.scale (scoreAnimation, Vector3.one, .5f).setEaseInCubic ();
            LeanTween.alpha (scoreAnimation, 0f, .35f).setEaseOutCubic ().setOnComplete (() => {
                ResetGoal ();
                gameObject.GetComponent<SpriteRenderer> ().enabled = true;
                movement = true;
            });
        });
    }

    public void ResetGoal () {
        speed = initialSpeed;
        transform.position = Vector3.zero;
        direction = Vector3.right * sentido;
        LeanTween.alpha (scoreAnimation, 1f, 0.1f);
        LeanTween.moveLocalY (scoreAnimation, -50f, .01f);
        LeanTween.rotate (scoreAnimation, Vector3.zero, .01f);
        scoreAnimation.SetActive (false);
    }

    public void SentidoIzq () {
        sentido = -1;
    }

    public void SentidoDer () {
        sentido = 1;
    }
}
