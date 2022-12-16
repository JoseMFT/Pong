using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Marcador: MonoBehaviour {
    // Start is called before the first frame update
    int golesJugador1, golesJugador2;
    public static Marcador instance;

    [SerializeField]
    TextMeshProUGUI puntuacion;

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
        if (golesJugador1 >= 7 || golesJugador2 >= 7) {
            SceneManager.LoadScene (0);
        }
    }

    public void GolP1 () {
        ++golesJugador1;
        puntuacion.text = golesJugador1.ToString () + " - " + golesJugador2.ToString ();
        //Bola.behavior.SentidoDer ();
    }

    public void GolP2 () {
        ++golesJugador2;
        puntuacion.text = golesJugador1.ToString () + " - " + golesJugador2.ToString ();
        //Bola.behavior.SentidoIzq ();
    }


}

//resultadoJugadorDos.text = golesJugador2.ToString();