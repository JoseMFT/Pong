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

    public int objetivoGoles = 1;

    [SerializeField]
    TextMeshProUGUI puntuacion, textoFinal;

    private void Awake () {
        if (Marcador.instance == null) {
            Marcador.instance = this;
        } else {
            Destroy (this);
        }
    }
    void Start () {
        golesJugador1 = golesJugador2 = 0;

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
        ++golesJugador1;
        puntuacion.text = golesJugador1.ToString () + " - " + golesJugador2.ToString ();
        //Bola.behavior.SentidoDer ();
    }

    public void GolP2 () {
        scored = true;
        ++golesJugador2;
        puntuacion.text = golesJugador1.ToString () + " - " + golesJugador2.ToString ();
        //Bola.behavior.SentidoIzq ();
    } 
}
