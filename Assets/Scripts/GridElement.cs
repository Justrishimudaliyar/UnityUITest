using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class GridElement : MonoBehaviour
{
    public int rowNumber;
    public int columnNumber;
    public int gridElementNumber = 1;
    public Color gridElementColor;
    public TextMeshProUGUI gridElementText;
    [SerializeField]
    private Button gridElementButton;
    public bool isActive;

    public event Action<int, int> OnClickGridElement;

    private void Start()
    {
        isActive = false;
        gridElementButton = gameObject.GetComponent<Button>();
        gridElementButton.onClick.AddListener(OpenGridElement);
    }
    public void SetPosition(int row, int col)
    {
        rowNumber = row;
        columnNumber = col;
    }

    public void GenerateGridElementNumber(int columns)
    {
        gridElementNumber = rowNumber * columns + columnNumber + 1;
        gridElementNumber = UnityEngine.Random.Range(0, gridElementNumber);
    }

    public void GenerateGridElementColor()
    {
        gridElementColor = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
    }

    public void OnGridElementClick()
    {
        OnClickGridElement?.Invoke(rowNumber, columnNumber);
    }
    public void OpenGridElement()
    {
        gridElementText.text = gridElementNumber.ToString();
        gameObject.GetComponent<Image>().color = gridElementColor;
        Debug.Log(this.gameObject.name);
        isActive = true;
    }

    
}
