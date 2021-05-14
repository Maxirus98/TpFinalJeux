using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class EventVector3 : UnityEvent<Vector3>
{
    //ICI : Vector3 est le paramètre pour le handler event qui va se faire appeler
    //1. déFINIR LA CLASSE D'ÉVÉNEMENT avec les param qu'on veut passer
}


public class MouseManager : MonoBehaviour
{
    [SerializeField] private LayerMask _clickableLayer;
    [SerializeField] private LayerMask _attackableLayer;

    [SerializeField] private Interactable focus;
    [SerializeField] private PlayerAnimator _playerAnimator;

    //2e étape, déclarer le handler
    public EventVector3 OnClickEnvironment;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000000, _clickableLayer.value))
            {
                OnClickEnvironment.Invoke(hit.point);
            }
           
        }
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000, _attackableLayer.value))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable)
                {
                    SetFocus(interactable);
                    _playerAnimator.Attack();
                }
            }
        }
    }
    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();
            focus = newFocus;
        }
        newFocus.OnFocused(transform);
    }
}
