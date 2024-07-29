using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Source.UI.Mono
{
    public class MenuManager : MonoBehaviour
    {
        [FormerlySerializedAs("_policeConfirmUI")] [SerializeField] private PoliceConfirmView policeConfirmView;
        [SerializeField] private MainMenuView _mainMenu;
        [SerializeField] private UIView[] _UIViews;

        private void Start()
        {
            foreach (var variUIView in _UIViews)
            {
                variUIView.Hide();
            }
            var policy = PlayerPrefs.GetInt("Policy", 0);
            if (policy == 0)
            {
                policeConfirmView.Show();
            }
            else
            {
                _mainMenu.Show();
            }
        }
    }
}