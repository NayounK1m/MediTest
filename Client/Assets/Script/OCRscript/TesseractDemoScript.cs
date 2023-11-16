using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;
using TMPro;
using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Data.Common;
using static UnityEngine.Networking.UnityWebRequest;
using System.Collections;
using System.IO.Compression;
using Components.Attributes;

public class TesseractDemoScript : MonoBehaviour
{
	private Texture2D imageToRecognize;
	[SerializeField] private Text displayText;
	[SerializeField] private RawImage outputImage;
	private TesseractDriver _tesseractDriver;
	private string _text = "";
	private Texture2D _texture;

public GameObject mediPanel;
	public Image showImage;
	public GameObject menuPanel;
	Image image;
    public void pictureBtn()
    {
		
		menuPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -2341);

        NativeCamera.Permission permission = NativeCamera.TakePicture((path) =>
        {
            Debug.Log("Image path:" + path);
            if (path != null)
            {
                Texture2D texture = NativeCamera.LoadImageAtPath(path, 516);
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from" + path);
                    return;
                }
            }
        }, 516);
        Debug.Log("Permission result:" + permission);
		createMedi("덱실란트디알캡슐60밀리그램", "1", "1", "7");
		createMedi("가스모틴에스알정", "1", "1", "7");
		createMedi("보나링에이정", "1", "1", "7");
		//TakePicturecamera(516);

	}

    public void TakePicturecamera(int maxSize)
	{
		mediPanel.SetActive(false);

		NativeCamera.Permission permission = NativeCamera.TakePicture((path)=>
		{
			Debug.Log("Image path:"+path);
			if(path != null)
			{
				Texture2D texture= NativeCamera.LoadImageAtPath(path,maxSize);
				if(texture == null)
				{
					Debug.Log("Couldn't load texture from"+path);
					return;
				}
			  UpdateImage(path);
			}
		}, maxSize);
		Debug.Log("Permission result:"+permission);
	}

	 void UpdateImage(string path)
	{
		imageToRecognize = loadImage(new Vector2(553,256), path);
		Debug.Log(imageToRecognize + path);
		ShowPic();
		// texture2d로 sprite 생성
		//image.sprite = Sprite.Create(tex, new Rect(0, 0, 553,256), new Vector2(0.5f, 0.5f));
		//showImage.GetComponent<Image>().sprite = image.sprite;
	}

	// 이미지 파일을 texture2d로 변환
	private static Texture2D loadImage(Vector2 size, string filePath)
	{
	   
		byte[] bytes = File.ReadAllBytes(filePath);
		Texture2D texture = new Texture2D((int)size.x, (int)size.y, TextureFormat.RGB24, false);
		texture.filterMode = FilterMode.Trilinear;
		texture.LoadImage(bytes);

		return texture;
	}

	private void ShowPic()
	{
		Texture2D texture = new Texture2D(imageToRecognize.width, imageToRecognize.height, TextureFormat.ARGB32, false);
		texture.SetPixels32(imageToRecognize.GetPixels32());
		texture.Apply();
		_tesseractDriver = new TesseractDriver();
		
		Recoginze(texture);
	}

	private void Recoginze(Texture2D outputTexture)
	{
		_texture = outputTexture;
		ClearTextDisplay();
		//AddToTextDisplay(_tesseractDriver.CheckTessVersion());
		_tesseractDriver.Setup(OnSetupCompleteRecognize);
	}

	private void OnSetupCompleteRecognize()
	{
		AddToTextDisplay(Nocr());
		//AddToTextDisplay(_tesseractDriver.Recognize(_texture));
		//AddToTextDisplay(_tesseractDriver.GetErrorMessage(), true);
		//SetImageDisplay();
	}

	private void ClearTextDisplay()
	{
		_text = "";
	}

	private void AddToTextDisplay(string text, bool isError = false)
	{
		if (string.IsNullOrWhiteSpace(text)) return;
		string[] words = text.Split('|');
		foreach (string word in words)
		{
			int last = word.Length - 1;
			if (word.Length > 3 && (word[last] == '정' || word.Contains("캡"))) 
			{
				_text += word + (string.IsNullOrWhiteSpace(displayText.text) ? "" : "/");
			}
		}
		displayText.text = _text;
		Debug.Log("addtotextdisplay" + text);
		inputDonebtn();

		if (isError)
			Debug.LogError(text);
		else
			Debug.Log(text);
	}

	private void SetImageDisplay()
	{
		RectTransform rectTransform = outputImage.GetComponent<RectTransform>();
		rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,
			rectTransform.rect.width * _tesseractDriver.GetHighlightedTexture().height / _tesseractDriver.GetHighlightedTexture().width);
		outputImage.texture = _tesseractDriver.GetHighlightedTexture();
	}
	public GameObject mediItemPrefab;
	public Transform mediScrollContent;

	public void inputDonebtn()
	{
		//string result = Regex.Replace(_text, @"[0-9]", "");
		string result1 = Regex.Replace(_text, @"[ ]", "");
		string[] split_text;
		//string[] split_Num;
		//string strNum = Regex.Replace(_text, @"\D", "");

		split_text = result1.Split('/');
		for(int i = 0; i < split_text.Length-1; i++)
		{
			createMedi(split_text[i], "1", "1", "7");
		}
		
		// split_Num = strNum.Split(' ');
		
		// for (int i = 0; i < split_text.Length; i++)
		// {
		//     switch(i) {
		// 		case 0:
		// 			createMedi(split_text[i], split_Num[0], split_Num[1], split_Num[2]);
		// 			break;
		// 		case 1:
		// 			createMedi(split_text[i], split_Num[3], split_Num[4], split_Num[5]);
		// 			break;
		// 		case 2:
		// 			createMedi(split_text[i], split_Num[6], split_Num[7], split_Num[8]);
		// 			break;
		// 		case 3:
		// 			createMedi(split_text[i], split_Num[9], split_Num[10], split_Num[11]);
		// 			break;
		// 		case 4:
		// 			createMedi(split_text[i], split_Num[12], split_Num[13], split_Num[14]);
		// 			break;
		// 		case 5:
		// 			createMedi(split_text[i], split_Num[15], split_Num[16], split_Num[17]);
		// 			break;
		// 	}
		// }

		mediPanel.SetActive(true);
	}

	
	private void createMedi(string mn, string dosage, string numD, string dayD)
	{
		GameObject tmpObject = GameObject.Instantiate(mediItemPrefab) ;    // 오브젝트 생성
		tmpObject.transform.SetParent(mediScrollContent.transform);                           // 부모에 붙임
		tmpObject.transform.GetChild(0).GetComponent<TMP_Text>().text = "품목명 : " + mn;
		tmpObject.transform.GetChild(1).GetComponent<TMP_Text>().text = "1회 투약량 : " + dosage;
		tmpObject.transform.GetChild(2).GetComponent<TMP_Text>().text = "1일 투여횟수 : " + numD;
		tmpObject.transform.GetChild(3).GetComponent<TMP_Text>().text = "총 투약일수 : " + dayD;

		//Active.mediName = mn;

		menuPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -2341);
		//GameObject.Instantiate(itemPrefab).transform.parent = scrollContent.transform;

	}
	
	private void PostOCR(UnityWebRequest request)
	{
		request.SendWebRequest();

		while (!request.isDone) { }
			
	}
	private string Nocr()
	{
		string b64str = System.Convert.ToBase64String(_texture.EncodeToJPG(), Base64FormattingOptions.None);
		WWWForm form = new WWWForm();
		form.AddField("b464str", b64str);
		UnityWebRequest request = Post("hsj3925.iptime.org:9090/ocr", Convert.ToBase64String(Encoding.UTF8.GetBytes(b64str)));
		PostOCR(request);
		string result = Encoding.UTF8.GetString(request.downloadHandler.data);
		return result;
	}

}