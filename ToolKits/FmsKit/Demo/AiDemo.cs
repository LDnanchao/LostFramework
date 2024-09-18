using System;
using UnityEngine;

namespace LostFramework
{
    public class AiDemo:MonoBehaviour
    {
        public AiBrain aiBrain;
        private void Start()
        {
            //Wait状态
            AiState waitState = aiBrain.InitState("Wait");
            SearchTargetAction searchTargetAction = waitState.AddAction<SearchTargetAction>();
            searchTargetAction.distance = 10f;
            TargetIsHaveDetermine targetIsHaveDetermine = waitState.AddDetermine<TargetIsHaveDetermine>();
            targetIsHaveDetermine.TrueTag = "Move";
            //Move状态
            AiState moveState = aiBrain.InitState("Move");
            MoveToTargetAction moveToTargetAction = moveState.AddAction<MoveToTargetAction>();
            moveToTargetAction.distance = 1f;
            TargetIsLostDetermine targetIsLostDetermine = moveState.AddDetermine<TargetIsLostDetermine>();
            targetIsLostDetermine.distance = 10f;
            targetIsLostDetermine.FalseTag = "Wait";
            CanAttckDetermine canAttckDetermine = moveState.AddDetermine<CanAttckDetermine>();
            canAttckDetermine.distance = 1f;
            canAttckDetermine.TrueTag = "Attack";
            //攻击状态
            AiState attackState = aiBrain.InitState("Attack");
            attackState.AddAction<NormalAttackAction>();
            TargetIsLostDetermine targetIsLostDetermine1 = attackState.AddDetermine<TargetIsLostDetermine>();
            targetIsLostDetermine1.distance = 10;
            targetIsLostDetermine1.TrueTag = "Wait";

            aiBrain.StartState("Wait");
        }

        private void Update()
        {
            aiBrain.Update();
        }

        private void FixedUpdate()
        {
            aiBrain.FixedUpdate();
        }

        private void OnDestroy()
        {
            aiBrain.Clear();
        }
    }

    internal class NormalAttackAction:AiAction
    {
        
        public override void Start()
        {
           
        }

        public override void Update()
        {
            
        }
    }

    internal class TargetIsHaveDetermine:AiDetermine
    {
        public override bool Update()
        {
            return aiBrain.target!= null;
        }
        
    }

    internal class SearchTargetAction:AiAction
    {
        public float distance;
    }

    internal class CanAttckDetermine:AiDetermine
    {
        public float distance = 1;
    }

    internal class TargetIsLostDetermine:AiDetermine
    {
        public float distance = 5;
    }
    public class MoveToTargetAction:AiAction
    {
        public float distance;

        public override void Start()
        {
            //获得储存的对象
            GameObject target = aiBrain.target;
        }

        public override void Update()
        {
            
        }

        public override void FixedUpdate()
        {
            
        }

        public override void End()
        {
            //重置数据
        }
    }
}