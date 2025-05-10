using UnityEngine;
using System.Collections.Generic;

public class Passenger : MonoBehaviour
{
    public SpriteRenderer rend;

    // 色名に対応したスプライトを格納した辞書
    private static Dictionary<string, Sprite> spriteMap;

    // このセルの色（実際は列挙型や int で管理してもOK）
    public Color passengerColor;

    void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    public void Initialize(string colorKey)
    {
        if (spriteMap == null)
            LoadAllSprites();

        if (spriteMap.TryGetValue(colorKey, out var sprite))
        {
            rend.sprite = sprite;
        }
    }

    private void LoadAllSprites()
    {
        spriteMap = new Dictionary<string, Sprite>();
        var folderPath = "Art/Passengers"; // Resources 以下に置く場合
        var loaded = Resources.LoadAll<Sprite>(folderPath);
        foreach (var sp in loaded)
        {
            // ファイル名から "_<color>" 部分を抜き出してキーに
            var name = sp.name; // ex. "passenger_red"
            var key = name.Substring("passenger_".Length);
            spriteMap[key] = sp;
        }
    }

    // クリック時に呼ばれる
    private void OnMouseDown()
    {
        GridManager.Instance.OnPassengerClicked(this);
    }

    // セルを消す演出（SPAWN/DESTROY）
    public void DestroyPassenger()
    {
        // 簡易的に消す
        Destroy(gameObject);
    }
}