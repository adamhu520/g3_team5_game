using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

namespace GameStartStudio
{
    public abstract class U : MonoBehaviour
    {
        private CanvasGroup canvasGroup;

        public virtual void OnInit() {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = gameObject.AddComponent<CanvasGroup>();
            }
        }
        public virtual void Onen() { }
        public virtual void OnUpdate() { }
        public virtual void OnClose() { }
        public virtual void OnRecycle() { }

        public void PlaySound() { }

    }

}

