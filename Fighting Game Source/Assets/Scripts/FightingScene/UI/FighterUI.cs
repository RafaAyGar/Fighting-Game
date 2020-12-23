using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterUI : MonoBehaviour
{
    public GameObject healthBar;
    public GameObject manaBar;

    [HideInInspector] public FighterSide _fighterSide;
    [HideInInspector] public Slider healthSlider;
    [HideInInspector] public Slider manaSlider;

    private Transform canvas;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        InstanstiateBar(healthBar);
        healthSlider = healthBar.GetComponent<Slider>();
    }

    void InstanstiateBar(GameObject bar)
    {
        healthBar = Instantiate(bar, bar.transform.parent);
    }

    private void Start()
    {
        _fighterSide = GetComponent<FighterController>().side;
        AdjustSliderScreenPosition(healthSlider);
    }


    void AdjustSliderScreenPosition(Slider slider)
    {
        AdjustRectTransformToFighterSide(slider.GetComponent<RectTransform>());
        slider.transform.SetParent(canvas.transform, false);
    }
    Slider InstantiateBarAndReturnSliderComponent(GameObject bar)
    {
        var sliderComponent = Instantiate(bar, bar.transform.parent).gameObject.GetComponent<Slider>();

        AdjustRectTransformToFighterSide(sliderComponent.GetComponent<RectTransform>());
        sliderComponent.name = bar.name;
        sliderComponent.transform.SetParent(canvas.transform, false);

        return sliderComponent;
    }
    void AdjustRectTransformToFighterSide(RectTransform rectTransform)
    {
        Vector2 anchors = GetAnchorsFromFighterSide(_fighterSide);
        rectTransform.anchorMin = anchors;
        rectTransform.anchorMax = anchors;
        if (_fighterSide.Equals(FighterSide.left)) rectTransform.anchoredPosition = new Vector2(130, -41);
        else rectTransform.anchoredPosition = new Vector2(-130, -41);
    }
    Vector2 GetAnchorsFromFighterSide(FighterSide playerSide)
    {
        Vector2 anchor;
        if(playerSide.Equals(FighterSide.left))
        {
            anchor = Vector2.up;
        }
        else
        {
            anchor = Vector2.one;
        }
        return anchor;
    }
}
