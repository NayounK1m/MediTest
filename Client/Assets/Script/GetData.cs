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

public class GetData : MonoBehaviour
{
    public static string getResults()
    {
        GameObject This = EventSystem.current.currentSelectedGameObject;
        Debug.Log(This.name);
        TMP_Text txt = This.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
        const string targetURL = "http://apis.data.go.kr/1471000/DrbEasyDrugInfoService/getDrbEasyDrugList";
        const string serviceKey = "PIVkvcHgudkmfRVTAjJuLGZiXcrwjnq9gjPqJPsvrSfy72tfTWw0eT%2B%2F9atRs0nBZOO8T%2Bc0LIbG1RCzJKeV%2Fw%3D%3D";
        const string pageNo = "1";
        const string numOfRows = "1";
        string tmpName = txt.text; //품목명
        string itemName = Regex.Replace(tmpName, @"품목명 : ", "");
        
        const string type = "xml";

    	string result = string.Empty;
 
		try
		{
        	WebClient client = new WebClient();
			string url = string.Format(@"{0}?ServiceKey={1}&pageNo={2}&numOfRows={3}&itemName={4}&type={5}", targetURL, serviceKey, pageNo, numOfRows, itemName, type);
			using (Stream data = client.OpenRead(url))
			{
            	using (StreamReader reader = new StreamReader(data))
            	{
					string s = reader.ReadToEnd();
					result = s;
 
					reader.Close();
					data.Close();
				}
			}
		}
		catch (Exception e)
		{
			Debug.Log(e.Message);
		}
        Debug.Log(result);
 
		return result;
	}

    public void buttonRefresh_Click()
{
        // GameObject infoPage = EventSystem.current.currentSelectedGameObject;
        // Debug.Log(infoPage.name);
        TMP_Text entpNametxt = GameObject.Find("entpNametxt").GetComponent<TMP_Text>();
        TMP_Text itemNametxt = GameObject.Find("itemNametext").GetComponent<TMP_Text>();
        TMP_Text efcyQesitmtxt = GameObject.Find("efcyQesitmtxt").GetComponent<TMP_Text>();
        TMP_Text useMethodQesitmtxt = GameObject.Find("useMethodQesitmtxt").GetComponent<TMP_Text>();
        TMP_Text atpnWarnQesitmtxt = GameObject.Find("atpnWarnQesitmtxt").GetComponent<TMP_Text>();
        TMP_Text atpnQesitmtxt = GameObject.Find("atpnQesitmtxt").GetComponent<TMP_Text>();
        TMP_Text intrcQesitmtxt = GameObject.Find("intrcQesitmtxt").GetComponent<TMP_Text>();
        TMP_Text depositMethodQesitmtxt = GameObject.Find("depositMethodQesitmtxt").GetComponent<TMP_Text>();

	string result = getResults();
 
	XmlDocument xml = new XmlDocument();

	xml.LoadXml(result);

    XmlNodeList list = xml.GetElementsByTagName("item");
    int ResultC; 
	XmlNodeList resultCode = xml.GetElementsByTagName("body");
    foreach (XmlNode re in resultCode)
    {
        ResultC = int.Parse(re["totalCount"].InnerText);
        Debug.Log(re["totalCount"].InnerText);

    if (ResultC == 0)
    {
       entpNametxt.text = "등록되어 있지 않은 데이터이거나 조회 정보 없음";
        itemNametxt.text = " ";
        efcyQesitmtxt.text = " ";
        useMethodQesitmtxt.text = " ";
        atpnWarnQesitmtxt.text = " ";
        atpnQesitmtxt.text = " ";
        intrcQesitmtxt.text = " ";
        depositMethodQesitmtxt.text = " ";
    }
    else
    {

        foreach (XmlNode node in list)
        {
            entpNametxt.text = "업체명 : " + node["entpName"].InnerText;
            Debug.Log(entpNametxt.text);

            itemNametxt.text = "제품명 : " + node["itemName"].InnerText;
            Debug.Log(itemNametxt.text);

            string result1 = "효능 : " + node["efcyQesitm"].InnerText;
            string result2 = result1.Replace("<p>", "");
            efcyQesitmtxt.text = result2.Replace("</p>", "");
            Debug.Log(result2);

            result1 = "사용법 : " + node["useMethodQesitm"].InnerText;
            result2 = result1.Replace("<p>", "");
            useMethodQesitmtxt.text = result2.Replace("</p>", "");
            Debug.Log(result2);

            result1 = "경고 : " + node["atpnWarnQesitm"].InnerText + "\n";
            result2 = result1.Replace("<p>", "");
            atpnWarnQesitmtxt.text = result2.Replace("</p>", "");
            Debug.Log(result2);

            result1 = "주의사항 : " + node["atpnQesitm"].InnerText;
            result2 = result1.Replace("<p>", "");
            atpnQesitmtxt.text = result2.Replace("</p>", "");
            Debug.Log(result2);
            
            result1 =  "동일성분 주의 : " + node["intrcQesitm"].InnerText;
            result2 = result1.Replace("<p>", "");
            intrcQesitmtxt.text = result2.Replace("</p>", "");
            Debug.Log(result2);

            result1 = "보관법 : " + node["depositMethodQesitm"].InnerText;
            result2 = result1.Replace("<p>", "");
            depositMethodQesitmtxt.text = result2.Replace("</p>", "");
            Debug.Log(result2);
        }
        
    }
    }
}
}
