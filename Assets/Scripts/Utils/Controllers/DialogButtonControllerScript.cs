using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Utilities controller namespace
/// </summary>
namespace Utils.Controllers
{
    /// <summary>
    /// Dialog button controller script class
    /// </summary>
    public class DialogButtonControllerScript : MonoBehaviour
    {
        /// <summary>
        /// Button
        /// </summary>
        [SerializeField]
        private Selectable button;

        /// <summary>
        /// Button text
        /// </summary>
        [SerializeField]
        private Text buttonText;

        /// <summary>
        /// Dialog UI controller
        /// </summary>
        private DialogUIControllerScript dialogUIController;

        /// <summary>
        /// Button index
        /// </summary>
        private uint buttonIndex;

        /// <summary>
        /// Fill values
        /// </summary>
        /// <param name="dialogUIController">Dialog UI controller</param>
        /// <param name="buttonIndex">Button index</param>
        /// <param name="text">Text</param>
        public void FillValues(DialogUIControllerScript dialogUIController, uint buttonIndex, string text)
        {
            this.dialogUIController = dialogUIController;
            this.buttonIndex = buttonIndex;
            if (buttonText != null)
            {
                buttonText.text = ((text == null) ? "" : text);
            }
        }

        /// <summary>
        /// Select
        /// </summary>
        public void Select()
        {
            if (button != null)
            {
                button.Select();
            }
        }

        /// <summary>
        /// Click
        /// </summary>
        public void Click()
        {
            if (dialogUIController != null)
            {
                dialogUIController.Respond((int)buttonIndex);
            }
        }
    }
}
