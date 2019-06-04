using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    private Transform bar;
    private GameObject health;

    private void Start()
    {
        bar = transform.Find("BarSprite");
        health = GameObject.Find("BarSprite");
    }

    public void SetSize(float sizeNormalized)
    {
      bar.localScale = new Vector3(sizeNormalized, 1f);
      float move = (1-sizeNormalized) * 40;
      bar.localPosition = new Vector3(bar.localPosition.x - move, bar.localPosition.y);
      float red = (-200*sizeNormalized)+255;
      float green = (red*-1)+310;
      health.GetComponent<Image>().color = new Color32((byte)red,(byte)green,0,255);
    }
}
