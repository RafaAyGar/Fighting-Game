using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectingFighterImage : MonoBehaviour
{
    public List<Sprite> fightersImages;
    public Button goLeft, goRight;

    int fighterDisplayedIndex;
    Image fighterImage;

    private void Awake()
    {
        fighterImage = GetComponent<Image>();
        goLeft.onClick.AddListener(SwipeToLeft);
        goRight.onClick.AddListener(SwipeToRight);
    }
    private void Start()
    {
        fighterDisplayedIndex = 0;
        ChangeImageToCurrentIndex();
    }
    void ChangeImageToCurrentIndex()
    {
        fighterImage.sprite = fightersImages[fighterDisplayedIndex];
    }
    public void SwipeToLeft()
    {
        if (fighterDisplayedIndex == 0) fighterDisplayedIndex = fightersImages.Count - 1;
        else fighterDisplayedIndex--;
        ChangeImageToCurrentIndex();
    }
    public void SwipeToRight()
    {
        if (fighterDisplayedIndex == fightersImages.Count - 1) fighterDisplayedIndex = 0;
        else fighterDisplayedIndex++;
        ChangeImageToCurrentIndex();
    }
    public Fighters GetFighterByCurrentImage()
    {
        Fighters fighter;

        if (fighterImage.sprite.name.Contains(Fighters.Naruto.ToString()))
        {
            fighter = Fighters.Naruto;
        }
        else if (fighterImage.sprite.name.Contains(Fighters.Sakura.ToString()))
        {
            fighter = Fighters.Sakura;
        }
        else
        {
            fighter = Fighters.Kakashi;
        }

        return fighter;
    }
}
