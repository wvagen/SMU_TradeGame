using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyBtn : MonoBehaviour
{
    public Image myBtnImg;
    public Text currencyValueTxt;
    public int currencyID;

    public Sprite selectedSprite, unselectedSprite;

    MyGameManager myGameMan;

    public void Set_Me(MyGameManager myGameMan)
    {
        this.myGameMan = myGameMan;
    }

    public void Update_Pricetxt(int currentPrice)
    {
        currencyValueTxt.text = currentPrice.ToString() + "$";
    }

    private void Start()
    {
        Unselect_Me();
    }

    public void Select_Me()
    {
        myGameMan.Select_Currency(currencyID);
    }

    public void Select_Me_Behavior()
    {
        myBtnImg.enabled = true;
    }

    public void Unselect_Me()
    {
        // myBtnImg.sprite = unselectedSprite;
        myBtnImg.enabled = false;
    }
}
