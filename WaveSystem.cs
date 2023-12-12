using System.Collections;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    [SerializeField] Transform _spawnLocation;
    [SerializeField] private WaveSO[] _waves;

    private int _currentWave = 0;
    private int _currentEntityGroup = 0;
    private float _timeBetweenWaves = 5.0f;
    private float _timeBetweenEntities = 1.0f;

    private void Start()
    {
        StartCoroutine(StartWaveSystem());
    }

    private IEnumerator StartWaveSystem()
    {
        foreach (WaveSO wave in _waves)
        {
            yield return StartCoroutine(StartNextWave());
            yield return new WaitForSeconds(_timeBetweenWaves);
        }
    }

    private IEnumerator StartNextWave()
    {
        foreach (WaveSO.EntityGroup entityGroup in GetCurrentWave().EntityGroups)
        {
            yield return StartCoroutine(SpawnNextEntityGroup());
            yield return new WaitForSeconds(_timeBetweenEntities);
        }
        _currentEntityGroup = 0;
        _currentWave++;
    }

    private IEnumerator SpawnNextEntityGroup()
    {
        for (int i = 0; i < GetCurrentEntityGroup()._amount; i++)
        {
            Instantiate(GetCurrentEntityGroup()._transform, _spawnLocation.position, Quaternion.identity);
            yield return new WaitForSeconds(_timeBetweenEntities);
        }
        _currentEntityGroup++;
    }

    private WaveSO GetCurrentWave() => _waves[_currentWave];
    private WaveSO.EntityGroup GetCurrentEntityGroup() => GetCurrentWave().EntityGroups[_currentEntityGroup];
}