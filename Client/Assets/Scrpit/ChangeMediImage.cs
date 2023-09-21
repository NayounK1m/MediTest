using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMediImage : MonoBehaviour
{
    public RawImage Image1;
    public RawImage Image2;
    public RawImage Image3;
    public RawImage Image4;


    

    private void ChangeImage()
    {
        Image1 = GetComponent<RawImage>();
        Image1.texture = Resources.Load("/MediImage/alchol.jpg", typeof(Sprite)) as Texture;
    }
}
