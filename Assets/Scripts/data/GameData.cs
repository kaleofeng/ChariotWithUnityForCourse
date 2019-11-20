using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData {

    public static GameData Instance { get; private set; } = new GameData();

    public long Coin { get; set; } = 0;

    public float Distance { get; set; } = 0;

    public long Score { get; set; } = 0;

    public long Cost { get; set; } = 0;

    public void Reset() {
        Coin = 0;
        Distance = 0;
        Score = 0;
        Cost = 0;
    }
}
