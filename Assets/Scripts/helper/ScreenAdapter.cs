using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenAdapter {

    public static float DesignWidth { get; } = 750;

    public static float DesignHeight { get; } = 1334;

    public static float CanvasWidth { get; private set; }

    public static float CanvasHeight { get; private set; }

    public static float CanvasWidthRatio { get; private set; }

    public static float CanvasHeightRatio { get; private set; }

    public static float ScreenWidth { get; private set; }

    public static float ScreenHeight { get; private set; }

    public static float ScreenWidthRatio { get; private set; }

    public static float ScreenHeightRatio { get; private set; }

    public static float ScreenXRatio { get; private set; }

    public static float ScreenYRatio { get; private set; }

    public static void Setup(float canvasWidth, float canvasHeight, float screenWidth, float screenHeight) {
        CanvasWidth = canvasWidth;
        CanvasHeight = canvasHeight;

        ScreenWidth = screenWidth;
        ScreenHeight = screenHeight;

        CanvasWidthRatio = CanvasWidth / DesignWidth;
        CanvasHeightRatio = CanvasHeight / DesignHeight;

        ScreenWidthRatio = ScreenWidth / CanvasWidth;
        ScreenHeightRatio = ScreenHeight / CanvasHeight;

        ScreenXRatio = ScreenWidth / DesignWidth;
        ScreenYRatio = ScreenHeight / DesignHeight;

        Debug.Log(string.Format("Canvas: {0} {1} {2} {3} {4} {5}", DesignWidth, DesignHeight, CanvasWidth, CanvasHeight, ScreenWidth, ScreenHeight));
        Debug.Log(string.Format("Screen: {0} {1} {2} {3} {4} {5}", CanvasWidthRatio, CanvasHeightRatio, ScreenWidthRatio, ScreenHeightRatio, ScreenXRatio, ScreenYRatio));
    }

    public static float AdaptScreenWidth(float width) {
        return width * ScreenWidthRatio;
    }

    public static float AdaptScreenHeight(float height) {
        return height * ScreenHeightRatio;
    }

    public static float AdaptScreenX(float x) {
        return x * ScreenXRatio;
    }

    public static float AdaptScreenY(float y) {
        return y * ScreenYRatio;
    }
}
