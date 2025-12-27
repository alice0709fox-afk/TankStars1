using System;
using UnityEngine;

[RequireComponent(typeof(BotHealthStats))]
[RequireComponent(typeof(BotTargetDetector))]
[RequireComponent(typeof(BotCombatController))]
[RequireComponent(typeof(BotCoverPointDetector))]
public class BotStateController : MonoBehaviour
{
    private enum State
    {
        Patrol = 0,
        Attack = 1,
        Hide = 2,
        Retreat = 3
    }

    private BotHealthStats _health;
    private BotCombatController _combatController;
    private BotCoverPointDetector _coverPointDetector;
    private BotTargetDetector _targetDetector;
    private BotMovementBase _movement;

    private void Start()
    {
        _movement = GetComponentInChildren<BotMovementBase>();
        _targetDetector = GetComponent<BotTargetDetector>();
        _coverPointDetector = GetComponent<BotCoverPointDetector>();
        _health = GetComponent<BotHealthStats>();
        _combatController = GetComponent<BotCombatController>();
        
        _combatController.Initialization(_movement, _targetDetector);
    }

    private void FixedUpdate()
    {
        var enemy = _targetDetector.GetTarget();
        var cover = _coverPointDetector.GetTarget();

        if (enemy)
        {
            _combatController.Attack(enemy);
        }
        else if (cover)
        {
            _movement.MoveTo(cover.position);
        }
        else
        {
            _movement.MoveToRandomPointNearInterest();
        }
    }
}