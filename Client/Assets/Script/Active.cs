
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEditor.Experimental.Rendering;

public class Active : MonoBehaviour
{
	public Transform mediScrollContent;
	public GameObject menuPanel;
	public GameObject mediItemPrefab;

	public GameObject nameIF;
	public GameObject dosageIF;
	public GameObject dayDoIF;
	public GameObject numDoIF;
	public GameObject hospitalIF;
	public GameObject diseaseIF;

	public GameObject InputPanel;
	public GameObject mediPanel;
	public GameObject MainPanel;
	public GameObject CreatePanel;
	public GameObject SelectPanel;
	public GameObject AddCalPanel;
	public TMP_InputField nameInput;
	public TMP_InputField ageInput;
	private string pageName = null;
	private string pageAge = null;
	public GameObject itemPrefab;
	public Transform scrollContent;

	public GameObject calanderPanel;
	public GameObject inputCalPanel;
	public GameObject AlarmPanel;

	public void CalandersaveBtn()
	{
		inputCalPanel.SetActive(true);
	}

	public TMP_InputField DateName;
	public TMP_InputField FTimeHH;
	public TMP_InputField FTimeMM;
	public TMP_InputField LTimeHH;
	public TMP_InputField LTimeMM;
	public GameObject CalMemoPrefab;
	public Transform CalCon; //임시 달력 리스트

	public void GoToCalanderBtn()
	{
		calanderPanel.SetActive(true);
	}
	public void GoToAlarmrBtn()
	{
		AlarmPanel.SetActive(true);
	}

	public void backBtn()
	{
		MainPanel.SetActive(true);
		CreatePanel.SetActive(false);
	}
	public void createPagebtn()
	{
		CreatePanel.SetActive(true);
		MainPanel.SetActive(false);
	}

	public void moreCreatePagebtn()
	{
		SelectPanel.SetActive(false);
		CreatePanel.SetActive(true);
	}

	public void selectPagebtn()
	{
		SelectPanel.SetActive(true);
		MainPanel.SetActive(false);
	}

	 public void inputbtn()
	{
		menuPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -2341);
		InputPanel.SetActive(true);
		mediPanel.SetActive(false);
	}

	public void mediInfoBackbtn()
	{
		GameObject infoPage = GameObject.Find("Canvas").transform.Find("mediInfoPage").gameObject;
		infoPage.SetActive(false);
	}

 public void createMediListbtn()
	{
		if(menuPanel != null)
		{
			Animator animator = menuPanel.GetComponent<Animator>();
			if(animator != null)
			{
				bool isOpen = animator.GetBool("open");
				animator.SetBool("open", true);
			}
		}
	}

	public void createMediListBackbtn()
	{
		if(menuPanel != null)
		{
			Animator animator = menuPanel.GetComponent<Animator>();
			if(animator != null)
			{
				bool isOpen = animator.GetBool("open");
				animator.SetBool("open", false);
			}
		}
	}
	public GameObject List;

	private List<string> getPreMedilist()	//기존 약 이름만 get 한다음 List에추가, 리턴 작업: 김나연
	{
		List<string> result = new List<string>();
		
		Transform[] allChildren = List.GetComponentsInChildren<Transform>();
		Transform[] allChildrenChild = allChildren[0].GetChild(0).GetComponents<Transform>();
		Debug.Log(allChildren[1].name); //MediItem
		foreach(Transform child in allChildrenChild) 
		{
    		// 자기 자신의 경우엔 무시 
    		// (게임오브젝트명이 다 다르다고 가정했을 때 통하는 코드)
    		if(child.name == transform.name)
			Debug.Log("무시");
			Debug.Log(child);
			Debug.Log(child.GetChild(0));
			Debug.Log(child.GetChild(0).GetComponent<TMP_Text>().text);
    		result.Add(child.GetChild(0).GetComponent<TMP_Text>().text);
			
		}
		return result;
	}

	private bool[] overlapCheck(List<string> preMedicine , string newMedicine)
	{
		//챗지피티 연구필요 임시로 1011리턴
		preMedicine.Add(newMedicine);
		bool[] result = new bool[4];
		result[0] = true;
		result[1] = false;
		result[2] = true;
		result[3] = true;
		return result;
	}

	private void overlapChangeImage()
	{
		//부작용 체크
		Transform[] allChildren = List.GetComponentsInChildren<Transform>();
		Transform[] allChildrenChild = allChildren[1].GetComponents<Transform>();
		Debug.Log(allChildren[1].name); //MediItem
		foreach(Transform child in allChildrenChild) 
		{
    		// 자기 자신의 경우엔 무시 
    		// (게임오브젝트명이 다 다르다고 가정했을 때 통하는 코드)
    		if(child.name == transform.name)
			Debug.Log("무시");
			else if(child == null)
			Debug.Log("null");
    
			Debug.Log(child.GetChild(0).GetComponent<TMP_Text>().text);
			bool[] result = overlapCheck(getPreMedilist(), child.GetChild(0).GetComponent<TMP_Text>().text);
    				//이미지 변경
			if (result[0] == true)
			{
				child.GetChild(6).GetComponent<Image>().sprite
				= Resources.Load("MediImage/overlap", typeof(Sprite)) as Sprite;
			}
			if (result[1] == true)
			{
				child.GetChild(7).GetComponent<Image>().sprite
				= Resources.Load("MediImage/alcohol", typeof(Sprite)) as Sprite;
			}
			if (result[2] == true)
			{
				child.GetChild(8).GetComponent<Image>().sprite
					= Resources.Load("MediImage/pregnant", typeof(Sprite)) as Sprite;
			}
			if (result[3] == true)
			{
				child.GetChild(9).GetComponent<Image>().sprite
					= Resources.Load("MediImage/smoke", typeof(Sprite)) as Sprite;
			}
			
		}

	}
	public static string mediName {get; set;}

	private void createMedi(string mn, string dosage, string numD, string dayD, string hospital, string disease)
	{
		GameObject tmpObject = GameObject.Instantiate(mediItemPrefab) ;    // 오브젝트 생성
		tmpObject.transform.SetParent(mediScrollContent.transform);                           // 부모에 붙임
		tmpObject.transform.GetChild(0).GetComponent<TMP_Text>().text = "품목명 : " + mn;
		tmpObject.transform.GetChild(1).GetComponent<TMP_Text>().text = "1회 투약량 : " + dosage;
		tmpObject.transform.GetChild(2).GetComponent<TMP_Text>().text = "1일 투여횟수 : " + numD;
		tmpObject.transform.GetChild(3).GetComponent<TMP_Text>().text = "총 투약일수 : " + dayD;
		tmpObject.transform.GetChild(4).GetComponent<TMP_Text>().text = "병원 : " + hospital;
		tmpObject.transform.GetChild(5).GetComponent<TMP_Text>().text = "질병 : " + disease; //질병정보 추가 필요

		// //부작용 체크
		// bool[] result = overlapCheck(getPreMedilist(), mn);

		// //이미지 변경
		// if (result[0] == true)
		// {
		// 	tmpObject.transform.GetChild(6).GetComponent<Image>().sprite
		// 	= Resources.Load("MediImage/overlap", typeof(Sprite)) as Sprite;
		// }
		// if (result[1] == true)
		// {
		// 	tmpObject.transform.GetChild(7).GetComponent<Image>().sprite
		// 	= Resources.Load("MediImage/alcohol", typeof(Sprite)) as Sprite;
		// }
		// if (result[2] == true)
		// {
		// 	tmpObject.transform.GetChild(8).GetComponent<Image>().sprite
		// 			= Resources.Load("MediImage/pregnant", typeof(Sprite)) as Sprite;
		// }
		// if (result[3] == true)
		// {
		// 	tmpObject.transform.GetChild(9).GetComponent<Image>().sprite
		// 			= Resources.Load("MediImage/smoke", typeof(Sprite)) as Sprite;
		// }

		GameObject.Instantiate(itemPrefab).transform.parent = scrollContent.transform;

		mediName = mn;

	}


	public void inputDonebtn()
	{
		InputPanel.SetActive(false);
		mediPanel.SetActive(true);

		createMedi(nameIF.GetComponent<TMP_InputField>().text, dosageIF.GetComponent<TMP_InputField>().text,
		numDoIF.GetComponent<TMP_InputField>().text, dayDoIF.GetComponent<TMP_InputField>().text,
		hospitalIF.GetComponent<TMP_InputField>().text, diseaseIF.GetComponent<TMP_InputField>().text);

		overlapChangeImage();

		nameIF.GetComponent<TMP_InputField>().text = "";
		dosageIF.GetComponent<TMP_InputField>().text = "";
		numDoIF.GetComponent<TMP_InputField>().text = "";
		dayDoIF.GetComponent<TMP_InputField>().text = "";
		hospitalIF.GetComponent<TMP_InputField>().text = "";
		diseaseIF.GetComponent<TMP_InputField>().text = "";

	}

	public void regiBtn()
	{
		pageName = nameInput.GetComponent<TMP_InputField>().text;
		pageAge = ageInput.GetComponent<TMP_InputField>().text;
		//Debug.Log(pageName + " / " + pageAge);
		nameInput.GetComponent<TMP_InputField>().text = "";
		ageInput.GetComponent<TMP_InputField>().text = "";
		CreatePanel.SetActive(false);
		SelectPanel.SetActive(true);
		crateList();
	}

	private void crateList()
	{
		GameObject tmpObject = GameObject.Instantiate(itemPrefab) ;    // 오브젝트 생성
		tmpObject.transform.SetParent(scrollContent.transform);                           // 부모에 붙임
		tmpObject.transform.GetChild(0).GetComponent<TMP_Text>().text = pageName;
		tmpObject.transform.GetChild(1).GetComponent<TMP_Text>().text = pageAge;
		//GameObject.Instantiate(itemPrefab).transform.parent = scrollContent.transform;

	}
	
}
