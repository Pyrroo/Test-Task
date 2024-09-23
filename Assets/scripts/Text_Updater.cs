using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Text_Updater : MonoBehaviour
{
    public TextMeshProUGUI txt;
    void Update()
    {
      txt.text = App_Controller.Current_DateTime.ToString("HH:mm:ss");
    }
}
