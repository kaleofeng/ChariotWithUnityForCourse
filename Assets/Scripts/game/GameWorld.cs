using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWorld {

    public static GameWorld Instance { get; private set; } = new GameWorld();

    public PlayController Stage { get; private set; }
    public Hero Hero { get; private set; }

    private EGameState state;

    public void Setup(PlayController playController) {
        Stage = playController;
    }

    public void Start() {
        Hero = Stage.GetComponentInChildren<Hero>();

        state = EGameState.PAUSE;
    }

    public void Update() {
        if (!IsRunning()) {
            return;
        }
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
}
