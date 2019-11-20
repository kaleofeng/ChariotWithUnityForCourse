using System.Collections;
using UnityEngine;

public abstract class Entity : MonoBehaviour {

    public EEntityFamily Family { get; protected set; } = EEntityFamily.NONE;

    public EEntityState State { get; protected set; } = EEntityState.LIVE;

    public int Way { get; set; } = -1;

    public int Jobs { get; set; } = 0;

    public bool IsLive() {
        return State <= EEntityState.LIVE;
    }

    public void SwitchState(EEntityState state) {
        State = state;

        switch (State) {
            case EEntityState.DEAD:
                transform.localScale = new Vector3(0, 0, 0);
                break;
            default: break;
        }
    }

    public bool IsBusy() {
        return Jobs > 0;
    }

    public void IncJobs() {
        ++Jobs;
    }

    public void DecJobs() {
        --Jobs;
    }

    public bool IsRunning() {
        return GameWorld.Instance.IsRunning();
    }
}
