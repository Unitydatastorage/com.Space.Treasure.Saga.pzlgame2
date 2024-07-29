using System;
using UnityEngine;

namespace Source.Level.Mono
{
    public class LevelViewMono : MonoBehaviour
    {
        private Transform _transform;
        public Transform Transform => _transform;

        [SerializeField] private AudioSource _mergeSound;

        private void Awake()
        {
            _transform = transform;
        }

        public void PlayMerge()
        {
            _mergeSound.Play();
        }
    }
}