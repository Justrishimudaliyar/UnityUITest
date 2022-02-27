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
            var newRow = Instantiate(Column, transform.position, Quaternion.identity);
            newRow.transform.SetParent(gameObject.transform);

            for (int col = 0; col < _columns; col++)
            {
                var newTile = Instantiate(GridElement, transform.position, Quaternion.identity);
                newTile.transform.SetParent(newRow.transform);

                newTile.GetComponent<GridElement>().SetPosition(row, col);
                Grid[row, col] = newTile.GetComponent<GridElement>();
            }
        }
    }
}
      

