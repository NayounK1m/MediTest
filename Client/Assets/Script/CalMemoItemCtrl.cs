using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalMemoItemCtrl : MonoBehaviour
{
    public void Btn()
    {
        GameObject infoPage = GameObject.Find("Canvas").transform.Find("CalCon_Popup").gameObject;
        infoPage.SetActive(true);
    }
}
