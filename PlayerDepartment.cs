using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string Name;
    public int Degree;
    public string Description;
    public float speed;
}

public abstract class PlayerMovement
{
    public Rigidbody2D rb;
    public float speed;

    public PlayerMovement(Rigidbody2D rb, float speed)
    {
        this.rb = rb;
        this.speed = speed;
    }

    public abstract void Move();
}


public class PlayerIdleMovement: PlayerMovement
{
    public PlayerIdleMovement(Rigidbody2D rb, float speed): base(rb, speed) { }

    public override void Move()
    {
        rb.velocity = new Vector2();
    }
}
public class PlayerRunMovement: PlayerMovement
{
    public PlayerRunMovement(Rigidbody2D rb, float speed) : base(rb, speed) { }

    public override void Move()
    {
        rb.velocity = rb.velocity * speed;
    }
}

public interface IPlayerState
{

    public void Enter();
    public void Update();
    public void Exit();
}

[System.Serializable]
public class PlayerStateMachine
{
    public IPlayerState CurrentState { get; private set; }

    public void Initialize(IPlayerState startingState)
    {
        CurrentState = startingState;
        startingState.Enter();
    }

    public void TransitionTo(IPlayerState nextState)
    {
        CurrentState.Exit();
        CurrentState = nextState;
        nextState.Enter();
    }

    public void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }
}