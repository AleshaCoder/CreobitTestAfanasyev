using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _movesCountText;
    [SerializeField] private TMP_Text _energyCountText;
    [SerializeField] private Player _player;

    private const string MovesText = "Moves ";
    private const string EnergyText = "Energy ";

    private void RefreshMovesCountText() =>
        _movesCountText.text = MovesText + _player.Moves;

    private void RefreshEnergyCountText() =>
        _energyCountText.text = EnergyText + _player.Energy;

    private void OnEnable()
    {
        RefreshMovesCountText();
        _player.OnMovesChanged += RefreshMovesCountText;
        _player.OnEnergyChanged += RefreshEnergyCountText;
    }

    private void OnDisable()
    {
        _player.OnMovesChanged -= RefreshMovesCountText;
        _player.OnEnergyChanged -= RefreshEnergyCountText;
    }
}
