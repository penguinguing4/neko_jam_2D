using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    /// <summary>MainScene を再読み込み</summary>
    public void OnRestartButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    /// <summary>TitleScene へ戻る</summary>
    public void OnHomeButton()
    {
        SceneManager.LoadScene("TitleScene");
    }

    /// <summary>ヒント（今はダミー）</summary>
    public void OnHintButton()
    {
        Debug.Log("Hintボタンが押されました（ダミー実装）");
        // 将来ここで広告表示やヒントダイアログを開く
    }
}