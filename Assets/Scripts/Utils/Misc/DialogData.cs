/// <summary>
/// Utilities namespace
/// </summary>
namespace Utils
{
    /// <summary>
    /// Dialog data structure
    /// </summary>
    public struct DialogData
    {
        /// <summary>
        /// Title
        /// </summary>
        private string title;

        /// <summary>
        /// Message
        /// </summary>
        private string message;

        /// <summary>
        /// Dialog type
        /// </summary>
        private EDialogType dialogType;

        /// <summary>
        /// Dialog buttons
        /// </summary>
        private EDialogButtons dialogButtons;

        /// <summary>
        /// Buttons
        /// </summary>
        private string[] buttons;

        /// <summary>
        /// On dialog response
        /// </summary>
        private DialogResponseDelegate onDialogResponse;

        /// <summary>
        /// Title
        /// </summary>
        public string Title
        {
            get
            {
                if (title == null)
                {
                    title = "";
                }
                return title;
            }
        }

        /// <summary>
        /// Message
        /// </summary>
        public string Message
        {
            get
            {
                if (message == null)
                {
                    message = "";
                }
                return message;
            }
        }

        /// <summary>
        /// Dialog type
        /// </summary>
        public EDialogType DialogType
        {
            get
            {
                return dialogType;
            }
        }

        /// <summary>
        /// Dialog buttons
        /// </summary>
        public EDialogButtons DialogButtons
        {
            get
            {
                return dialogButtons;
            }
        }

        /// <summary>
        /// Buttons
        /// </summary>
        public string[] Buttons
        {
            get
            {
                if (buttons == null)
                {
                    switch (dialogButtons)
                    {
                        case EDialogButtons.OKCancel:
                            buttons = new string[] { Dialog.OKString, Dialog.CancelString };
                            break;
                        case EDialogButtons.YesNo:
                            buttons = new string[] { Dialog.YesString, Dialog.NoString };
                            break;
                        case EDialogButtons.YesNoCancel:
                            buttons = new string[] { Dialog.YesString, Dialog.NoString, Dialog.CancelString };
                            break;
                        default:
                            buttons = new string[] { Dialog.OKString };
                            break;
                    }
                }
                return buttons;
            }
        }

        /// <summary>
        /// On dialog response
        /// </summary>
        public DialogResponseDelegate OnDialogResponse
        {
            get
            {
                return onDialogResponse;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="title">Title</param>
        /// <param name="message">Message</param>
        /// <param name="dialogType">Dialog tyoe</param>
        /// <param name="dialogButtons">Dialog buttons</param>
        /// <param name="buttons">Buttons</param>
        /// <param name="onDialogResponse">On dialog response</param>
        public DialogData(string title, string message, EDialogType dialogType, EDialogButtons dialogButtons, string[] buttons, DialogResponseDelegate onDialogResponse)
        {
            this.title = title;
            this.message = message;
            this.dialogType = dialogType;
            this.dialogButtons = dialogButtons;
            this.buttons = buttons;
            this.onDialogResponse = onDialogResponse;
            if (dialogButtons != EDialogButtons.Custom)
            {
                this.buttons = null;
            }
        }
    }
}
