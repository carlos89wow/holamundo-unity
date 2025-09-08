using UnityEngine;
using UnityEngine.EventSystems;

public class DragUI : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    RectTransform rt;
    Canvas canvas;

    void Awake()
    {
        rt = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    // Se llama mientras arrastras: movemos en píxeles, compensando el escalado del Canvas
    public void OnDrag(PointerEventData e)
    {
        rt.anchoredPosition += e.delta / canvas.scaleFactor;
    }

    public void OnBeginDrag(PointerEventData e) { /* opcional: sonido/efecto */ }
}
