using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyGameManager : MonoBehaviour
{
    public bool canPlay = false;
    public float gameSpeed = 5f;

    public CurrencyBtn[] currencyBtns;
    public PointsManager[] pointsMan;

    public Camera mainCam;

    int currencyIndexSelected = 0;

    // Start is called before the first frame update
    void Start()
    {
        Set_UP();
        Select_Currency(0);
    }

    private void Update()
    {
        Cam_Movement();
        Update_Prices();
        Restart_Scene();
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
            mainCam.transform.Translate(Vector2.right * Time.deltaTime * gameSpeed * 0.5f);
        }
    }

    void Set_UP()
    {
        for (int i = 0; i < currencyBtns.Length; i++)
        {
            currencyBtns[i].Set_Me(this);
            pointsMan[i].Set_Me(this);
        }
    }

    public void Select_Currency(int newSelectedCurrency)
    {
        currencyBtns[currencyIndexSelected].Unselect_Me();
        pointsMan[currencyIndexSelected].Unselect_Me();

        currencyIndexSelected = newSelectedCurrency;

        currencyBtns[currencyIndexSelected].Select_Me_Behavior();
        pointsMan[currencyIndexSelected].Select_Me();
    }
}
