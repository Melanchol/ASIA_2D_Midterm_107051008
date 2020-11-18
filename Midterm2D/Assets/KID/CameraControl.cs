using UnityEngine;

namespace KID
{
    public class CameraControl : MonoBehaviour
    {
        [Header("要追蹤的物件")]
        public Transform target;
        [Header("追蹤速度"), Range(0, 100)]
        public float speed = 5;
        [Header("上下限制")]
        public Vector2 limitup = new Vector2(0, 2f);
        [Header("左右限制")]
        public Vector2 limitleft = new Vector2(0, 1f);
        private void LateUpdate()
        {
            Track();
        }

        private void Track()
        {
            Vector3 posA = target.position;
            posA.x = Mathf.Clamp(posA.x, limitleft.x, limitleft.y);
            posA.y = Mathf.Clamp(posA.y, limitup.x, limitup.y);
            posA.z = -10;
            transform.position = Vector3.Slerp(transform.position, posA, Time.deltaTime * speed);
            
            
         }
      
    }
}
