using UnityEngine;

public class Cell : MonoBehaviour
{
    // このセルの色（実際は列挙型や int で管理してもOK）
    public Color cellColor;

    // クリック検出用
    private SpriteRenderer rend;

    void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    // セットアップ用に呼び出すメソッド
    public void Initialize(Color color)
    {
        cellColor = color;
        rend.color = color;
    }

    // クリック時に呼ばれる
    private void OnMouseDown()
    {
        GridManager.Instance.OnCellClicked(this);
    }

    // セルを消す演出（SPAWN/DESTROY）
    public void DestroyCell()
    {
        // 簡易的に消す
        Destroy(gameObject);
    }
}