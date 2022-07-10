using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private GameObject _prefab;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(2f);
    private Transform[] _points;
    private Coroutine _spawn;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
        _spawn = StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            Transform target = _points[i];
            Instantiate(_prefab, target);
            yield return _waitForSeconds;
        }
    }
}
