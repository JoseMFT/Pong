using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpBehaviour: MonoBehaviour {

    float contador = 5f, tiempoVida;
    bool breakSpeedLimit = false;

    [SerializeField]
    Slider vidaPowerUp;

    [SerializeField]
    GameObject prefabBarra;
    // Start is called before the first frame update
    void Start () {
        tiempoVida = contador;
        var barrita = Instantiate (prefabBarra, new Vector3 (-303f, 196f, 0f), Quaternion.identity);
        prefabBarra.transform.parent = gameObject.transform;
    }

    // Update is called once per frame
    void Update () {
        if (breakSpeedLimit == true) {
            Bola.controlador.limitSpeed = true;
        }

        if (contador <= 0) {
            Bola.controlador.limitSpeed = false;
        }

        contador -= Time.deltaTime;
        vidaPowerUp.value -= Time.deltaTime / tiempoVida;
    }

    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.gameObject.tag == "Bola") {
            breakSpeedLimit = true;
            gameObject.GetComponent<MeshRenderer> ().enabled = false;
        }
    }
}
