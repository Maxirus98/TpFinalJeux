using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class PlayerManager : Singleton<PlayerManager>
{
    [System.Serializable]
    public class PlayerStateEvent : UnityEvent<PlayerState>
    {
    }
    
    private GameObject player;

    public enum PlayerState
    {
        Alive,
        Dead
    }

    private PlayerStateEvent playerStateEventHandler;
}
