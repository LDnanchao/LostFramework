using UnityEngine;

namespace LostFramework
{
    public class EasyFsmManager : MonoBehaviour
    {
        private IEasyFsm _fsm = null;
        public void Run(IEasyFsm fsm)
        {
            if(fsm==null)
                return;
            
            _fsm = fsm;
            _fsm.SetOwner(gameObject);
            _fsm.StartFsm();
        }

        private void Update()
        {
            _fsm?.Update();
        }

        private void FixedUpdate()
        {
            _fsm?.FixedUpdate();
        }

        public void ClearFsm()
        {
            _fsm?.Clear();
        }
        private void OnDestroy()
        {
            ClearFsm();
            _fsm = null;
        }
    }
}