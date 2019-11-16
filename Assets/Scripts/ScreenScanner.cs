using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenScanner : MonoBehaviour {

    void Awake() {
        Application.targetFrameRate = 60;

        var rect = GetComponent<RectTransform>().rect;
        ScreenAdapter.Setup(rect.width, rect.height, Screen.width, Screen.height);
        WorldConstant.Setup();
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
