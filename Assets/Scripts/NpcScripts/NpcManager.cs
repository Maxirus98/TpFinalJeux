using UnityEngine;

namespace NpcScripts
{
    public class NpcManager : MonoBehaviour
    {

        private int _nbrOfNpcAlive = 0;

        public void AddNpcAlive()
        {
            _nbrOfNpcAlive++;
        }

        public void RemoveNpcAlive()
        {
            if (_nbrOfNpcAlive > 0)
            {
                _nbrOfNpcAlive--;
            }
        }

        public int GetNbrNpcAlive()
        {
            return _nbrOfNpcAlive;
        }
    }
}