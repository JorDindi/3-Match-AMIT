using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public sealed class Board : MonoBehaviour
{
    public static Board Instance { get; private set; } //Easy access to get and set properties outside the script.

    public Row[] rows; //Collect row data.
    public Tile[,] Tiles { get; private set; } //Easy access to get and set properties outside the script.

    public int Width => Tiles.GetLength(0); //Turn the width of the tile to desired dimensions.
    public int Height => Tiles.GetLength(1); // Turn the height of the tile to desired dimensions.

    private readonly List<Tile> _selection = new List<Tile>();

    private const float TweenDuration = 0.25f;

    private void Awake() => Instance = this; //When the game is activated (Before 'Frame 1', this script will be the Instance of itself to ignore collisions.

    private void Start() //When the game is activated (IN 'Frame 1')
    {
        Tiles = new Tile[rows.Max(row => row.tiles.Length), rows.Length]; //Sets desired dimensions of the tiles.

        for (var y = 0; y < Height; y++) //Looping through all X and Y values to get an indication on how big the board need to be.
        { 
            for (var x =0; x < Width; x++)
            {
                var tile = rows[y].tiles[x];

                tile.x = x;
                tile.y = y;

                tile.Item = ItemDatabase.Items[Random.Range(0, ItemDatabase.Items.Length)];
                Tiles[x, y] = rows[y].tiles[x];
            }
        } 
    }

    public async void Select(Tile tile) //Selecting current tile that was clicked
    {

        if(!_selection.Contains(tile)) _selection.Add(tile); //If the selection don't contain he tile, add the tile to the list

        if (_selection.Count < 2) return; //If 2 tiles are selected or more, return;

        Debug.Log($"Selected tiles at ({_selection[0].x}, {_selection[0].y}) and ({_selection[1].x},{_selection[1].y})"); //Testing

        await Swap(_selection[0], _selection[1]); //Calling an async method and waiting for it to finish.

        _selection.Clear(); //Clearing the list
    }

    public async Task Swap(Tile tile1, Tile tile2)
    {
        var icon1 = tile1.icon;
        var icon2 = tile2.icon; 

        var icon1Transform = icon1.transform;
        var icon2Transform = icon2.transform;

        var sequence = DOTween.Sequence();

        sequence.Join(icon1Transform.DOMove(icon2Transform.position, TweenDuration))
                .Join(icon2Transform.DOMove(icon1Transform.position, TweenDuration));

        await sequence.Play().AsyncWaitForCompletion();


        icon1Transform.SetParent(tile2.transform);
        icon2Transform.SetParent(tile1.transform);

        tile1.icon = icon2;
        tile2.icon = icon1;

        var tile1Item = tile1.Item;

        tile1.Item = tile2.Item;
        tile2.Item = tile1Item;
    }

    //private bool CanPop()
    //{
    //    for(var y = 0; y < Height; y++)
    //    {
    //        for(var x = 0; x < Width; x++)
    //        {
    //            if (Tiles[x, y].GetConnectedTiles().Skip(1));
    //        }
    //    }

   // }

    private void Pop()
    {
        throw new System.NotImplementedException();
    }
}