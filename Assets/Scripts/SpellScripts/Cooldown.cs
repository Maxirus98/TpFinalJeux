using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class Cooldown
    {
        public static IEnumerator WaitFor(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
        }
    }
}