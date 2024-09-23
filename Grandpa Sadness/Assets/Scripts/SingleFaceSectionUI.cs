using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SingleFaceSectionUI : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text text;

    public void UpdateUI(Sprite sprite, string text)
    {
        image.sprite = sprite;
        this.text.text = text;
    }

}
