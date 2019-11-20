using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barrier : Entity {

    public Sprite[] sprites = new Sprite[(int)EBarrierType.END];

    public EBarrierType Type { get; private set; }

    void Awake() {
        Family = EEntityFamily.BARRIER;
        State = EEntityState.LIVE;
        Way = -1;
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (!IsRunning()) {
            return;
        }

        if (!IsLive()) {
            return;
        }

        Move();
    }

    public void Morph(EBarrierType type) {
        Type = type;
        GetComponent<Image>().sprite = sprites[(int)Type - 1];
    }

    private void Move() {
        var deltaY = WorldConstant.BarrierYps * Time.deltaTime;
        var deltaPosY = Vector3.down * deltaY;
        transform.Translate(deltaPosY, Space.World);
    }
}
