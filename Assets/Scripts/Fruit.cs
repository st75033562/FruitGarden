using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public enum Mold
    {
        Apple,
        Banana,
        Kiwi,
        Orange,
        Pear,
        Pineapple,
        Strawberry
    }
    public Mold fruitMold;
    private int x;
    private int y;

    private Action<int, int> clickBack; 

    public void SetIndex(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public void SetListClick(Action<int, int> clickBack)
    {
        this.clickBack = clickBack;
    }

    void OnMouseDown()
    {
        clickBack(x, y);
    }
}
