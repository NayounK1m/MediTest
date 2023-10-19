using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Repository : MonoBehaviour
{
	private Dictionary<string, string[]> hospitalDict;
	public GameObject inputMediPopup;
	public Dropdown localDropdown;
	public Dropdown hospitalDropdown;
	public TMP_Text hospitalbtn;

	void Start()
	{
		SetHospitalDict();

		//지역 선택할 경우 병원 옵션 변경
		localDropdown.onValueChanged.AddListener(delegate {
			ChangeHospitalDropdown(localDropdown.options[localDropdown.value].text);
		});
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	private void SetHospitalDict()
	{
		hospitalDict = new Dictionary<string, string[]>();
		string[] seoulHospitalarr = { "아산 병원", "연세 늘봄 병원", "연세대학병원" };
		hospitalDict.Add("서울", seoulHospitalarr);

		string[] daejeonHospitalarr = { "대전 병원", "대전 클리닉" };
		hospitalDict.Add("대전", daejeonHospitalarr);
	}

	public Dictionary<string, string[]> GetHospitalDict()
    {
		return hospitalDict;
    }

	
	public void ChangeDropdown()
    {
		localDropdown.ClearOptions();
		Dropdown.OptionData firsthospitaldataOption = new Dropdown.OptionData();
		firsthospitaldataOption.text = "지역";
		localDropdown.options.Add(firsthospitaldataOption);
		foreach (KeyValuePair<string, string[]> keyValuePair in hospitalDict)
        {
			Dropdown.OptionData localdataOption = new Dropdown.OptionData();
			localdataOption.text = keyValuePair.Key;
			localDropdown.options.Add(localdataOption);
        }
	}

	//병원 옵션 변경 코드
	public void ChangeHospitalDropdown(string hospitalDictKey)
    {
		hospitalDropdown.ClearOptions();
		Dropdown.OptionData firsthospitaldataOption = new Dropdown.OptionData();
		firsthospitaldataOption.text = "병원";
		hospitalDropdown.options.Add(firsthospitaldataOption);
		string[] hospitalList = hospitalDict[hospitalDictKey];
		foreach (string i in hospitalList)
		{
			Dropdown.OptionData hospitaldataOption = new Dropdown.OptionData();
			hospitaldataOption.text = i;
			hospitalDropdown.options.Add(hospitaldataOption);
		}

	}

	//선택 완료 후 버튼 누르면 텍스트 입력창에 가져오기
	public void changeDoneBtn()
    {
		Debug.Log(hospitalDropdown.options[hospitalDropdown.value].text);
		hospitalbtn.text = hospitalDropdown.options[hospitalDropdown.value].text;
		inputMediPopup.SetActive(false);

	}


	public void changeHospitalBtn()
    {
		inputMediPopup.SetActive(true);
		ChangeDropdown();

	}
}
