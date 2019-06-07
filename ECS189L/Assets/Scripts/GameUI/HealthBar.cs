using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    private Transform bar;

    private void Start()
    {
        bar = this.gameObject.transform.GetChild(2).transform;
    }


    private float currentSize = 1;

    public void SetSize(float sizeNormalized)
    {
      bar.localScale = new Vector3(sizeNormalized, 1f);
      float move = (currentSize-sizeNormalized) * 5.4f;
      bar.localPosition = new Vector3(bar.localPosition.x - move, bar.localPosition.y);
      float red = (-200*sizeNormalized)+255;
      float green = (red*-1)+310;
      bar.GetComponent<Image>().color = new Color32((byte)red,(byte)green,0,255);
      currentSize = sizeNormalized;
    }

}
