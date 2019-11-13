using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour {

    public GameObject shield;
    public GameObject weapon;
    public Slider healthSlider;

    // Start is called before the first frame update
    void Start() {
        shield.GetComponent<Module>().Activate();
        weapon.GetComponent<Module>().Activate();
    }

    // Update is called once per frame
    void Update() {

    }
}
