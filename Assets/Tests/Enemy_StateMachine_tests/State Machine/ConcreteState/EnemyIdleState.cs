using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    private Vector3 _targetPos;
    private Vector3 _direction;
    public EnemyIdleState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }
    public override void EnterState(){
        base.EnterState();
        _targetPos = GetRandomPointCircle();
    }
    public override void ExitState(){
        base.ExitState();
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    public override void FrameUpdate()
    {
        
        base.FrameUpdate();
        _direction = (_targetPos - enemy.transform.position).normalized;
        enemy.MoveEnemy(_direction*enemy.RandomMovementSpeed);
        if((enemy.transform.position - _targetPos).sqrMagnitude < 0.01f){
            _targetPos = GetRandomPointCircle();
        } 
    }
    public override void AnimationTriggerEvent(Enemy.AnimaitonTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }
        private Vector3 GetRandomPointCircle()
    {
        return enemy.transform.position + (Vector3)UnityEngine.Random.insideUnitCircle*enemy.RandomMovementRange;
    }




}
