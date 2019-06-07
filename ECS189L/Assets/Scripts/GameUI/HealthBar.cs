using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    private Transform bar;

    private void Start()
    {
        bar = this.gameObject.transform;
    }

    public void SetSize(float sizeNormalized)
    {
      bar.localScale = new Vector3(sizeNormalized, 1f);
      float move = (1-sizeNormalized) * 5.4f;
      bar.localPosition = new Vector3(bar.localPosition.x - move, bar.localPosition.y);
      float red = (-200*sizeNormalized)+255;
      float green = (red*-1)+310;
      this.gameObject.GetComponent<Image>().color = new Color32((byte)red,(byte)green,0,255);
    }
}
