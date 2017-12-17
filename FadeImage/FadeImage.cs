using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour {
    public float durationTime;//The time that the fading can continue.
    public bool isFadeIn;//The effect is Fade-In.
    public bool isFadeOut;//The effect is Fade-Out.
    public bool FadeOnAwake;
    private Image img;
	void Start () {
        img = GetComponent<Image>();
        if(FadeOnAwake&&img!=null)
        {
            StartCoroutine(fading());
        }
	}
    public bool fade()
    {
        if(img!=null)
        {
            StartCoroutine(fading());
            return true;
        }
        else
        {
            return false;
        } 
    }

    IEnumerator fading()
    {
        float t = 0;
        while(t<=1)
        {
            float delta;
            t +=Time.deltaTime/durationTime;
            if (isFadeIn)
                delta = Mathf.Lerp(0, 1, t);
            else
                delta = Mathf.Lerp(1, 0, t);
            Vector4 color = new Vector4();
            color.x = img.color.r;
            color.y = img.color.g;
            color.z = img.color.b;
            color.w = delta;
            img.color = color;
            yield return 0;
        }
        
    }
}
