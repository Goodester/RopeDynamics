using System;
using System.Collections;
using UnityEngine;
using Wave;

namespace Utils
{
    public static class UtilityMethods
    {
        public static IEnumerator AddDelayToDisplacementMethod
            (Action<float, WavePoint> method, float amount, WavePoint cause)
        {
            yield return new WaitForSeconds(Globals.DelayBetweenWavePoints / 1000f);
            method(amount, cause);
        }
    }
}
