using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : Singleton<PlayerManager>
{
    [System.Serializable]
    public class PlayerStateEvent : UnityEvent<PlayerState, PlayerState>
    {
    }
    
    private GameObject player;

    public enum PlayerState
    {
        Alive,
        Dead
    }


    void UpdateGameState(PlayerState playerState)
    {
        var previousGameState = CurrentPlayerState;
        CurrentPlayerState = playerState;
        switch (CurrentPlayerState)
        {
            case PlayerState.Alive:
                break;
            case PlayerState.Dead:
                break;
            default:
                break;
        }

        playerStateEventHandler.Invoke(CurrentPlayerState, previousGameState);
    }


    private PlayerStateEvent playerStateEventHandler;
    
    public PlayerState CurrentPlayerState { set; get; }
}
