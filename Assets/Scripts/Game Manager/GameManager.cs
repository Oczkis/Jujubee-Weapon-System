using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public List<IManager> _managers = new List<IManager>();

    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else if (Instance != this) { Destroy(this); }

        _managers =  GetComponentsInChildren<IManager>().ToList();
    }

    public bool TryGetManager<T>(out T manager)
    {
        foreach (IManager possibleManager in _managers)
        {
            if(possibleManager is T)
            {
                manager = (T)possibleManager;
                return true;
            }
        }

        manager = default;
        Debug.LogError($"Manager {typeof(T)} was not found!");
        return false;
    }
}
