using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCtrl : MonoBehaviour
{
    public GameObject PanelThis;
    public GameObject CalanderPanel;
    public GameObject AlarmPanel;
    public GameObject MediPanel;
    public GameObject HomePanel;
    // Start is called before the first frame update
     
    public void GoToCalander()
    {
        PanelThis.SetActive(false);
        CalanderPanel.SetActive(true);
    }

    public void GoToAlarm()
    {
        PanelThis.SetActive(false);
        AlarmPanel.SetActive(true);
    }

    public void GoToMedi()
    {
        PanelThis.SetActive(false);
        MediPanel.SetActive(true);
    }

    public void GoToHome()
    {
        PanelThis.SetActive(false);
        HomePanel.SetActive(true);
    }
}
