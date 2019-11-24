using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour {

    public Transform road1;
    public Transform road2;

    private float road1PosY;
    private float road2PosY;
    private float diffPosY;

    // Start is called before the first frame update
    void Start() {
        road1PosY = road1.position.y;
        road2PosY = road2.position.y;
        diffPosY = road2PosY - road1PosY;
    }

    // Update is called once per frame
    void Update() {
        if  (!GameWorld.Instance.IsRunning()) {
            return;
        }

        var deltaY = 500 * Time.deltaTime;
        var deltaPos = Vector3.down * deltaY;
        road1.Translate(deltaPos, Space.World);
        road2.Translate(deltaPos, Space.World);

        var lowerRoad = road1.position.y < road2.position.y ? road1 : road2;
        if (lowerRoad.position.y - road1PosY <= -diffPosY) {
            lowerRoad.position += new Vector3(0, diffPosY * 2, 0);
        }
    }
}
