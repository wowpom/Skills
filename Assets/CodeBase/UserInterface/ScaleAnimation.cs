using System.Collections;
using UnityEngine;

namespace CodeBase.UserInterface
{
    public class ScaleAnimation : MonoBehaviour
    {
        private const float BaseScaleFactor = 1f;
        private Vector3 _startLocalScale;

        private void Awake() => 
            _startLocalScale = transform.localScale;

        private void OnEnable() => 
            StartCoroutine(Animation());

        private IEnumerator Animation()
        {
            float scaleFactor = 1f;
            float time = 0;
        
            while (isActiveAndEnabled)
            {
                scaleFactor = Mathf.PingPong(time, BaseScaleFactor) + BaseScaleFactor;
                transform.localScale = _startLocalScale * scaleFactor;
                yield return null;
                time += Time.deltaTime;
            }
        }
    }
}
