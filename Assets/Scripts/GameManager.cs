using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public FruitsManager fruitManager;

    private Fruit[,] fruitArray = new Fruit[5, 5];
    void Start () {
        InitFruits();

    }

    void InitFruits()
    {
        for (int i = 0; i < fruitArray.GetLength(0); i++)
        {
            for (int j = 0; j < fruitArray.GetLength(1); j++)
            {
                var go = fruitManager.RandomCreateFruit(i, j);
                var fruit = go.GetComponent<Fruit>();
                fruit.SetIndex(i, j);
                fruit.SetListClick(ClickFruit);
                fruitArray[i, j] = fruit;
            }
        }
    }

    void ClickFruit(int x, int y)
    {
        List<Fruit> fruits = new List<Fruit>();
        fruits.Add(fruitArray[x, y]);
        FindNearSameFruit(x, y, fruits);
        foreach (var go in fruits) {
            go.gameObject.SetActive(false);
        }
       // fruitArray[x, y].gameObject.SetActive(false);
       
    }

    void FindNearSameFruit(int x, int y, List<Fruit> fruits)
    {
        if (x > 0)  //向左
        {
            if (fruitArray[x - 1, y].fruitMold == fruitArray[x, y].fruitMold && !fruits.Contains(fruitArray[x - 1, y]))
            {
                fruits.Add(fruitArray[x - 1, y]);
                FindNearSameFruit(x - 1, y, fruits);
            }
        }
        if (x < fruitArray.GetLength(0) - 1)  //向右
        {
            if (fruitArray[x + 1, y].fruitMold == fruitArray[x, y].fruitMold && !fruits.Contains(fruitArray[x + 1, y]))
            {
                fruits.Add(fruitArray[x + 1, y]);
                FindNearSameFruit(x + 1, y, fruits);
            }
        }
        if (y < fruitArray.GetLength(1) - 1)  //向上
        {
            if (fruitArray[x, y + 1].fruitMold == fruitArray[x, y].fruitMold && !fruits.Contains(fruitArray[x, y + 1]))
            {
                fruits.Add(fruitArray[x, y + 1]);
                FindNearSameFruit(x, y + 1, fruits);
            }
        }
        if (y > 0)  //向下
        {
            if (fruitArray[x, y - 1].fruitMold == fruitArray[x, y].fruitMold && !fruits.Contains(fruitArray[x, y - 1]))
            {
                fruits.Add(fruitArray[x, y - 1]);
                FindNearSameFruit(x, y - 1, fruits);
            }
        }
    }
}
