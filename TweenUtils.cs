using System;
using System.Collections;
using UnityEngine;

namespace Tween
{
    public class TweenUtils : MonoBehaviour
    {
        public static IEnumerator DoAsync(TimeSpan duration, Func<TimeSpan> getDelta, Action<double> set)
        {
            var d = TimeSpan.Zero;
            while (d < duration)
            {
                set(d / duration);
                yield return null;
                d += getDelta();
            }

            set(1f);
        }

        public static IEnumerator RepeatAsync(Func<IEnumerator> callable)
        {
            while (true)
            {
                yield return callable();
            }
        }
    }
}