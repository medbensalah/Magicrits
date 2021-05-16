using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

[Serializable]
public class Diag
{
    [SerializeField]
    public string speaker;
    [SerializeField]
    public string text;
}

[Serializable]
public class DialogueManager : MonoBehaviour
{

    public Transform dialogueBox;
    public TextMeshProUGUI speaker;
    public TextMeshPro _mTextMeshPro;

    public float RevealSpeed = 0.01f;
    public int CurrentPage = 1;
    public bool IsWriting = false;

    public bool trigger = false;
    public static bool inDialogue = false;

    protected int index = 0;
    [SerializeField] protected Diag[] dialogue;

    public bool done = false;

    [SerializeField] public Dialogue[] dialogs;

    public void TriggerDialogue(int index)
    {
        dialogs[index].trigger = true;
    }

    private void Update()
    {
    }
}
