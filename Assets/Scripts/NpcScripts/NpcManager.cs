using UnityEngine;

namespace NpcScripts
{
    public class NpcManager : MonoBehaviour
    {
        #region Singleton

        public static NpcManager Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                print("More than one instance found");
            }

            Instance = this;
        }

        #endregion
        
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