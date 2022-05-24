using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnist : ObjectPool
{
    [SerializeField] private GameObject _bee;
    [SerializeField] private Transform[] _spawnPoints;    
    [SerializeField] private int _quantity;

    private void Start()
    {
        CreateBees(_quantity);

        StartCoroutine(SpawnBee());
    }

    private IEnumerator SpawnBee()
    {
        int randomPoint = Random.Range(0, _spawnPoints.Length);

        Transform coordinate = _spawnPoints[randomPoint];

        if (TryGetBee(out GameObject bee))
        {
            bee.transform.position = coordinate.position;

            TryFlipSprite(bee);

            bee.SetActive(true);

            yield return new WaitForSeconds(2f);
        }

        StartCoroutine(SpawnBee());
    }

    private void TryFlipSprite(GameObject subject)
    {
        SpriteRenderer sprite = subject.GetComponent<SpriteRenderer>();
        sprite.flipX = false;

        if (subject.transform.position.x < 0)
            sprite.flipX = true;
    }

    private void CreateBees(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Initialize(_bee);
        }
    }
}
