using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class App_Controller : MonoBehaviour
{
    public static System.DateTime Current_DateTime;
    public delegate void ActionEvent();
    public static event ActionEvent UpdateEvent;


    void Start()
    {
        TimeFromServer.ParseTime();
        StartCoroutine(ServerAnswer());
        StartCoroutine(WaitHour());
    }
    IEnumerator ServerAnswer()
    {
        
        yield return new WaitForSeconds(0.25f);
        UpdateEvent.Invoke();
    }
    IEnumerator WaitHour()
    {
        yield return new WaitForSeconds(3600f);
        TimeFromServer.ParseTime();
        UpdateEvent.Invoke();
        StartCoroutine(WaitHour());

    }
}
