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
		hospitalDict.Add("����", seoulHospitalarr);
	}

	public Dictionary<string, string[]> GetHospitalDict()
    {
		return hospitalDict;
    }

	
	public void ChangeDropdown()
    {
		foreach(KeyValuePair<string, string[]> keyValuePair in hospitalDict)
        {
			Dropdown.OptionData localdataOption = new Dropdown.OptionData();
			localdataOption.text = keyValuePair.Key;
			localDropdown.options.Add(localdataOption);
			//���� ������ ��� ���� �ɼ� ����
			localDropdown.onValueChanged.AddListener(delegate {
				ChangeHospitalDropdown(keyValuePair.Value);
			});
			
			
        }
	}

	//���� �ɼ� ���� �ڵ�
	public void ChangeHospitalDropdown(string[] hospitalList)
    {
		foreach (string i in hospitalList)
		{
			Dropdown.OptionData hospitaldataOption = new Dropdown.OptionData();
			hospitaldataOption.text = i;

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
