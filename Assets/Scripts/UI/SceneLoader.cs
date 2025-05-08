using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // Button を使うなら

public class SceneLoader : MonoBehaviour
{
    // 遷移したいシーン名を Inspector から設定できる
    [SerializeField] private string sceneName;

    // UI Button の OnClick() に登録するメソッド
    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
            SceneManager.LoadScene(sceneName);
        else
            Debug.LogWarning("SceneLoader: sceneName が設定されていません");
    }
}