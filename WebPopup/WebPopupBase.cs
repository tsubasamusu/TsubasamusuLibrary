#pragma warning disable IDE0005
using System.Runtime.InteropServices;
#pragma warning restore IDE0005
using UnityEngine;
using UnityEngine.Scripting;

namespace TSUBASAMUSU.WebPopup
{
    public class WebPopupBase : MonoBehaviour
    {
        [SerializeField]
#pragma warning disable CS8618
#pragma warning disable CS0169
#pragma warning disable IDE0044
#pragma warning disable IDE0051
        private string popupDescription;
#pragma warning restore IDE0051
#pragma warning restore IDE0044
#pragma warning restore CS0169
#pragma warning restore CS8618

        private readonly string salt = "(Selected for Input)";

#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void MakePopupAppear(string objectID, string popupDescription);
#else
#pragma warning disable IDE0051
        private static void MakePopupAppear(string objectID, string popupDescription) { }
#pragma warning restore IDE0051
#endif
        /// <summary>
        /// Popups appear.
        /// </summary>
        [Preserve]
        protected void ShowPopup()
        {
#if UNITY_WEBGL && !UNITY_EDITOR
        SaltName();
        MakePopupAppear(gameObject.name, popupDescription);
#endif
        }

        [Preserve]
        public void ReceiveEnterdText(string text)
        {
            UnSaltName();

            OnFinishedTypingPrompt(text);
        }

        /// <summary>
        /// Called when popup input is completed.
        /// </summary>
        /// <param name="enteredText">Entered Text</param>
        protected virtual void OnFinishedTypingPrompt(string enteredText) { }

        [Preserve]
#pragma warning disable IDE0051
        private void SaltName()
#pragma warning restore IDE0051
        {
            if (!gameObject.name.Contains(salt)) gameObject.name += salt;
        }

        private void UnSaltName()
        {
            if (gameObject.name.Contains(salt)) gameObject.name = gameObject.name.Replace(salt, string.Empty);
        }
    }
}