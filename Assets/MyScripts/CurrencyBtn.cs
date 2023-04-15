using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyBtn : MonoBehaviour
{
    public Image myBtnImg;
    public int currencyID;

    public Sprite selectedSprite, unselectedSprite;

    MyGameManager myGameMan;

    public void Set_Me(MyGameManager myGameMan)
    {
        this.myGameMan = myGameMan;
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
        myBtnImg.sprite = selectedSprite;
    }

    public void Unselect_Me()
    {
        myBtnImg.sprite = unselectedSprite;
    }
}
