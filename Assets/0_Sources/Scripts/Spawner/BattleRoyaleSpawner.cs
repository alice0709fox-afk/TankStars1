using System.Collections.Generic;
using UnityEngine;

public class BattleRoyaleSpawner : CharacterSpawnerBase
{
    [SerializeField] private Transform[] spawnPoints;

    private List<Transform> _availableSpawnPoints;
    
    protected virtual void Awake()
    {
        _availableSpawnPoints = new List<Transform>(spawnPoints);
    }

    public override void SpawnAllCharacters()
    {
        
    }

    public Transform GetRandomFreeSpawnPoint()
    {
        if (_availableSpawnPoints.Count == 0)
        {
            Debug.LogError("No available spawn points");
            return null;
        }
        
        int index = Random.Range(0, _availableSpawnPoints.Count);
        Transform point =  _availableSpawnPoints[index];
        _availableSpawnPoints.RemoveAt(index);
        return point;
    }
}
