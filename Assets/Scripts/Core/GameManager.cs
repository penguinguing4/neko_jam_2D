using UnityEngine;
using TMPro;      // TextMeshPro 用
using UnityEngine.UI;  // Image 用（バー派）

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    void Awake()
    {
        // 既にいたら自分を消す、いなければ自分をインスタンスに
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        movesRemaining = initialMoves;
        UpdateMoveUI();
    }




    [Header("Move Count Settings")]
    public int initialMoves = 5;      // 初期出庫回数
    private int movesRemaining;

    [Header("UI References")]
    public TMP_Text moveCountText;    // 数字派用
    public Image moveCountBarFill;    // バー派用


    /// <summary>
    /// バスを“出庫”するたびに呼ぶ
    /// </summary>
    public void ConsumeMove()
    {
        Debug.Log($"ConsumeMove called. Remaining before: {movesRemaining}");
        if (movesRemaining <= 0) return;
        movesRemaining--;
        UpdateMoveUI();

        if (movesRemaining == 0)
        {
            OnOutOfMoves();
        }
    }

    /// <summary>
    /// UI の更新
    /// </summary>
    private void UpdateMoveUI()
    {
        if (moveCountText != null)
        {
            moveCountText.text = $"Moves: {movesRemaining}";
        }
        if (moveCountBarFill != null)
        {
            float t = (float)movesRemaining / initialMoves;
            moveCountBarFill.fillAmount = t;
        }
    }

    /// <summary>
    /// 手数が尽きたときの処理
    /// </summary>
    private void OnOutOfMoves()
    {
        // 例：ResultScene に遷移
        UnityEngine.SceneManagement.SceneManager.LoadScene("ResultScene");
    }
}