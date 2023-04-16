using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StockBtn : MonoBehaviour
{
    public int quantity;
    public Text quantityTxt;

    private void Start()
    {
        Update_Quantity_Txt();
    }

    public void Buy()
    {
        quantity++;
        Update_Quantity_Txt();
    }

    void Update_Quantity_Txt()
    {
        quantityTxt.text = quantity.ToString();
    }

    public void Sell()
    {
        if (quantity > 0)
        {
            quantity--;
        }
        Update_Quantity_Txt();
    }
}
