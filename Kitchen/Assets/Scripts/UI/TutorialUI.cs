using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keyMoveUpText;
    [SerializeField] private TextMeshProUGUI keyMoveDownText;
    [SerializeField] private TextMeshProUGUI keyMoveLeftText;
    [SerializeField] private TextMeshProUGUI keyMoveRightText;
    [SerializeField] private TextMeshProUGUI keyInteractText;
    [SerializeField] private TextMeshProUGUI keyInteractAltText;
    [SerializeField] private TextMeshProUGUI keyPauseText;
    [SerializeField] private TextMeshProUGUI KeyGamepadInteractText;
    [SerializeField] private TextMeshProUGUI KeyGamepadInteractAltText;
    [SerializeField] private TextMeshProUGUI KeyGamepadPauseText;

    private void Start()
    {
        GameInput.Instance.OnBindingRebind += GameInput_OnBindingRebind;
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;

        UpdateVisual();
        Show();
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsCountdownToStart())
        {
            Hide();
        }
    }

    private void GameInput_OnBindingRebind(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        keyMoveUpText.text = GameInput.Instance.GetBinding(GameInput.Binding.Move_Up);
        keyMoveDownText.text = GameInput.Instance.GetBinding(GameInput.Binding.Move_Down);
        keyMoveLeftText.text = GameInput.Instance.GetBinding(GameInput.Binding.Move_Left);
        keyMoveRightText.text = GameInput.Instance.GetBinding(GameInput.Binding.Move_Right);
        keyInteractText.text = GameInput.Instance.GetBinding(GameInput.Binding.Interact);
        keyInteractAltText.text = GameInput.Instance.GetBinding(GameInput.Binding.InteractAlternative);
        keyPauseText.text = GameInput.Instance.GetBinding(GameInput.Binding.Pause);
        KeyGamepadInteractText.text = GameInput.Instance.GetBinding(GameInput.Binding.Gamepad_Interact);
        KeyGamepadInteractAltText.text = GameInput.Instance.GetBinding(GameInput.Binding.Gamepad_InteractAlternative);
        KeyGamepadPauseText.text = GameInput.Instance.GetBinding(GameInput.Binding.Gamepad_Pause);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
