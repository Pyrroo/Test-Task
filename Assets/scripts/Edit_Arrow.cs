using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;

public class Edit_Arrow : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    bool isRotating= false;
    public string arrow_name;
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        
       
            isRotating = true;
             
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (Edit_Mode_Controller.isEditMode)
        {
            if (isRotating)
            {
                if (arrow_name == "Minutes")
                {
                    float rotationAmount = eventData.delta.x;
                    transform.Rotate(Vector3.forward, rotationAmount);
                    App_Controller.Current_DateTime = App_Controller.Current_DateTime.AddMinutes(eventData.delta.x / 6);

                }
            }
        }
    }
}
