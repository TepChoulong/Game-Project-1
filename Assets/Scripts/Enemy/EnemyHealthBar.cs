using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    #region Variables

    [SerializeField] Slider Slider;
    [SerializeField] Color Low_Health;
    [SerializeField] Color High_Health;
    public Vector3 offset;

    #endregion


    public void SetHealth(float Health, float Max_Health)
    {
        Slider.gameObject.SetActive(Health <= Max_Health);
        Slider.maxValue = Max_Health;
        Slider.value = Health;

        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low_Health, High_Health, Slider.normalizedValue);  

    }


    void Update()
    {
        Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
}
