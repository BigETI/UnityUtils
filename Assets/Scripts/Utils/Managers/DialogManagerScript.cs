using System.Collections.Generic;
using UnityEngine;
using Utils.Controllers;
using Utils.Objects;

/// <summary>
/// Utilities managers namespace
/// </summary>
namespace Utils.Managers
{
    /// <summary>
    /// Dialog manager script class
    /// </summary>
    [RequireComponent(typeof(RectTransform))]
    public class DialogManagerScript : MonoBehaviour
    {
        /// <summary>
        /// OK translation
        /// </summary>
        [SerializeField]
        private TranslationObjectScript okTranslation;

        /// <summary>
        /// Cancel translation
        /// </summary>
        [SerializeField]
        private TranslationObjectScript cancelTranslation;

        /// <summary>
        /// Yes translation
        /// </summary>
        [SerializeField]
        private TranslationObjectScript yesTranslation;

        /// <summary>
        /// No translation
        /// </summary>
        [SerializeField]
        private TranslationObjectScript noTranslation;

        /// <summary>
        /// Dialog panel asset
        /// </summary>
        [SerializeField]
        private GameObject dialogPanelAsset;

        /// <summary>
        /// Rectangle transform
        /// </summary>
        private RectTransform rectTransform;

        /// <summary>
        /// Dialog stack
        /// </summary>
        private static Stack<DialogData> dialogStack = new Stack<DialogData>();

        /// <summary>
        /// Instance
        /// </summary>
        private static DialogManagerScript instance;

        /// <summary>
        /// OK translation
        /// </summary>
        public TranslationObjectScript OKTranslation
        {
            get
            {
                return okTranslation;
            }
        }

        /// <summary>
        /// Cancel translation
        /// </summary>
        public TranslationObjectScript CancelTranslation
        {
            get
            {
                return cancelTranslation;
            }
        }

        /// <summary>
        /// Yes translation
        /// </summary>
        public TranslationObjectScript YesTranslation
        {
            get
            {
                return yesTranslation;
            }
        }

        /// <summary>
        /// No translation
        /// </summary>
        public TranslationObjectScript NoTranslation
        {
            get
            {
                return noTranslation;
            }
        }

        /// <summary>
        /// Instance
        /// </summary>
        public static DialogManagerScript Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Awake
        /// </summary>
        private void Awake()
        {
            if (instance == null)
            {
                DontDestroyOnLoad(gameObject);
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// Start
        /// </summary>
        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        /// <summary>
        /// Current dialog panel object
        /// </summary>
        private GameObject currentDialogPanelObject;

        /// <summary>
        /// Update visuals
        /// </summary>
        public void UpdateVisuals()
        {
            if (currentDialogPanelObject != null)
            {
                Destroy(currentDialogPanelObject);
                currentDialogPanelObject = null;
            }
            if ((dialogPanelAsset != null) && (dialogStack.Count > 0))
            {
                DialogData dialog_data = dialogStack.Peek();
                GameObject go = Instantiate(dialogPanelAsset);
                if (go != null)
                {
                    RectTransform rect_transform = go.GetComponent<RectTransform>();
                    DialogUIControllerScript dialog_ui_controller = go.GetComponent<DialogUIControllerScript>();
                    if ((rect_transform != null) && (dialog_ui_controller != null))
                    {
                        dialog_ui_controller.FillValues(dialog_data);
                        rect_transform.SetParent(rectTransform, false);
                        currentDialogPanelObject = go;
                    }
                    else
                    {
                        Destroy(go);
                    }
                }
            }
        }

        /// <summary>
        /// Show dialog
        /// </summary>
        /// <param name="dialogData">Dialog data</param>
        public void Show(DialogData dialogData)
        {
            dialogStack.Push(dialogData);
            UpdateVisuals();
        }

        /// <summary>
        /// Pop last dialog
        /// </summary>
        public void PopLastDialog()
        {
            if (dialogStack.Count > 0)
            {
                dialogStack.Pop();
            }
            UpdateVisuals();
        }
    }
}
