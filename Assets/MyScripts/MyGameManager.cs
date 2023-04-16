using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MyGameManager : MonoBehaviour
{
    public Animator canvasAnim;

    public bool canPlay = false;

    public float gameSpeed = 5f;
    public float pointsSpeed = 5f;

    public CurrencyBtn[] currencyBtns;
    public PointsManager[] pointsMan;
    public StockBtn[] stockBtns;

    public Camera mainCam;
    public Text myMoneyTxt,alertTxt;

    int currencyIndexSelected = 0;
    int myMoney = 50000;

    // Start is called before the first frame update
    void Start()
    {
        Set_UP();
        Select_Currency(0);
    }

    private void Update()
    {
        Update_Prices();
        Restart_Scene();
    }

    private void LateUpdate()
    {
        Cam_Movement();
    }

    void Update_Prices()
    {
        for (int i = 0; i < pointsMan.Length; i++)
        {
            currencyBtns[i].Update_Pricetxt(pointsMan[i].currentPrice);
        }
    }

    private void Restart_Scene()
    {
        if (Input.GetKeyDown(KeyCode.R))
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Cam_Movement()
    {
        if (canPlay)
        {
            mainCam.transform.position = new Vector3(pointsMan[0].currentPoint.transform.position.x, mainCam.transform.position.y, mainCam.transform.position.z);
        }
    }

    void Set_UP()
    {
        for (int i = 0; i < currencyBtns.Length; i++)
        {
            currencyBtns[i].Set_Me(this);
            pointsMan[i].Set_Me(this);
        }
        Update_Money_Txt();
    }

    void Update_Money_Txt()
    {
        myMoneyTxt.text = myMoney.ToString();
    }

    public void Select_Currency(int newSelectedCurrency)
    {
        currencyBtns[currencyIndexSelected].Unselect_Me();
        pointsMan[currencyIndexSelected].Unselect_Me();

        currencyIndexSelected = newSelectedCurrency;

        currencyBtns[currencyIndexSelected].Select_Me_Behavior();
        pointsMan[currencyIndexSelected].Select_Me();
    }

    public void Hide_Alert()
    {
        canvasAnim.SetBool("isShowingNotification", false);
    }

    public void Display_Alert(string alertTxt)
    {
        this.alertTxt.text = alertTxt;
        canvasAnim.SetBool("isShowingNotification", true);
    }

    public void Buy()
    {
        if (myMoney > -10000)
        {
            myMoney -= pointsMan[currencyIndexSelected].currentPrice;
            Update_Money_Txt();
            stockBtns[currencyIndexSelected].Buy();
        }
    }

    public void Sell()
    {
        if (stockBtns[currencyIndexSelected].quantity > 0)
        {
            myMoney += pointsMan[currencyIndexSelected].currentPrice;
            Update_Money_Txt();
            stockBtns[currencyIndexSelected].Sell();
        }
    }

}
