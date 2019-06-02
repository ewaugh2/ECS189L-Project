using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    private Transform bar;

    private void Start()
    {
        Transform bar = transform.Find("BarSprite");
    }

    public void SetSize(float sizeNormalized)
    {
      bar.localScale = new Vector3(sizeNormalized, 1f);
      float move = (1-sizeNormalized) * 100;
      bar.localPosition = new Vector3(bar.localPosition.x - move, bar.localPosition.y);
    }
}
