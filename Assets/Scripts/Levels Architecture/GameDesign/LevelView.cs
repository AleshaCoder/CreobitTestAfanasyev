using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelView : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelViewText;
    [SerializeField] private Button _levelViewButton;

    [HideInInspector] public UnityEvent OnLevelViewClick;

    public void SetText(string name) =>
        _levelViewText.text = name;

    private void OnEnable() =>
        _levelViewButton.onClick.AddListener(OnLevelViewClick.Invoke);

    private void OnDisable() =>
        _levelViewButton.onClick.RemoveListener(OnLevelViewClick.Invoke);

    private void OnApplicationQuit() =>
        _levelViewButton.onClick.RemoveAllListeners();
}
