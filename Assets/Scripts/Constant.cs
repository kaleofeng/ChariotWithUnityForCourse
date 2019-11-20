using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant {

    public static float LEFT_ROAD_X = 110; // pixels
    public static float RIGHT_ROAD_X = 640; // pixels
    public static float BOTTOM_ROAD_Y = 0; // pixels
    public static float TOP_ROAD_Y = 1334; // pixels

    public static int[] FIXED_INDEXES = { 0, 1, 2, 3 };
    public static float[] FIXED_XS = { 170, 305, 445, 580 }; // pixels
    public static List<int> FIXED_WAYS = new List<int>(FIXED_INDEXES);

    public static float GAP_DISTANCE = 600; // pixels
    public static float GAP_DURATION = 5; // seconds
    public static float AI_DISTANCE = 300; // pixels

    public static float STATIC_YPS = 300; // y pixels per second
    public static float ROAD_YPS = 1000; // y pixels per second
    public static float BARRIER_YPS = 300; // y pixels per second

    public static float PIXELS_PER_METER = 50; // pixels
}
