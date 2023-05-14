using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagers : MonoBehaviour
{
    public Mine m_CloneBlockElement = null;

    public int XSize = 9;
    public int YSize = 9;

    public Camera LinkCam = null;
    public bool[,] ISMineArr = new bool[9, 9];
    public Mine[,] AllBlockElementArr = null;

    public Dictionary<string, int[,]> BlockDictionary = new Dictionary<string, int[,]>();

    public bool ISMine(int p_y, int p_x)
    {
        if (p_x < 0 || p_x >= XSize)
            return false;

        if (p_y < 0 || p_y >= YSize)
            return false;

        return ISMineArr[p_y, p_x];
    }

    public int GetArounMineCount(int p_x, int p_y)
    {
        int outmine = 0;

        if (ISMine(p_y + 1, p_x - 1) == true) ++outmine;
        if (ISMine(p_y + 1, p_x - 0) == true) ++outmine;
        if (ISMine(p_y + 1, p_x + 1) == true) ++outmine;

        if (ISMine(p_y + 0, p_x - 1) == true) ++outmine;
        if (ISMine(p_y + 0, p_x + 1) == true) ++outmine;


        if (ISMine(p_y - 1, p_x - 1) == true) ++outmine;
        if (ISMine(p_y - 1, p_x - 0) == true) ++outmine;
        if (ISMine(p_y - 1, p_x + 1) == true) ++outmine;

        return outmine;
    }
    public void GetAroundBlockAroundMine(int x, int y)
    {

    }

    protected void InitMineSeeting()
    {

        for (int i = 0; i < 5; i++)
        {
            int randomX = Random.Range(0, 9);
            int randomY = Random.Range(0, 9);

            if(AllBlockElementArr[randomX, randomY].GetMine() == false)
            {
                AllBlockElementArr[randomX, randomY].SetMine(true);
                ISMineArr[randomX, randomY] = true;
            }
            else
            {
                continue;
            }
        }



        for (int y = 0; y < YSize; y++)
        {
            for (int x = 0; x < XSize; x++)
            {
                AllBlockElementArr[y, x].SetMine(ISMineArr[y, x]);
            }
        }
    }

    private void Awake()
    {
        CreateMine();

        InitMineSeeting();
    }

    void CreateMine()
    {
        AllBlockElementArr = new Mine[YSize, XSize];
        for (int y = 0; y < YSize; y++)
        {
            for (int x = 0; x < XSize; x++)
            {
                Vector3 pos = new Vector3(x, YSize - 1 - y, 0);
                Mine cloneobj = GameObject.Instantiate(m_CloneBlockElement
                    , pos
                    , Quaternion.identity);

                cloneobj.name = $"Mine_[{x},{y}]";
                cloneobj.SetGridPos(x, y);
                cloneobj.m_ParentManager = this;
                cloneobj.gameObject.SetActive(true);

                AllBlockElementArr[y, x] = cloneobj;

            }
        }
    }

    public SpriteRenderer m_TempRender = null;
    


    void Start()
    {

    }


    void Update()
    {

    }
}
