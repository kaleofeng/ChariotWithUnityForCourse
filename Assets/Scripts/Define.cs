
public enum EGameState {
    PAUSE = 0,
    RUNNING,
    OVER,
}

public enum EEntityFamily {
    NONE = 0,
    HERO,
    BARRIER,
}

public enum EEntityState {
    NONE = 0,
    LIVE,
    DEAD,
}

public enum EBarrierType {
    NONE = 0,
    BEGIN,
    BLOCK = BEGIN,
    CONFUSE,
    END = CONFUSE,
}

public enum ECreateDistance {
    NONE = 0,
    ENEMY,
    BARRIER,
    ROLLING,
}
