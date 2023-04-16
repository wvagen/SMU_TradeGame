using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject oilPanelGO;
    public GameObject coffeePanelGO;
    public GameObject woodPanelGO;

    public Text goldTxt;
    public Text oilTxt;
    public Text coffeeTxt;
    public Text finalGoldTxt;

    public GameObject nextBtnEnabled;
    public GameObject nextBtnDisabled;

    int finalScore = 0;

    public void Set_Final_Score(int gold, int quantityOil, int coffeeQuantity, int oilValue, int coffeeValue)
    {
        finalScore = gold + (quantityOil / 10) * oilValue + (coffeeQuantity / 10) * coffeeValue;
        if (finalScore >= 1000000)
            nextBtnEnabled.SetActive(true);
        else nextBtnDisabled.SetActive(true);

        finalGoldTxt.text = finalScore.ToString();
        goldTxt.text = gold.ToString();
        oilTxt.text = quantityOil.ToString();
        coffeeTxt.text = coffeeQuantity.ToString();


        woodPanelGO.SetActive(false);
    }

    
}
