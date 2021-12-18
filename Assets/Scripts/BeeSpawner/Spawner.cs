using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _subject;
    [SerializeField] private Transform[] _spawnPointers;
    [SerializeField] private GameObject _container;
    [SerializeField] private int _quantity;

    private bool canSpawn = true;
    private List<GameObject> _pool = new List<GameObject>();

    private void Start()
    {
        LoadObjectPool(_quantity);
    }

    private void Update()
    {
        if (canSpawn)
            StartCoroutine(SpawnBee());
    }

    private IEnumerator SpawnBee()
    {
        canSpawn = false;

        int randomPoint = Random.Range(0, _spawnPointers.Length);
        int randomBee = Random.Range(0, _pool.Count);

        Transform coordinate = _spawnPointers[randomPoint];
        
        if (TryGetBee(out GameObject bee))
        {
            bee.transform.position = coordinate.position;
            bee.SetActive(true);

            yield return new WaitForSeconds(2f);
        }

        canSpawn = true;
    }

    private void LoadObjectPool(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject spawned = Instantiate(_subject, _container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    private bool TryGetBee(out GameObject result)
    {
        result = _pool.First(p => p.activeSelf == false);

        return result != null;
    }
}
