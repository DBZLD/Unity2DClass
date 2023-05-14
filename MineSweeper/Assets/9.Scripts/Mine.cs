using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public Sprite[] AroundMine = null;
    [SerializeField]
    protected Vector2Int m_GridPos;
    [SerializeField]
    protected bool m_ISMine;
    public GameManagers m_ParentManager = null;
    private SpriteRenderer spriterenderer;
    private bool IsPressed = true;


    public Vector2Int GridPos
    {
        get { return m_GridPos; }
        set { m_GridPos = value; }
    }

    public Vector2Int GetGridPos()
    {
        return m_GridPos;
    }
    public void SetGridPos(int x, int y)
    {
        m_GridPos.x = x;
        m_GridPos.y = y;
    }

    public bool GetMine()
    {
        return m_ISMine;
    }

    public void SetMine(bool p_ismine)
    {
        m_ISMine = p_ismine;
    }

    private void OnMouseDown()
    {
        if (IsPressed == true)
        {
            spriterenderer = GetComponent<SpriteRenderer>();
            if (this.m_ISMine == true)
            {
                spriterenderer.sprite = AroundMine[9];
            }
            else
            {
                int minecount = m_ParentManager.GetArounMineCount(this.GridPos.x, this.GridPos.y);
                Debug.Log($"ÁÖº¯ Áö·Ú°¹¼ö´Â : {minecount}");
            
                spriterenderer.sprite = AroundMine[minecount];
                IsPressed = false;
                m_ParentManager.GetAroundBlockAroundMine(this.GridPos.x, this.GridPos.y);
            }
            
        }
    }

    private void OnDrawGizmos()
    {
        if( m_ISMine )
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(this.transform.position, Vector3.one * 0.5f);
        }
    }


    private void Awake()
    {
        m_ParentManager = GameObject.FindObjectOfType<GameManagers>();
    }


    void Start()
    {
    }

    void Update()
    {

    }
}
