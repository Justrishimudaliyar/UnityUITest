using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridElement : MonoBehaviour
{
    public int rowNumber;
    public int columnNumber;
    public int tileNumber = 1;
    public Color tileColor;
    public TextMeshProUGUI tileText;

 
    public void SetPosition(int row, int col)
    {
        rowNumber = row;
        columnNumber = col;
    }

    public void GenerateTileNumber(int columns)
    {
        tileNumber = rowNumber * columns + columnNumber + 1;
        tileNumber = Random.Range(0, tileNumber);
    }

    public void GenerateTileColor()
    {
        tileColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    public void OpenTile()
    {
        tileText.text = tileNumber.ToString();
        gameObject.GetComponent<Image>().color = tileColor;
    }

}
