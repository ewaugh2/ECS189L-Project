using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
	[SerializeField] private GameObject mapObject;

	private static MapManager instance;

	public static MapManager GetInstance()
	{
		return instance;
	}

	public GameObject GetMap()
	{
		return mapObject;
	}
    void Awake()
    {
        instance = this;
    }
}
