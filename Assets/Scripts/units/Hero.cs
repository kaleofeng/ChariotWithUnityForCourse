using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour {

    public GameObject shield;
    public GameObject weapon;
    public Slider healthSlider;

    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start() {
        boxCollider = transform.GetComponent<BoxCollider2D>();
        shield.GetComponent<Module>().Activate();
        weapon.GetComponent<Module>().Activate();
    }

    // Update is called once per frame
    void Update() {

    }

    public void Move(Vector3 translation) {
        transform.Translate(translation, Space.World);
        CheckPosition();
    }

    private void CheckPosition() {
        var x = transform.position.x;
        var y = transform.position.y;
        var z = transform.position.z;

        var width = boxCollider.bounds.size.x;
        var height = boxCollider.bounds.size.y;

        var minX = WorldConstant.LeftRoadX + width / 2;
        var maxX = WorldConstant.RightRoadX - width / 2;
        var minY = WorldConstant.BottomRoadY + height / 2;
        var maxY = WorldConstant.TopRoadY - height / 2;

        x = Mathf.Max(minX, x);
        x = Mathf.Min(maxX, x);
        y = Mathf.Max(minY, y);
        y = Mathf.Min(maxY, y);
        transform.position = new Vector3(x, y, z);
    }
}
