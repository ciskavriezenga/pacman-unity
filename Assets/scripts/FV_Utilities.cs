using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FV_Utilities
{
  public static bool equalVec2(Vector2 v1, Vector2 v2, float dev=0.0001f) {
    return  v1.x >= (v2.x - dev) &&
            v1.x <= (v2.x + dev) &&
            v1.y >= (v2.y - dev) &&
            v1.y <= (v2.y + dev);
  }
}
