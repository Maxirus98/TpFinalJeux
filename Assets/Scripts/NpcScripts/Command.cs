using System.Collections;
using UnityEngine;

namespace Script
{
    public abstract class Command 
    {
        public abstract IEnumerator Execute();
    }
}