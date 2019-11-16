using System.Collections;
using System.Collections.Generic;

public class WorldConstant {

    public static float LeftRoadX { get; private set; }
    public static float RightRoadX { get; private set; }
    public static float BottomRoadY { get; private set; }
    public static float TopRoadY { get; private set; }

    public static void Setup() {
        LeftRoadX = ScreenAdapter.AdaptScreenX(Constant.LEFT_ROAD_X);
        RightRoadX = ScreenAdapter.AdaptScreenX(Constant.RIGHT_ROAD_X);
        BottomRoadY = ScreenAdapter.AdaptScreenY(Constant.BOTTOM_ROAD_Y);
        TopRoadY = ScreenAdapter.AdaptScreenY(Constant.TOP_ROAD_Y);
    }
}
