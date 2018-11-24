using Utils.Managers;

/// <summary>
/// Utilities namespace
/// </summary>
namespace Utils
{
    /// <summary>
    /// Dialog class
    /// </summary>
    public static class Dialog
    {
        /// <summary>
        /// OK string
        /// </summary>
        public static string OKString
        {
            get
            {
                return ((DialogManagerScript.Instance == null) ? "OK" : ((DialogManagerScript.Instance.OKTranslation == null) ? "OK" : DialogManagerScript.Instance.OKTranslation.ToString()));
            }
        }

        /// <summary>
        /// Cancel string
        /// </summary>
        public static string CancelString
        {
            get
            {
                return ((DialogManagerScript.Instance == null) ? "Cancel" : ((DialogManagerScript.Instance.CancelTranslation == null) ? "Cancel" : DialogManagerScript.Instance.CancelTranslation.ToString()));
            }
        }

        /// <summary>
        /// Yes string
        /// </summary>
        public static string YesString
        {
            get
            {
                return ((DialogManagerScript.Instance == null) ? "Yes" : ((DialogManagerScript.Instance.YesTranslation == null) ? "Yes" : DialogManagerScript.Instance.YesTranslation.ToString()));
            }
        }

        /// <summary>
        /// No string
        /// </summary>
        public static string NoString
        {
            get
            {
                return ((DialogManagerScript.Instance == null) ? "No" : ((DialogManagerScript.Instance.NoTranslation == null) ? "No" : DialogManagerScript.Instance.NoTranslation.ToString()));
            }
        }

        /// <summary>
        /// Show dialog
        /// </summary>
        /// <param name="title">Title</param>
        /// <param name="message">Message</param>
        /// <param name="dialogType">Dialog type</param>
        /// <param name="dialogButtons">Dialog buttons</param>
        /// <param name="onDialogResponse">On dialog response</param>
        public static void Show(string title, string message, EDialogType dialogType, EDialogButtons dialogButtons, DialogResponseDelegate onDialogResponse)
        {
            DialogManagerScript dialog_manager = DialogManagerScript.Instance;
            if (dialog_manager != null)
            {
                dialog_manager.Show(new DialogData(title, message, dialogType, dialogButtons, null, onDialogResponse));
            }
        }

        /// <summary>
        /// Show dialog
        /// </summary>
        /// <param name="title">Title</param>
        /// <param name="message">Message</param>
        /// <param name="dialogType">Dialog type</param>
        /// <param name="dialogButtons">Dialog buttons</param>
        public static void Show(string title, string message, EDialogType dialogType, EDialogButtons dialogButtons)
        {
            Show(title, message, dialogType, dialogButtons, null);
        }

        /// <summary>
        /// Show dialog
        /// </summary>
        /// <param name="title">Title</param>
        /// <param name="message">Message</param>
        /// <param name="dialogType">Dialog type</param>
        /// <param name="buttons">Buttons</param>
        /// <param name="onDialogResponse">On dialog response</param>
        public static void Show(string title, string message, EDialogType dialogType, string[] buttons, DialogResponseDelegate onDialogResponse)
        {
            DialogManagerScript dialog_manager = DialogManagerScript.Instance;
            if (dialog_manager != null)
            {
                dialog_manager.Show(new DialogData(title, message, dialogType, EDialogButtons.Custom, buttons, onDialogResponse));
            }
        }

        /// <summary>
        /// Show dialog
        /// </summary>
        /// <param name="title">Title</param>
        /// <param name="message">Message</param>
        /// <param name="dialogType">Dialog type</param>
        /// <param name="buttons">Buttons</param>
        public static void Show(string title, string message, EDialogType dialogType, string[] buttons)
        {
            Show(title, message, dialogType, buttons, null);
        }
    }
}
