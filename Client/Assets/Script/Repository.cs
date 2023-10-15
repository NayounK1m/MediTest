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

		//���� ������ ��� ���� �ɼ� ����
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
		string[] seoulHospitalarr = { "�ƻ� ����", "���� �ú� ����", "�������к���" };
		hospitalDict.Add("����", seoulHospitalarr);

		string[] daejeonHospitalarr = { "���� ����", "���� Ŭ����" };
		hospitalDict.Add("����", daejeonHospitalarr);
	}

	public Dictionary<string, string[]> GetHospitalDict()
    {
		return hospitalDict;
    }

	
	public void ChangeDropdown()
    {
		localDropdown.ClearOptions();
		Dropdown.OptionData firsthospitaldataOption = new Dropdown.OptionData();
		firsthospitaldataOption.text = "����";
		localDropdown.options.Add(firsthospitaldataOption);
		foreach (KeyValuePair<string, string[]> keyValuePair in hospitalDict)
        {
			Dropdown.OptionData localdataOption = new Dropdown.OptionData();
			localdataOption.text = keyValuePair.Key;
			localDropdown.options.Add(localdataOption);
        }
	}

	//���� �ɼ� ���� �ڵ�
	public void ChangeHospitalDropdown(string hospitalDictKey)
    {
		hospitalDropdown.ClearOptions();
		Dropdown.OptionData firsthospitaldataOption = new Dropdown.OptionData();
		firsthospitaldataOption.text = "����";
		hospitalDropdown.options.Add(firsthospitaldataOption);
		string[] hospitalList = hospitalDict[hospitalDictKey];
		foreach (string i in hospitalList)
		{
			Dropdown.OptionData hospitaldataOption = new Dropdown.OptionData();
			hospitaldataOption.text = i;
			hospitalDropdown.options.Add(hospitaldataOption);
		}

	}

	//���� �Ϸ� �� ��ư ������ �ؽ�Ʈ �Է�â�� ��������
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
