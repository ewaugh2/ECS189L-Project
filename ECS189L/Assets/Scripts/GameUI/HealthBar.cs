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
      float move = (1-sizeNormalized) * 100;
      bar.localPosition = new Vector3(bar.localPosition.x - move, bar.localPosition.y);
      health.GetComponent<Image>().color = new Color32((-200*sizeNormalized)+255,(((-200*sizeNormalized)+255)*-1)+255,0,255);
    }
}
