using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _rows, _columns;
    [SerializeField] private GameObject Row;
    [SerializeField] private GridElement GridElement;
    [HideInInspector] public GridElement[ , ] Grid;
    public int areaOfInterest;

    private void Start()
    {
        Grid = new GridElement[_rows, _columns];
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        for (int row = 0; row < _rows; row++)
        {
            var newRow = Instantiate(Row, transform.position, Quaternion.identity);
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
                //newGridElement.GetComponent<GridElement>().OpenGridElement();

                Grid[row, col] = newGridElement.GetComponent<GridElement>();
            }
        }
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

}
      

