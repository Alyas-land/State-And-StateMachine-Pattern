using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerIdleState: IPlayerState
{
    private PLayerController playerController;

    public PlayerIdleState(PLayerController playerController)
    {
        this.playerController = playerController;

    }

    public void Enter()
    {
        
        playerController.SetMovement(new PlayerIdleMovement(playerController.GetComponent<Rigidbody2D>(), playerController.PlayerData.speed));
    }

    public void Update() {
    }

    public void Exit()
    {

    }
}
