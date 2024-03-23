using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] PlayerInput playerControl;
    [SerializeField] NavMeshAgent agent;
    private bool isMoving;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        playerControl.actions.FindAction("Primary").started += OnPrimaryInput;
        playerControl.actions.FindAction("Primary").performed += OnPrimaryInput;
        playerControl.actions.FindAction("Primary").canceled += OnPrimaryInput;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMoving)
        {
            MovePlayer();
        }
    }

    void MovePlayer()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.GetComponent<EnemyBehaviour>() != null)
            {
                //add code to hit enemies here
            }
            else
            {
                agent.SetDestination(hit.point);
            }
            
        }
    }

    void OnPrimaryInput(InputAction.CallbackContext context)
    {
        if (context.performed || context.started)
        {
            isMoving = true;
        }
        if (context.canceled)
        {
            isMoving = false;
        }
    }
     



}
