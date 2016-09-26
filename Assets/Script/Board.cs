using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Board : MonoBehaviour {

    public GameObject CrossPrefab;

    const float CrossSize = 40;

    public const int CrossCount = 15;

    public const int Size = 550;
    public const int HalfSize = Size/2;

    Dictionary<int, Cross> crossMap = new Dictionary<int, Cross>();

    static int MakeKey(int x, int y)
    {
        return x * 10000 + y;
    }

    void Reset()
    {
        for (int i = 0; i < CrossCount; i++)
        {
            for (int j = 0; j < CrossCount; j++)
            {
                GameObject crossObject = GameObject.Instantiate<GameObject>(CrossPrefab);
                crossObject.transform.SetParent(gameObject.transform);

                crossObject.transform.localScale = Vector3.one;

                crossObject.transform.localPosition = new Vector3(CrossSize * i - HalfSize, CrossSize * j - HalfSize, 1);

                var cross = crossObject.GetComponent<Cross>();
                cross.GridX = i;
                cross.GridY = j;

                crossMap.Add(MakeKey(i, j), cross);
            }   
        }
    }

    public Cross GetCross(int gridX, int gridY)
    {
        Cross cross;
        if (crossMap.TryGetValue(MakeKey(gridX, gridY), out cross))
        {
            return cross;
        }
        return null;
    }

    void Start()
    {
        Reset();
    }

}
