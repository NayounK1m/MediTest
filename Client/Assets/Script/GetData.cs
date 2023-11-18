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
                    if (result.Length < 245)
                    {
                        result = "\"<?xml version=\\\"1.0\\\" encoding=\\\"UTF-8\\\"?>\\n<response>\\n<header>\\n<resultCode>00</resultCode>\\n<resultMsg>NORMAL SERVICE.</resultMsg>\\n</header>\\n<body>\\n<numOfRows>1</numOfRows>\\n<pageNo>1</pageNo>\\n<totalCount>6</totalCount>\\n<items>\\n<item>\\n<entpName>한국존슨앤드존슨판매(유)</entpName>\\n<itemName>어린이타이레놀산160밀리그램(아세트아미노펜)</itemName>\\n<itemSeq>202005623</itemSeq>\\n<efcyQesitm>이 약은 감기로 인한 발열 및 동통(통증), 두통, 신경통, 근육통, 월경통, 염좌통(삔 통증), 치통, 관절통, 류마티양 동통(통증)에 사용합니다.\\n</efcyQesitm>\\n<useMethodQesitm>만 7~12세 소아는 1회 권장용량을 4~6시간마다 필요 시 물 없이 혀에 직접 복용합니다.\\n\\n이 약은 가능한 최단기간동안 최소 유효용량으로 복용하며, 1일 5회(75 mg/kg)를 초과하여 복용하지 않습니다.\\n\\n몸무게를 아는 경우 몸무게에 따른 용량(10~15 mg/kg)으로 복용하는 것이 더 적절합니다.\\n\\n자세한 사항은 허가사항 상세정보를 참고하십시오.\\n</useMethodQesitm>\\n<atpnWarnQesitm>매일 세잔 이상 정기적 음주자가 이 약 또는 다른 해열진통제를 복용할 때는 의사 또는 약사와 상의하십시오. 간손상을 일으킬 수 있습니다.\\n\\n매우 드물게 치명적일 수 있는 급성전신발진고름물집증, 스티븐스-존슨증후군, 독성표피괴사용해와 같은 중대한 피부반응이 보고되었고 이 약 복용 후 피부발진 또는 다른 과민반응의 징후가 나타나는 경우 즉시 복용을 중단하십시오.\\n\\n아세트아미노펜으로 일일 최대 용량(4,000 mg)을 초과하여 복용하지 마십시오. 간손상을 일으킬 수 있습니다. 아세트아미노펜을 포함하는 다른 제품과 함께 복용하지 마십시오.\\n</atpnWarnQesitm>\\n<atpnQesitm>이 약에 과민증, 소화성궤양, 심한 혈액 이상, 심한 간장애, 심한 신장(콩팥)장애, 심한 심장기능저하 환자, 아스피린 천식(비스테로이드성 소염(항염)제에 의한 천식발작 유발) 또는 경험자는 이 약을 복용하지 마십시오.\\n\\n이 약을 복용하기 전에 간장애 또는 경험자, 신장(콩팥)장애 또는 경험자, 소화성궤양 경험자, 혈액이상 또는 경험자, 출혈경향이 있는 환자, 심장기능이상이 있는 환자, 과민증 경험자, 기관지 천식 환자, 고령자(노인), 만 2세 미만 소아, 임부 또는 수유부, 와파린을 장기복용하는 환자는 의사 또는 약사와 상의하십시오.\\n\\n의사 또는 약사의 지시없이 통증에 10일 이상(성인)또는 5일 이상(소아) 복용하지 않고 발열에 3일 이상 복용하지 않습니다.\\n</atpnQesitm>\\n<intrcQesitm>바르비탈계 약물, 삼환계 항우울제, 알코올, 다른 소염(항염)진통제와 함께 복용하지 마십시오.\\n\\n리튬, 치아짓계이뇨제와 함께 복용 시 의사 또는 약사와 상의하십시오.\\n</intrcQesitm>\\n<seQesitm>쇽, 아나필락시양 증상(과민성유사증상: 호흡곤란, 온몸이 붉어짐, 혈관부기, 두드러기 등), 천식발작, 혈소판 감소, 과립구감소, 용혈성(적혈구파괴성)빈혈, 메트헤모글로빈혈증, 혈소판기능 저하(출혈시간 연장), 청색증, 과민증상(얼굴부기, 호흡곤란, 땀이 남, 저혈압, 쇽), 구역, 구토, 식욕부진, 장기복용시 위장출혈, 소화성궤양, 천공(뚫림) 등의 위장관계 이상반응, 발진, 알레르기 반응, 피부점막안증후군(스티븐스-존슨 증후군), 독성표피괴사용해(리엘증후군), 피부 및 피하(피부밑)조직 장애, 소양성(가려움) 발진, 발진, 고정발진, AST 상승, ALT 상승 등이 나타나는 경우 복용을 즉각 중지하고 의사 또는 약사와 상의하십시오.\\n</seQesitm>\\n<depositMethodQesitm>실온에서 보관하십시오.\\n\\n어린이의 손이 닿지 않는 곳에 보관하십시오.\\n</depositMethodQesitm>\\n<openDe>2023-07-12 00:00:00</openDe>\\n<updateDe>2023-07-12</updateDe>\\n<itemImage/>\\n<bizrno>1068649891</bizrno>\\n</item>\\n</items>\\n</body>\\n</response>\\n\"";

					}
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
