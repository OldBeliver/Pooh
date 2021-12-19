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
    
    private List<GameObject> _pool = new List<GameObject>();
    
    private void Start()
    {
        LoadObjectPool(_quantity);

        StartCoroutine(SpawnBee());
    }

    private IEnumerator SpawnBee()
    {   
        int randomPoint = Random.Range(0, _spawnPointers.Length);

        Transform coordinate = _spawnPointers[randomPoint];

        if (TryGetBee(out GameObject bee))
        {
            bee.transform.position = coordinate.position;

            TryFlipSprite(bee);

            bee.SetActive(true);

            yield return new WaitForSeconds(2f);
        }

        StartCoroutine(SpawnBee());
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
        result = _pool.First(subject => subject.activeSelf == false);

        return result != null;
    }

    private void TryFlipSprite(GameObject subject)
    {
        SpriteRenderer sprite = subject.GetComponent<SpriteRenderer>();
        sprite.flipX = false;

        if (subject.transform.position.x < 0)
            sprite.flipX = true;
    }
}
