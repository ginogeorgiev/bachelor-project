using UnityEngine;

namespace Features.CommandLevel.Logic
{
    [CreateAssetMenu(fileName = "newCommandData", menuName = "Features/CommandLevel/CommandData")]
    public class CommandData : ScriptableObject
    {
        // Are used for switch between languages
        [SerializeField] private GameObject upTextPrefab;
        [SerializeField] private GameObject downTextPrefab;
        [SerializeField] private GameObject leftTextPrefab;
        [SerializeField] private GameObject rightTextPrefab;
        
        [SerializeField] private GameObject upLeftTextPrefab;
        [SerializeField] private GameObject downLeftTextPrefab;
        [SerializeField] private GameObject upRightTextPrefab;
        [SerializeField] private GameObject downRightTextPrefab;

        public GameObject UpTextPrefab => upTextPrefab;
        public GameObject DownTextPrefab => downTextPrefab;
        public GameObject LeftTextPrefab => leftTextPrefab;
        public GameObject RightTextPrefab => rightTextPrefab;
        public GameObject UpLeftTextPrefab => upLeftTextPrefab;
        public GameObject DownLeftTextPrefab => downLeftTextPrefab;
        public GameObject UpRightTextPrefab => upRightTextPrefab;
        public GameObject DownRightTextPrefab => downRightTextPrefab;
    }
}