using System.Collections;
using UnityEngine;

namespace Script
{
    public abstract class Command : MonoBehaviour
    {
        public abstract IEnumerator Execute();
    }
}