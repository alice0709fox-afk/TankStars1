using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class CharacterSpawnerBase : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private SuitableUnitFinder unitFinder;
    [Space]
    [SerializeField] private PlayerInitializer playerInitializer;
    [SerializeField] private BotInitializer botInitializer;

    public static Action PlayerInitialized;
    
    protected GameObject PlayerPrefab => playerPrefab;
    protected SuitableUnitFinder UnitFinder => unitFinder;
    
 
    public abstract void SpawnAllCharacters();

    public virtual GameObject Spawn(GameObject character, TeamData team, Vector3 position, Quaternion rotation)
    {
      var tempCharacter = Instantiate(character, position, rotation);
      return tempCharacter;
    }

    protected virtual void InitializePlayer(GameObject character, TeamData team, bool isInvertedZ, bool isInvertedX)
    {
        playerInitializer.Initialize(character, team);
        playerInitializer.InitializeInverted(isInvertedZ, isInvertedX);
    }
    protected virtual void InitializeBot(GameObject character, TeamData team)  => botInitializer.Initialize(character, team);
}