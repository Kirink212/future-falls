﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Culture {

    // These six attributes are based on 
    // Geert Hofstede's culture model,
    // focusing on Boloni's interpretation
    // [Range(0f, 1f)]
    private float time;
    // [Range(0f, 1f)]
    private float wealth;
    // [Range(0f, 1f)]
    private float dignity;
    // [Range(0f, 1f)]
    private float politeness;
    // [Range(0f, 1f)]
    private float rationality;
    // [Range(0f, 1f)]
    private float collectivism;

    private float[] currentCulture = new float[6];

    public Culture(float[] newCulture) {
        time = newCulture[0];
        wealth = newCulture[1];
        dignity = newCulture[2];
        politeness = newCulture[3];
        rationality = newCulture[4];
        collectivism = newCulture[5];

        InitializeCulture(newCulture);
    }

    void InitializeCulture(float[] newCulture) {
        for (int i = 0; i < currentCulture.Length; i++)
        {
            currentCulture[i] = newCulture[i];
        }
    }

    public void LoadCultureDict(Dictionary<string, float> dict) {
        dict["wealth"] = wealth;
        dict["dignity"] = dignity;
        dict["politeness"] = politeness;
        dict["rationality"] = rationality;
        dict["collectivism"] = collectivism;
    }

    public float[] GetCulture() {
        return currentCulture;
    }

    public float GetTime() {
        return time;
    }

    public float GetWealth() {
        return wealth;
    }

    public float GetDignity() {
        return dignity;
    }

    public float GetPoliteness() {
        return politeness;
    }

    public float GetRationality() {
        return rationality;
    }

    public float GetCollectivism() {
        return collectivism;
    }
}
