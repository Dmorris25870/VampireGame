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
    private bool skillsMenuIsOpen;
    private GameObject skillToAbsorb;
    // Start is called before the first frame update
    void Start()
    {
        skillsMenuIsOpen = false;
        skillToAbsorb = null;
    }

    private void OnEnable()
    {
        playerControl.actions.FindAction("Primary").started += OnPrimaryInput;
        playerControl.actions.FindAction("Primary").performed += OnPrimaryInput;
        playerControl.actions.FindAction("Primary").canceled += OnPrimaryInput;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AbilityToAbsorb"))
        {
            Debug.Log("Can Absorb Ability");
            EventManager.OnCanAbsorbAbility?.Invoke();
            skillToAbsorb = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("AbilityToAbsorb"))
        {
            Debug.Log("Cannot Absorb Ability");
            EventManager.OnCannotAbsorbAbility?.Invoke();
            skillToAbsorb = null;
        }
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
     
    private void OnAbility1()
    {        
        EventManager.OnQAbility?.Invoke();
    }

    private void OnAbility2()
    {
        EventManager.OnWAbility?.Invoke();
    }

    private void OnSkills()
    {
        Debug.Log("Skills Menu");
        if (!skillsMenuIsOpen)
        {
            EventManager.OnSkillsMenu?.Invoke();
            skillsMenuIsOpen = true;
        }
        else if (skillsMenuIsOpen)
        {
            EventManager.OnSkillsMenuClose?.Invoke();
            skillsMenuIsOpen = false;
        }        
    }

    private void OnAbsorbAbility()
    {
        Destroy(skillToAbsorb);
        EventManager.OnCannotAbsorbAbility?.Invoke();
    }

}
