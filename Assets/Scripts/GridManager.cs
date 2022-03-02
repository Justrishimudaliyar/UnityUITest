using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _rows, _columns;
    [SerializeField] private GameObject Row;
    [SerializeField] private int areaOfInterest;
    private List<GameObject> Rows;
    [SerializeField] private GridElement GridElement;
    [HideInInspector] public GridElement[ , ] Grid;

    [SerializeField] private GameObject UIPanel;
    [SerializeField] private Slider sliderRow;
    [SerializeField] private TextMeshProUGUI numberRow;
    [SerializeField] private Slider sliderColumn;
    [SerializeField] private TextMeshProUGUI numberColumn;
    [SerializeField] private Slider sliderAreaOfInterest;
    [SerializeField] private TextMeshProUGUI numberAreaOfInterest;

    private void Start()
    {
        Rows = new List<GameObject>();
        GenerateGrid();
        AssignListeners();
    }

    public void GenerateGrid()
    {
        Grid = new GridElement[_rows, _columns];
        for (int row = 0; row < _rows; row++)
        {
            var newRow = Instantiate(Row, transform.position, Quaternion.identity);
            Rows.Add(newRow);
            newRow.transform.SetParent(gameObject.transform);

            for (int col = 0; col < _columns; col++)
            {
                var newGridElement = Instantiate(GridElement, transform.position, Quaternion.identity);
                newGridElement.transform.SetParent(newRow.transform);
                newGridElement.name = $"gridElement {row} {col}";

                newGridElement.SetPosition(row, col);
                newGridElement.GenerateGridElementNumber(_columns);
                newGridElement.GenerateGridElementColor();
                newGridElement.OnClickGridElement += OpenGridElements;

                Grid[row, col] = newGridElement.GetComponent<GridElement>();
            }
        }
    }
    private void AssignListeners()
    {
        sliderRow.onValueChanged.AddListener((v) => {
            numberRow.text = v.ToString();
        });

        sliderColumn.onValueChanged.AddListener((v) => {
            numberColumn.text = v.ToString();
        });

        sliderAreaOfInterest.onValueChanged.AddListener((v) => {
            numberAreaOfInterest.text = v.ToString();
        });
    }
    public void OpenGridElements(int row, int col)
    {
        for (int a = -areaOfInterest; a <= areaOfInterest; a++)
        {
            for (int b = -areaOfInterest; b <= areaOfInterest; b++)
            {
                if (row + a < 0 || col + b < 0 || row + a > _rows - 1 || col + b > _columns - 1 || Grid[row + a, col + b].isActive)
                {
                    continue;
                }
                Grid[row + a, col + b].OpenGridElement();
                Grid[row + a, col + b].OnClickGridElement -= OpenGridElements;
            }
        }
    }

    public void CreateNewGrid()
    {
        foreach (GameObject row in Rows)
        {
            Destroy(row);
        }

        _rows = (int)sliderRow.value;
        _columns = (int)sliderColumn.value;
        areaOfInterest = (int)sliderAreaOfInterest.value;

        GenerateGrid();

        ToggleResetPanel(false);
    }

    public void ToggleResetPanel(bool isActive)
    {
        UIPanel.SetActive(isActive);
    }


}


