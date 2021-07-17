using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent agent;
    MouseInput mouseInput;

    private void Awake()
    {
        mouseInput = new MouseInput();
    }

    private void OnEnable()
    {
        mouseInput.Enable();
    }

    private void OnDisable()
    {
        mouseInput.Disable();
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent> ();
        mouseInput.Mouse.MouseClick.performed += _ => MouseClick();
    }

    private void MouseClick()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mouseInput.Mouse.MousePosition.ReadValue<Vector2>());

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            agent.SetDestination(hit.point);
        }
    }

    void Update()
    {
        
    }
}
