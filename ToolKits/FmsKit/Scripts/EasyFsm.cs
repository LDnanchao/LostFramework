using System;
using UnityEngine;

namespace LostFramework
{
    
    /// <summary>
    /// 简易状态机
    /// </summary>
    public interface IEasyFsm
    {
        void StartFsm();
        void Update();
        void FixedUpdate();
        void Clear();
        void SetOwner(GameObject go);
    }

    public class EasyFsm<T>:IEasyFsm
    {
        public T currentState;
        public GameObject gameObject;

        public virtual void StartFsm()
        {
            
        }
        public virtual void Update()
        {
            
        }

        public virtual void FixedUpdate()
        {
            
        }

        public virtual void Clear()
        {
            
        }

        public void SetOwner(GameObject go)
        {
            gameObject = go;
        }

        protected virtual void SwitchState(T t)
        {
            currentState = t;
        }
    }
}