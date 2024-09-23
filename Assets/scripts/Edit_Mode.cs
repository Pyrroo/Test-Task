using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edit_Mode_Controller : MonoBehaviour
{

    public static bool isEditMode = false;
    public void ButtonEdit()
    {
        if (isEditMode)
        {
            isEditMode = false;
        }
        else
        {
            isEditMode = true;
        }
    } 
}
