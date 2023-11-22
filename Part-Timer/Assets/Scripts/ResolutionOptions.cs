using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionOptions : MonoBehaviour {
    [SerializeField] Dropdown resolutionDropdown;

    Resolution[] resolutions;

    void Start() {
        resolutions = Screen.resolutions;
    }
}
