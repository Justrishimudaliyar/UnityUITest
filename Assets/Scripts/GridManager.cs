using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _rows, _columns;
    [SerializeField] private GameObject Column;
    [SerializeField] private GameObject GridElement;
    [HideInInspector] public GridElement[,] Grid;

    private void Start()
    {
        Grid = new GridElement[_rows, _columns];
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        for (int row = 0; row < _rows; row++)
        {
            var newColumn = Instantiate(Column, transform.position, Quaternion.identity);
            newColumn.transform.SetParent(gameObject.transform);

            for (int col = 0; col < _columns; col++)
            {
                var newGridElement = Instantiate(GridElement, transform.position, Quaternion.identity);
                newGridElement.transform.SetParent(newColumn.transform);

                newGridElement.GetComponent<GridElement>().SetPosition(row, col);
                newGridElement.GetComponent<GridElement>().GenerateTileNumber(_columns);
                newGridElement.GetComponent<GridElement>().GenerateTileColor();
                newGridElement.GetComponent<GridElement>().OpenTile();

                Grid[row, col] = newGridElement.GetComponent<GridElement>();
            }
        }
    }
}
      

