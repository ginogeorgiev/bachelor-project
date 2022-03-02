using UnityEngine;

namespace Features.Dialogue.Logic
{
    public class DrPatternController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private static readonly int StartTalking = Animator.StringToHash("StartTalking");

        public void OnTriggerTalking()
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("DrTalkingAnimation") || animator.IsInTransition(0)) return;
            animator.SetTrigger(StartTalking);
        }
    }
}
