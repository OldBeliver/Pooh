using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;    

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        GameObject spawned = Instantiate(prefab, _container.transform);
        
        spawned.SetActive(false);

        _pool.Add(spawned);
    }

    protected bool TryGetBee(out GameObject result)
    {
        result = _pool.First(bee => bee.activeSelf == false);

        return result != null;
    }
}
