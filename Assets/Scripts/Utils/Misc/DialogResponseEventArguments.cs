/// <summary>
/// Utilities namespace
/// </summary>
namespace Utils
{
    /// <summary>
    /// Dialog response event arguments class
    /// </summary>
    public class DialogResponseEventArguments
    {
        /// <summary>
        /// Dialog response
        /// </summary>
        private EDialogResponse dialogResponse;

        /// <summary>
        /// Selected button index
        /// </summary>
        private int selectedButtonIndex;

        /// <summary>
        /// Dialog response
        /// </summary>
        public EDialogResponse DialogResponse
        {
            get
            {
                return dialogResponse;
            }
        }

        /// <summary>
        /// Selected button index
        /// </summary>
        public int SelectedButtonIndex
        {
            get
            {
                return selectedButtonIndex;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dialogResponse">Dialog response</param>
        /// <param name="selectedButtonIndex">Selected button index</param>
        public DialogResponseEventArguments(EDialogResponse dialogResponse, int selectedButtonIndex)
        {
            this.dialogResponse = dialogResponse;
            this.selectedButtonIndex = selectedButtonIndex;
        }
    }
}
