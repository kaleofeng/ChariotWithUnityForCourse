using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldHelper {

    public static void Setup() {

    }

    public static List<int> RandomFixedIndexes(int min, int max) {
        var number = MathKit.RandomRange(min, max);
        return MathKit.RandomValues<int>(Constant.FIXED_INDEXES, number);
    }

    public static Dictionary<int, float> RandomFixedXS(int min, int max) {
        var result = new Dictionary<int, float>();
        var indexList = RandomFixedIndexes(min, max);
        foreach (var index in indexList) {
            var x = Constant.FIXED_XS[index];
            result[index] = ScreenAdapter.AdaptScreenX(x);
        }
        return result;
    }

    public static float IndexFixedXS(int index) {
        var x = Constant.FIXED_XS[index];
        return ScreenAdapter.AdaptScreenX(x);
    }

public static List<int> FilterFixedWays(List<int> excludes) {
        return MathKit.FilterValues(Constant.FIXED_WAYS, excludes);
    }

    public static bool IsOutside(Vector3 position) {
        return position.y > Screen.height * 2 || position.y < -Screen.height;
    }

    public static long PixelsToMeters(float value) {
        return Mathf.FloorToInt(value / WorldConstant.PixelsPerMeter);
    }
}
