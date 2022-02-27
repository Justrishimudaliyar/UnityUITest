using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class GridElement : MonoBehaviour, IPointerClickHandler
{

    public int rowNumber;
    public int columnNumber;
    public int gridElementNumber = 1;
    public Color gridElementColor;
    public TextMeshProUGUI gridElementText;

    public void SetPosition(int row, int col)
    {
        rowNumber = row;
        columnNumber = col;
    }

    public void GenerateGridElementNumber(int columns)
    {
        gridElementNumber = rowNumber * columns + columnNumber + 1;
        gridElementNumber = Random.Range(0, gridElementNumber);
    }

    public void GenerateGridElementColor()
    {
        gridElementColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    public void OpenGridElement()
    {
        gridElementText.text = gridElementNumber.ToString();
        gameObject.GetComponent<Image>().color = gridElementColor;
    }

    private void OnMouseEnter()
    {
        gridElementText.enabled = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        print("I was clicked");
        Debug.Log(this.gameObject.name);
    }

}
