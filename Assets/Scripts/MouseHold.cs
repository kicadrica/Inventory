using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MouseHold : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private UnityEvent OnHold;
    private bool _isHold;
    
    void Update()
    {
        if (_isHold) {
            OnHold?.Invoke();
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        _isHold = false;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        _isHold = true;
    }
}
