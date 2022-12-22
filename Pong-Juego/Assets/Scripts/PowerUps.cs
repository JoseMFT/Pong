using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps: MonoBehaviour {

    [SerializeField]
    Slider vidaSpeed, vidaDuplicado;

    [SerializeField]
    public GameObject barraSpeed, barraDuplicado, prefabSpeed, prefabDuplicado;

    float contadorVidaBarras;

    public static PowerUps manager;
    public bool hide = false, touchedSpeed = false, touchedDuplicado = false;

    private void Start () {
        contadorVidaBarras = Bola.controlador.contador;
    }


    float numRandom, contador = .5f;
    void Update () {

        if (hide == false) {
            if (contador > 0) {
                contador -= Time.deltaTime;
            } else if (contador <= 0) {
                numRandom = Random.Range (0f, 25f);
                contador = .5f;
            }
        }

        if (numRandom >= 0f && numRandom <= .25f) {
            var toDestroy = Instantiate (prefabSpeed, new Vector3 (Random.Range (-6f, 6f), 3.25f, 0f), Quaternion.identity);

        } else if (numRandom >= 24.75f && numRandom <= 25f) {
            var toDestroy = Instantiate (prefabDuplicado, new Vector3 (Random.Range (-6f, 6f), 3.25f, 0f), Quaternion.identity);
        }
    }
}
