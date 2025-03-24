using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private pelaajanElamat hitPoints;
    [SerializeField]
    private RahaLaskuri rahaLaskuri;
    [SerializeField]
    private AvainLaskuri avainLaskuri;

    [SerializeField]
    private RectTransform barRect;

    [SerializeField]
    private RectMask2D mask;

    [SerializeField]
    private TMP_Text hpText; 
    
    [SerializeField]
    private TMP_Text livesText;
    
    [SerializeField]
    private TMP_Text coinText; 
    [SerializeField]
    private TMP_Text avainText; 
  
    private float maxRightMask;
    private float initialRightMask;



    
    // Start is called before the first frame update
    void Start()
    {
        maxRightMask = barRect.rect.width - mask.padding.x - mask.padding.z;
        hpText.SetText($"{hitPoints.maxHealth} / {hitPoints.health}");
        initialRightMask = mask.padding.z; 
        livesText.SetText($"{hitPoints.playerLives}");
        coinText.SetText($"{rahaLaskuri.maxCoins} / {rahaLaskuri.countCoins}");

    }

    public void SetValue(int newValue)
    {
        var targetWidth = newValue * maxRightMask / hitPoints.maxHealth;
        var newRightMask = maxRightMask + initialRightMask - targetWidth;
        var padding = mask.padding;
        padding.z = newRightMask;
        mask.padding = padding;
        hpText.SetText($"{hitPoints.maxHealth} / {hitPoints.health}");
        livesText.SetText($"{hitPoints.playerLives}");

    }

    public void SetCoins()
    {
        coinText.SetText($"{rahaLaskuri.maxCoins} / {rahaLaskuri.countCoins}");

    }

    public void SetKeys()
    {
        avainText.SetText($"{avainLaskuri.avainLaskuri}");
    }
}
