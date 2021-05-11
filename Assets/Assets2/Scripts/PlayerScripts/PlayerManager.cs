using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : Singleton<PlayerManager>
{
    private CriDuTonerre spell1;
    private SprayAndPray spell2;
    private Empaler spell3;
    private Attack attack;
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

    protected override void Awake()
    {
        ResetPlayerSpellsDamage();
    }

    public void ResetPlayerSpellsDamage()
    {
        spell1.GetComponent<SpellAoeHit>().tmpDamage = 40;
        spell2.GetBulletGo().GetComponent<SpellHit>().tmpDamage = 10;
        spell3.GetComponent<SpellAoeHit>().tmpDamage = 40;
        attack.GetComponent<SpellAoeHit>().tmpDamage = 10;
    }

    public void UpdatePlayerState(PlayerState playerState)
    {
        var previousGameState = CurrentPlayerState;
        CurrentPlayerState = playerState;
        switch (CurrentPlayerState)
        {
            case PlayerState.Alive:
                break;
            case PlayerState.Dead:
                //animation
                break;
            default:
                break;
        }

        playerStateEventHandler.Invoke(CurrentPlayerState, previousGameState);
    }


    private PlayerStateEvent playerStateEventHandler;
    
    public PlayerState CurrentPlayerState { set; get; }
}
