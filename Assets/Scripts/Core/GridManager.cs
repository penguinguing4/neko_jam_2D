using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // 追加



public class GridManager : MonoBehaviour
{
    [Header("Passenger Color Keys")]
    [SerializeField]
    private string[] colorKeys = new string[]
        { "red", "blue", "green", "yellow", "pink", "purple", "brown", "white" };

        // 既存コード...

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI remainingCountText;  // 追加

    void Update()
    {
        // 毎フレーム残りセル数を更新
        if (remainingCountText != null)
            remainingCountText.text = $"残り乗客：{remainingCells}";
    }
    public static GridManager Instance { get; private set; }

    [Header("Grid Settings")]
    public GameObject cellPrefab;
    public int columns = 6, rows = 7;
    public float cellSpacing = 1.1f;

    private int remainingCells;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        GenerateGrid();
    }



    void GenerateGrid()
    {
        remainingCells = columns * rows;
        for (int x = 0; x < columns; x++)
        for (int y = 0; y < rows; y++)
        {
            Vector2 pos = new Vector2(
                x * cellSpacing - (columns - 1) * cellSpacing / 2f,
                y * -cellSpacing + (rows - 1) * cellSpacing / 2f
            );
            var go = Instantiate(cellPrefab, pos, Quaternion.identity, transform);
            var passenger = go.GetComponent<Passenger>();
            // ランダムに文字列キーを選択
            string randKey = colorKeys[Random.Range(0, colorKeys.Length)];
            passenger.Initialize(randKey);
        }
    }

public void OnPassengerClicked(Passenger passenger)
{
    // 1) セル（乗客）を回収
    passenger.DestroyPassenger();
    remainingCells--;

    // 2) 'バス出庫' と見なして残り手数を１つ減らす
    GameManager.Instance.ConsumeMove();

    // 3) すべて回収できたら ResultScene へ
    if (remainingCells <= 0)
        SceneManager.LoadScene("ResultScene");
}
}