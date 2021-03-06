using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{

    public Card displayCard;

    public Image artworkImage;
    public GameObject slash;
    public GameObject typeImage;

    public Sprite red;
    public Sprite green;
    public Sprite blue;

    public bool selected; //if the god/action has been selected
    public bool confirmed; //if the god/action has been confirmed and will be used

    // Start is called before the first frame update
    void Start()
    {
        Display(displayCard);
    }

    public void Display(Card test)
    {
        artworkImage.sprite = test.artwork;
        if (test.type == 1)
        {
            typeImage.GetComponent<Image>().sprite = red;
        }
        else if (test.type == 2)
        {
            typeImage.GetComponent<Image>().sprite = green;
        }
        else if (test.type == 3)
        {
            typeImage.GetComponent<Image>().sprite = blue;
        }
        else if (test.type == 0)
        {
            typeImage.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        int playerMaat = GameManager.playerObj[0].GetComponent<Base>().maat;
        if (!displayCard.destroyed && GameManager.state == GameManager.State.GodSelection)
        {
            selected = true;

            Debug.Log("name: " + displayCard.name);
            Debug.Log("type: " + displayCard.type);
            Debug.Log("description: " + displayCard.descriptionText);
        }
        else if (displayCard.action && GameManager.state == GameManager.State.ActionSelection && playerMaat > 0) //if the card is an action && its action selection time && the player has more than 0 maat
        {
            selected = true;
            Debug.Log("Action Selected: " + displayCard.name);
        }
    }
}
