using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TimeKit {

    public static long GetTimestamp() {
        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0);
        return Convert.ToInt64(ts.TotalSeconds);
    }
}
