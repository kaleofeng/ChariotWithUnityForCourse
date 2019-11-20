using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MathKit {

    public static int RandomRange(int min, int max) {
        return Random.Range(min, max + 1);
    }

    public static int RandomType(int[] probs) {
        var randValue = RandomRange(1, 100);
        for (var i = 0; i < probs.Length; ++i) {
            if (randValue <= probs[i]) {
                return i;
            }
        }
        return -1;
    }

    public static T RandomValue<T>(T[] values) {
        var index = Random.Range(0, values.Length);
        return values[index];
    }

    public static List<T> RandomValues<T>(T[] values, int number) {
        var valueList = new List<T>(values);
        var removeCount = valueList.Count - number;
        while (removeCount-- > 0) {
            var index = Random.Range(0, valueList.Count);
            valueList.RemoveAt(index);
        }
        return valueList;
    }

    public static List<T> FilterValues<T>(List<T> values, List<T> excludes) {
        return values.Where(t => !excludes.Contains(t)).ToList();
    }
}
