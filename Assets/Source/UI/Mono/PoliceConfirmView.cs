using UnityEngine;

namespace Source.UI.Mono
{
    public class PoliceConfirmView : UIView
    {

        public void PolicyConfirm()
        {
            PlayerPrefs.SetInt("Policy", 1);
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}