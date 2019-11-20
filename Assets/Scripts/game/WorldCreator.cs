using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCreator {

    public static int[] CREATE_DISTANCE_PROBS = { 0, 50, 85, 100 };
    public static int[] CREATE_BARRIER_PROBS = { 0, 50, 100 };
    public static int[] CREATE_FRUIT_PROBS = { 0, 20, 40, 70, 85, 100 };

    private static int[] LEVEL_ENEMY_MIN = { 1, 1, 2, 1, 2 };
    private static int[] LEVEL_ENEMY_MAX = { 1, 2, 2, 3, 3 };

    private static int[] LEVEL_BARRIER_MIN = { 1, 1, 2, 1, 2 };
    private static int[] LEVEL_BARRIER_MAX = { 1, 2, 2, 3, 3 };

    private static int[] LEVEL_ROLLING_MIN = { 1, 1, 2, 1, 2 };
    private static int[] LEVEL_ROLLING_MAX = { 1, 2, 2, 3, 3 };

    private GameWorld world;
    private PlayController stage;

    private float distance;
    private int difficulty;
    private ECreateDistance lastCreateDistanceType;
    private int lastCreateDistanceCount;

    public void Setup(GameWorld gameWorld, PlayController playController) {
        world = gameWorld;
        stage = playController;
    }

    public void Start() {
        distance = 0;
        difficulty = 0;
        lastCreateDistanceType = ECreateDistance.NONE;
        lastCreateDistanceCount = 0;
    }

    public void Update() {
        var deltaY = WorldConstant.StaticYps * Time.deltaTime;
        distance += deltaY;
        if (distance >= WorldConstant.GapDistance) {
            CreateByDistance();
            distance = 0;
        }

        GameWorld.Instance.IncDistance(deltaY);
        CalculateDifficulty();
    }

    private void CalculateDifficulty() {
        var meters = WorldHelper.PixelsToMeters(GameData.Instance.Distance);
        if (meters <= 150) {
            difficulty = 0;
        }
        else if (meters <= 300) {
            difficulty = 1;
        }
        else if (meters <= 600) {
            difficulty = 2;
        }
        else if (meters <= 1000) {
            difficulty = 3;
        }
        else {
            difficulty = 4;
        }
    }

    private void CreateByDistance() {
        var type = ECreateDistance.NONE;
        do {
            type = (ECreateDistance)MathKit.RandomType(CREATE_DISTANCE_PROBS);
            if (type == lastCreateDistanceType) {
                ++lastCreateDistanceCount;
            }
            else {
                lastCreateDistanceType = type;
                lastCreateDistanceCount = 1;
            }
        } while (lastCreateDistanceCount > 2);

        switch (type) {
            case ECreateDistance.ENEMY:
                CreateBarrier();
                break;
            case ECreateDistance.BARRIER:
                CreateBarrier();
                break;
            case ECreateDistance.ROLLING:
                CreateBarrier();
                break;
            default:
                break;
        }
    }

    private void CreateBarrier() {
        var minNumber = LEVEL_BARRIER_MIN[difficulty];
        var maxNumber = LEVEL_BARRIER_MAX[difficulty];
        var wayDict = WorldHelper.RandomFixedXS(minNumber, maxNumber);
        var blockMinimum = 2;
        var blockCount = 0;
        foreach (var kv in wayDict) {
            var way = kv.Key;
            var x = kv.Value;
            var type = EBarrierType.BLOCK;
            if (++blockCount > blockMinimum) {
                type = (EBarrierType)MathKit.RandomType(CREATE_BARRIER_PROBS);
            }

            var gameObject = Object.Instantiate(stage.barrierPrefab, stage.barrierCanvas.transform);
            gameObject.transform.position = new Vector3(x, Screen.height + 100, 0);

            var barrier = gameObject.GetComponent<Barrier>();
            barrier.Way = way;
            barrier.Morph(type);
            world.BarrierManager.Add(barrier);
        }
    }
}
