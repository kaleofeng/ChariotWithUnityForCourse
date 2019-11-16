using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayController : MonoBehaviour {

    private Vector3 mousePositionLast;

    void Awake() {
        GameWorld.Instance.Setup(this);
    }

    void Start() {
        GameWorld.Instance.Start();
    }

    // Update is called once per frame
    void Update() {
        MouseOrTouchUpdate();

        GameWorld.Instance.Update();
    }

    private void MouseOrTouchUpdate() {
        if (Application.isMobilePlatform) {
            TouchUpdate();
        }
        else {
            MouseUpdate();
        }
    }

    private void MouseUpdate() {
        if (IsTouchedUI()) {
            return;
        }

        if (Input.GetMouseButtonDown(0)) {
            GameWorld.Instance.Resume();
            mousePositionLast = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0)) {
            GameWorld.Instance.Pause();
        }

        if (Input.GetMouseButton(0)) {
            var deltaPosition = Input.mousePosition - mousePositionLast;
            mousePositionLast = Input.mousePosition;
            TriggerMove(deltaPosition);
        }
    }

    private void TouchUpdate() {
        if (IsTouchedUI()) {
            return;
        }

        if (Input.touchCount == 1) {
            switch (Input.GetTouch(0).phase) {
                case TouchPhase.Began:
                    GameWorld.Instance.Resume();
                    break;
                case TouchPhase.Ended:
                    GameWorld.Instance.Pause();
                    break;
                case TouchPhase.Moved:
                    var deltaPosition = Input.GetTouch(0).deltaPosition;
                    TriggerMove(deltaPosition);
                    break;
                default: break;
            }
        }
    }

    private void TriggerMove(Vector3 deltaPosition) {
        GameWorld.Instance.Hero.Move(deltaPosition);
    }

    private bool IsTouchedUI() {
        if (Input.touchCount < 1) {
            return false;
        }

        if (Application.isMobilePlatform) {
            return EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);
        }
        else {
            return EventSystem.current.IsPointerOverGameObject();
        }
    }

}
