using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PLayerController : MonoBehaviour
{
    public PlayerData PlayerData;
    public Rigidbody2D rb;
    public PlayerMovement movement;
    public PlayerStateMachine psm;
    public Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        psm = new PlayerStateMachine();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        movement = new PlayerIdleMovement(rb, PlayerData.speed);
        psm.TransitionTo(new PlayerIdleState(this));
    }

    // Update is called once per frame
    void Update()
    {
        psm.Update();
        movement.Move();
    }

    public void SetMovement(PlayerMovement newMovement)
    {
        movement = newMovement;
    }
}
