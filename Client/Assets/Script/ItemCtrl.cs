using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour
{
    public GameObject mediListPage;
    
    public void DeleteBtn()
    {
        Destroy(transform.parent.gameObject);
    }

    public void userPageBtn()
    {
        //GameObject tmpObject = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/MediListPage")) ;    // 오브젝트 생성
        //tmpObject.transform.SetParent(GameObject.Find("Canvas").transform);   
        GameObject selPage = GameObject.Find("Canvas").transform.Find("SelectPage").gameObject;
        selPage.SetActive(false);
        GameObject mediListPage = GameObject.Find("Canvas").transform.Find("MediListPage").gameObject;
        mediListPage.SetActive(true); 
    }
}
