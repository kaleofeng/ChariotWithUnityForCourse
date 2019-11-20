using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWorld {

    public static GameWorld Instance { get; private set; } = new GameWorld();

    public PlayController Stage { get; private set; }
    public Hero Hero { get; private set; }
    public EntityManager<Barrier> BarrierManager { get; private set; }

    private WorldCreator creator;

    private EGameState state;

    public void Setup(PlayController playController) {
        Stage = playController;
        creator = new WorldCreator();
        creator.Setup(this, Stage);
    }

    public void Start() {
        Hero = Stage.GetComponentInChildren<Hero>();
        BarrierManager = new EntityManager<Barrier>();

        state = EGameState.PAUSE;
    }

    public void Update() {
        if (!IsRunning()) {
            return;
        }

        creator.Update();
        BarrierManager.Update();
    }

    public void Pause() {
        switch (state) {
            case EGameState.RUNNING:
                state = EGameState.PAUSE;
                break;
            default: break;
        }
    }

    public void Resume() {
        switch (state) {
            case EGameState.PAUSE:
                state = EGameState.RUNNING;
                break;
            default: break;
        }
    }

    public void Over() {
        state = EGameState.OVER;
    }

    public bool IsRunning() {
        return EGameState.RUNNING == state;
    }

    public void IncDistance(float delta) {
        GameData.Instance.Distance += delta;
    }
}
