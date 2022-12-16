using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button2: MonoBehaviour {
    // Start is called before the first frame update

    Vector3 ogSize;
    void Start () {
        ogSize = transform.localScale;
    }

    // Update is called once per frame
    public void Clicked () {
        SceneManager.LoadScene (2);
    }

    public void ScaleUp () {
        LeanTween.scale (gameObject, ogSize * 1.3f, .25f).setEaseOutCubic ();
    }

    public void ScaleDown () {
        LeanTween.scale (gameObject, ogSize, .25f).setEaseInCubic ();
    }
}
