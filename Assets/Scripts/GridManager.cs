using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Transform _cam;
    [SerializeField] private GridLayoutGroup _layoutGroup;
    private Dictionary<Vector2, Tile> _tiles;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        _tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                //var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                //spawnedTile.Init(isOffset);
                _tiles[new Vector2(x, y)] = spawnedTile;
                spawnedTile.transform.SetParent(_layoutGroup.transform, false);
            }
        }

        //_cam.transform.position = new Vector3((float)_width / 2, (float)_height / 2 , -10);
    }

    public Tile GetTileAtPosition(Vector2 pos)  
    {
        if (_tiles.TryGetValue(pos, out var tile)) return tile;
        return null;
    }
}
      
