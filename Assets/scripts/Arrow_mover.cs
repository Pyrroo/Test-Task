using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Arrow_mover : MonoBehaviour
{
    public GameObject Hour_Arrow, Minute_Arrow, Second_Arrow;
    float seconds = 0;
    void Start()
    {
        App_Controller.UpdateEvent += ArrowFullUpdate;
    }

    public void ArrowFullUpdate()
    {
        Second_Arrow.transform.localEulerAngles = new Vector3(0, 0, 6 * App_Controller.Current_DateTime.Second);
        Minute_Arrow.transform.localEulerAngles = new Vector3(0,0, 6 * App_Controller.Current_DateTime.Minute);
        float rotatevalue = (App_Controller.Current_DateTime.Minute/60) + 
            (App_Controller.Current_DateTime.Second / 3600) + App_Controller.Current_DateTime.Hour*30;     
        Hour_Arrow.transform.localEulerAngles = new Vector3(0, 0, rotatevalue);
        seconds = App_Controller.Current_DateTime.Second;
        StartCoroutine(ArrowUpdater());
    }


    IEnumerator ArrowUpdater()
    {
        if(!Edit_Mode_Controller.isEditMode)
        {
            Second_Arrow.transform.Rotate(0, 0, 3f * 2);
            Minute_Arrow.transform.Rotate(0, 0, 0.05f * 2);
            Hour_Arrow.transform.Rotate(0, 0, 0.004f * 2);
            App_Controller.Current_DateTime = App_Controller.Current_DateTime.AddSeconds(1);
        }
        yield return new WaitForSeconds(1F);
        StartCoroutine(ArrowUpdater());
    }
}
