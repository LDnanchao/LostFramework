using System;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace LostFramework
{
    
    /// <summary>
    /// 简易状态机,异步类型，不由update进行处理
    /// </summary>
    public interface IEasyFsmAsync
    {
        void Clear();
        void SetOwner(GameObject go);
    }

    public class EasyFsmAsync<T>:IEasyFsmAsync
    {
        public T currentState;
        public GameObject gameObject;
        private CancellationTokenSource cts =new CancellationTokenSource();
        private bool isRun = false;
        public virtual async UniTaskVoid StartFsm(GameObject go)
        {
            await Start(go);
        }

        private async UniTask Start(GameObject go)
        {
            if(go==null)
                return;
            cts?.Cancel();
            isRun = true;
            gameObject = go;
            while(isRun)
            {
                await Update();
            }
        }

        public async virtual UniTask Update()
        {
            await UniTask.Yield();
        }
        public virtual void Clear()
        {
            cts?.Cancel();
            isRun = false;
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