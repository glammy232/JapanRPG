using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Inventory
{
    public class InventoryCell : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Transform _descriptionTransform;

        [SerializeField] private UnityEvent OnMouseDown;

        [SerializeField] private UnityEvent OnMouseUp;

        [SerializeField] private UnityEvent OnHold;

        [SerializeField] private UnityEvent OnMouseEnter;

        [SerializeField] private UnityEvent OnMouseExit;

        public void OnPointerDown(PointerEventData eventData) => OnMouseDown?.Invoke();

        public void OnPointerUp(PointerEventData eventData) => OnMouseUp?.Invoke();

        public void OnPointerEnter(PointerEventData eventData) => OnMouseEnter?.Invoke();

        public void OnPointerExit(PointerEventData eventData) => OnMouseExit?.Invoke();
    }
}
