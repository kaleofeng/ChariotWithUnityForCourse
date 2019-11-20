using System.Collections;
using System.Collections.Generic;

public class WorldConstant {

    public static float LeftRoadX { get; private set; }
    public static float RightRoadX { get; private set; }
    public static float BottomRoadY { get; private set; }
    public static float TopRoadY { get; private set; }

    public static float GapDistance { get; private set; }
    public static float GapDuration { get; private set; }
    public static float AIDistance { get; private set; }

    public static float StaticYps { get; private set; }
    public static float BarrierYps { get; private set; }

    public static float PixelsPerMeter { get; private set; }

    public static void Setup() {
        LeftRoadX = ScreenAdapter.AdaptScreenX(Constant.LEFT_ROAD_X);
        RightRoadX = ScreenAdapter.AdaptScreenX(Constant.RIGHT_ROAD_X);
        BottomRoadY = ScreenAdapter.AdaptScreenY(Constant.BOTTOM_ROAD_Y);
        TopRoadY = ScreenAdapter.AdaptScreenY(Constant.TOP_ROAD_Y);

        GapDistance = ScreenAdapter.AdaptScreenHeight(Constant.GAP_DISTANCE);
        GapDuration = Constant.GAP_DURATION;
        AIDistance = ScreenAdapter.AdaptScreenHeight(Constant.AI_DISTANCE);

        StaticYps = ScreenAdapter.AdaptScreenHeight(Constant.STATIC_YPS);
        BarrierYps = ScreenAdapter.AdaptScreenHeight(Constant.BARRIER_YPS);

        PixelsPerMeter = ScreenAdapter.AdaptScreenHeight(Constant.PIXELS_PER_METER);
    }
}
