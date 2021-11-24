using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MouseHold : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private UnityEvent OnHold;
    private bool _isHold;
    
    private void Update()
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
