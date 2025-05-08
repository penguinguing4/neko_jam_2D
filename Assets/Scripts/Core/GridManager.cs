using UnityEngine;
using UnityEngine.SceneManagement;

public class GridManager : MonoBehaviour
{
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
            var cell = go.GetComponent<Cell>();
            Color randColor = new Color[] {
                Color.red, Color.blue, Color.green, Color.yellow
            }[Random.Range(0, 4)];
            cell.Initialize(randColor);
        }
    }

    public void OnCellClicked(Cell cell)
    {
        cell.DestroyCell();
        remainingCells--;
        if (remainingCells <= 0)
            SceneManager.LoadScene("ResultScene");
    }
}