using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Marcador: MonoBehaviour {
    // Start is called before the first frame update
    public int golesJugador1, golesJugador2;
    public bool scored = false;
    public static Marcador instance;
    Vector3 ogSizeScore;

    public int objetivoGoles = 1;

    [SerializeField]
    TextMeshProUGUI puntuacion, textoFinal;

    [SerializeField]
    GameObject cuadroPuntuacion;

    private void Awake () {
        if (Marcador.instance == null) {
            Marcador.instance = this;
        } else {
            Destroy (this);
        }
    }
    void Start () {
        golesJugador1 = golesJugador2 = 0;
        ogSizeScore = cuadroPuntuacion.transform.localScale;

    }

    // Update is called once per frame
    void Update () {
        if (golesJugador1 >= objetivoGoles || golesJugador2 >= objetivoGoles) {
            if (golesJugador1 > golesJugador2) {
                textoFinal.text = "Player 1 wins";
            } else if (golesJugador2 > golesJugador1) {
                textoFinal.text = "Player 2 wins";
            }
        }

    }

    public void GolP1 () {
        scored = true;
        LeanTween.scale (cuadroPuntuacion, Vector3.zero, .25f).setOnComplete (() => {
            LeanTween.scale (cuadroPuntuacion, ogSizeScore, 1f).setEaseOutBack ();
            puntuacion.text = golesJugador1.ToString () + " - " + golesJugador2.ToString ();
        });
        ++golesJugador1;
        //Bola.behavior.SentidoDer ();
    }

    public void GolP2 () {
        scored = true;
        ++golesJugador2;
        LeanTween.scale (cuadroPuntuacion, Vector3.zero, .25f).setOnComplete (() => {
            LeanTween.scale (cuadroPuntuacion, ogSizeScore, 1f).setEaseOutBack ();
            puntuacion.text = golesJugador1.ToString () + " - " + golesJugador2.ToString ();
        });
        //Bola.behavior.SentidoIzq ();
    }
}
