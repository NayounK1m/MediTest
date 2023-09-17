using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Net;
using System.IO;
using System;
using System.Xml;
using TMPro;
using System.Text.RegularExpressions;

public class mediItemCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    public void mediItemBtn()
    {
        GetData getDataManger = GameObject.Find("GetData").GetComponent<GetData>();
        GameObject infoPage = GameObject.Find("Canvas").transform.Find("mediInfoPage").gameObject;
        infoPage.SetActive(true);
        getDataManger.buttonRefresh_Click();
    }
}
