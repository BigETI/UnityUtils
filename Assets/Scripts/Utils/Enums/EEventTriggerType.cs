using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum EEventTriggerType
{
    /// <summary>
    /// <seealso cref="EventTriggerType.PointerEnter"/>
    /// </summary>
    PointerEnter = 0,

    /// <summary>
    /// <seealso cref="EventTriggerType.PointerExit"/>
    /// </summary>
    PointerExit = 1,

    /// <summary>
    /// <seealso cref="EventTriggerType.PointerDown"/>
    /// </summary>
    PointerDown = 2,

    /// <summary>
    /// <seealso cref="EventTriggerType.PointerUp"/>
    /// </summary>
    PointerUp = 3,

    /// <summary>
    /// <seealso cref="EventTriggerType.PointerClick"/>
    /// </summary>
    PointerClick = 4,

    /// <summary>
    /// <seealso cref="EventTriggerType.Drag"/>
    /// </summary>
    Drag = 5,

    /// <summary>
    /// <seealso cref="EventTriggerType.Drop"/>
    /// </summary>
    Drop = 6,

    /// <summary>
    /// <seealso cref="EventTriggerType.Scroll"/>
    /// </summary>
    Scroll = 7,

    /// <summary>
    /// <seealso cref="EventTriggerType.UpdateSelected"/>
    /// </summary>
    UpdateSelected = 8,

    /// <summary>
    /// <seealso cref="EventTriggerType.Select"/>
    /// </summary>
    Select = 9,

    /// <summary>
    /// <seealso cref="EventTriggerType.Deselect"/>
    /// </summary>
    Deselect = 10,

    /// <summary>
    /// <seealso cref="EventTriggerType.Move"/>
    /// </summary>
    Move = 11,

    /// <summary>
    /// <seealso cref="EventTriggerType.InitializePotentialDrag"/>
    /// </summary>
    InitializePotentialDrag = 12,

    /// <summary>
    /// <seealso cref="EventTriggerType.BeginDrag"/>
    /// </summary>
    BeginDrag = 13,

    /// <summary>
    /// <seealso cref="EventTriggerType.EndDrag"/>
    /// </summary>
    EndDrag = 14,

    /// <summary>
    /// <seealso cref="EventTriggerType.Submit"/>
    /// </summary>
    Submit = 15,

    /// <summary>
    /// <seealso cref="EventTriggerType.Cancel"/>
    /// </summary>
    Cancel = 16,

    /// <summary>
    /// Button click
    /// </summary>
    Click,

    /// <summary>
    /// Value changed
    /// </summary>
    ValueChanged,

    /// <summary>
    /// Input field end edit
    /// </summary>
    EndEdit
}
