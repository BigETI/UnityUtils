using UnityEngine;
using UnityEngine.UI;
using Utils.Managers;

/// <summary>
/// Utilities controllers namespace
/// </summary>
namespace Utils.Controllers
{
    /// <summary>
    /// Dialog UI controller script
    /// </summary>
    [RequireComponent(typeof(RectTransform))]
    public class DialogUIControllerScript : MonoBehaviour
    {
        /// <summary>
        /// Information sprite
        /// </summary>
        [SerializeField]
        private Sprite infoSprite;

        /// <summary>
        /// Warning sprite
        /// </summary>
        [SerializeField]
        private Sprite warningSprite;

        /// <summary>
        /// Error sprite
        /// </summary>
        [SerializeField]
        private Sprite errorSprite;

        /// <summary>
        /// Info color
        /// </summary>
        [SerializeField]
        private Color infoColor;

        /// <summary>
        /// Warning color
        /// </summary>
        [SerializeField]
        private Color warningColor;

        /// <summary>
        /// Error color
        /// </summary>
        [SerializeField]
        private Color errorColor;

        /// <summary>
        /// Button asset
        /// </summary>
        [SerializeField]
        private GameObject buttonAsset;

        /// <summary>
        /// Icon image
        /// </summary>
        [SerializeField]
        private Image iconImage;

        /// <summary>
        /// Title text
        /// </summary>
        [SerializeField]
        private Text titleText;

        /// <summary>
        /// Message text
        /// </summary>
        [SerializeField]
        private Text messageText;

        /// <summary>
        /// Buttons panel rectangle transform
        /// </summary>
        [SerializeField]
        private RectTransform buttonsPanelRectTransform;

        /// <summary>
        /// Dialog data
        /// </summary>
        private DialogData dialogData;

        /// <summary>
        /// Fill values
        /// </summary>
        /// <param name="dialogData">Dialog data</param>
        public void FillValues(DialogData dialogData)
        {
            Sprite sprite = infoSprite;
            Color color = infoColor;
            this.dialogData = dialogData;
            switch (dialogData.DialogType)
            {
                case EDialogType.Warning:
                    sprite = warningSprite;
                    color = warningColor;
                    break;
                case EDialogType.Error:
                    sprite = errorSprite;
                    color = errorColor;
                    break;
            }
            if (iconImage != null)
            {
                iconImage.sprite = sprite;
                iconImage.color = color;
            }
            if (titleText != null)
            {
                titleText.text = dialogData.Title;
                titleText.color = color;
            }
            if (messageText != null)
            {
                messageText.text = dialogData.Message;
            }
            if (messageText != null)
            {
                messageText.text = dialogData.Message;
            }
            if ((buttonAsset != null) && (buttonsPanelRectTransform != null))
            {
                for (int i = 0; i < dialogData.Buttons.Length; i++)
                {
                    string button = dialogData.Buttons[i];
                    GameObject go = Instantiate(buttonAsset);
                    if (go != null)
                    {
                        RectTransform rect_transform = go.GetComponent<RectTransform>();
                        DialogButtonControllerScript dialog_button = go.GetComponent<DialogButtonControllerScript>();
                        if ((rect_transform != null) && (dialog_button != null))
                        {
                            dialog_button.FillValues(this, (uint)i, button);
                            rect_transform.SetParent(buttonsPanelRectTransform, false);
                            if (i == 0)
                            {
                                dialog_button.Select();
                            }
                        }
                        else
                        {
                            Destroy(go);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Respond
        /// </summary>
        /// <param name="selectedButtonIndex">Selected button index</param>
        public void Respond(int selectedButtonIndex)
        {

            DialogManagerScript dialog_manager = DialogManagerScript.Instance;
            if (dialog_manager != null)
            {
                dialog_manager.PopLastDialog();
            }
            else
            {
                Destroy(gameObject);
            }
            if (dialogData.OnDialogResponse != null)
            {
                EDialogResponse dialog_response = EDialogResponse.None;
                switch (dialogData.DialogButtons)
                {
                    case EDialogButtons.OK:
                        if (selectedButtonIndex == 0)
                        {
                            dialog_response = EDialogResponse.OK;
                        }
                        break;
                    case EDialogButtons.OKCancel:
                        switch (selectedButtonIndex)
                        {
                            case 0:
                                dialog_response = EDialogResponse.OK;
                                break;
                            case 1:
                                dialog_response = EDialogResponse.Cancel;
                                break;
                        }
                        break;
                    case EDialogButtons.YesNo:
                        switch (selectedButtonIndex)
                        {
                            case 0:
                                dialog_response = EDialogResponse.Yes;
                                break;
                            case 1:
                                dialog_response = EDialogResponse.No;
                                break;
                        }
                        break;
                    case EDialogButtons.YesNoCancel:
                        switch (selectedButtonIndex)
                        {
                            case 0:
                                dialog_response = EDialogResponse.Yes;
                                break;
                            case 1:
                                dialog_response = EDialogResponse.No;
                                break;
                            case 2:
                                dialog_response = EDialogResponse.Cancel;
                                break;
                        }
                        break;
                }
                dialogData.OnDialogResponse(new DialogResponseEventArguments(dialog_response, selectedButtonIndex));
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Respond(-1);
            }
        }
    }
}
