
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;
namespace ProyectoFinal
{
    public class Drag : PointerManipulator
    {
        private Vector3 posIni; //almacena la posicion inicial del puntero cuando se presiona
        protected bool isActive; //indica si el dragger esta activo o no
        private int pointerID; // almacena el ID del puntero activo
        private VisualElement closestSlot;
        public Drag()
        {
            pointerID = -1;
            activators.Add(new ManipulatorActivationFilter { button = UnityEngine.UIElements.MouseButton.LeftMouse });
            isActive = false;
        }
        protected override void RegisterCallbacksOnTarget()
        {
            target.RegisterCallback<PointerDownEvent>(OnPointerDown);
            target.RegisterCallback<PointerMoveEvent>(OnPointerMove);
            target.RegisterCallback<PointerUpEvent>(OnPointerUp);
        }
        protected override void UnregisterCallbacksFromTarget()
        {
            target.UnregisterCallback<PointerDownEvent>(OnPointerDown);
            target.UnregisterCallback<PointerMoveEvent>(OnPointerMove);
            target.UnregisterCallback<PointerUpEvent>(OnPointerUp);
        }
        //maneja el evento cuando se presiona el puntero
        protected void OnPointerDown(PointerDownEvent e)
        {
            if (isActive)
            {
                e.StopImmediatePropagation();
                return;
            }
            if (CanStartManipulation(e))
            {
                posIni = e.localPosition;
                pointerID = e.pointerId;
                isActive = true;
                target.CapturePointer(pointerID);
                e.StopPropagation();
            }
        }
        //maneja el evento cuando se mueve el puntero
        protected void OnPointerMove(PointerMoveEvent e)
        {
            if (!isActive || !target.HasPointerCapture(pointerID))
            {
                return;
            }
            Vector2 diff = e.localPosition - posIni;
            target.style.top = target.layout.y + diff.y;
            target.style.left = target.layout.x + diff.x;

            closestSlot = FindClosestSlot(target);
            e.StopPropagation();
        }
        //maneja el evento cuando se levanta el puntero
        protected void OnPointerUp(PointerUpEvent e)
        {
            if (!isActive || !target.HasPointerCapture(pointerID) || !CanStartManipulation(e))
            {
                return;
            }
            if(closestSlot != null)
            {
                Vector2 closestSlotPosition = closestSlot.layout.position;

                target.style.left = closestSlotPosition.x;
                target.style.top = closestSlotPosition.y;
            }
            isActive = false;
            target.ReleasePointer(pointerID);
            pointerID = -1;
            e.StopPropagation();
        }
        private VisualElement FindClosestSlot(VisualElement item)
        {
            VisualElement closest = null;
            float closestDistance = float.MaxValue;

            foreach(VisualElement slot in GetSlots())
            {
                float distance = Vector3.Distance(item.layout.position, slot.layout.position);
                if(distance < closestDistance)
                {
                    closest = slot;
                    closestDistance = distance;
                }
            }
            return closest;
        }
        private VisualElement[] GetSlots()
        {
            VisualElement[] slots = new VisualElement[6];
            slots[0] = App.slotCerdo;
            slots[1] = App.slotMovil;
            slots[2] = App.slotLapiz;
            slots[3] = App.slotAvion;
            slots[4] = App.slotOjo;
            slots[5] = App.slotZapatillas;

            return slots;
        }

    }
}

