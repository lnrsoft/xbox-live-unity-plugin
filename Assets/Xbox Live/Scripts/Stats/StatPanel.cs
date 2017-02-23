﻿// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// 
using System;

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Logic for the StatsPanel prefab that displays name and value of a <see cref="StatBase"/>.
/// </summary>
[Serializable]
public class StatPanel : MonoBehaviour
{
    public bool ShowStatLabel;

    public Text StatLabelText;

    public Text StatValueText;

    public StatBase Stat;

    private void Awake()
    {
        this.StatLabelText.text = string.Empty;
        this.StatValueText.text = string.Empty;

        // Make sure there is a StatsManager for us.
        var statsManager = StatsManagerComponent.Instance;
    }

    /// <summary>
    /// OnGUI is called for rendering and handling GUI events
    /// </summary>
    private void OnGUI()
    {
        if (this.ShowStatLabel)
        {
            Vector3 position = this.StatValueText.rectTransform.position;
            position.x = 130;
            this.StatValueText.rectTransform.position = position;
            this.StatLabelText.text = string.IsNullOrEmpty(this.Stat.DisplayName) ? this.Stat.Name : this.Stat.DisplayName;
            this.StatLabelText.gameObject.SetActive(true);
        }
        else
        {
            this.StatLabelText.gameObject.SetActive(false);
            Vector3 position = this.StatValueText.rectTransform.position;
            position.x = 10;
            this.StatValueText.rectTransform.position = position;
        }

        if (this.Stat != null)
        {
            this.StatValueText.text = this.Stat.ToString();
        }
    }
}