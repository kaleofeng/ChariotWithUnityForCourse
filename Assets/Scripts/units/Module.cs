using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Module : MonoBehaviour {

    public bool On { get; private set; } = false;
    private bool active = false;

    // Start is called before the first frame update
    void Start() {
        On = false;
        active = false;
        transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update() {

    }

    public void Activate() {
        if (!active) {
            active = true;
            transform.DOScale(new Vector3(1, 1, 1), 2f).OnComplete(() => On = true);
        }
    }

    public void Deactivate() {
        if (active) {
            active = false;
            transform.DOScale(new Vector3(0, 0, 0), 2f).OnComplete(() => On = false);
        }
    }
}
