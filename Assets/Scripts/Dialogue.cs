using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : DialogueManager
{

    IEnumerator DisplayDialogue()
    {
        inDialogue = true;
        yield return new WaitForSeconds(0.6f);

        // Force and update of the mesh to get valid information.
        speaker.text = dialogue[index].speaker;
        _mTextMeshPro.text = dialogue[index].text.Replace("\\n", "\n");

        _mTextMeshPro.pageToDisplay = CurrentPage;
        _mTextMeshPro.ForceMeshUpdate();

        CurrentPage = 1;

        var lastChar = _mTextMeshPro.textInfo.pageInfo[CurrentPage - 1].lastCharacterIndex; // Get # of Visible Character in text object
        var firstChar = _mTextMeshPro.textInfo.pageInfo[CurrentPage - 1].firstCharacterIndex;
        _mTextMeshPro.maxVisibleCharacters = firstChar + 1;

        while (true)
        {
            //   Debug.Log(visibleCount);
            if (_mTextMeshPro.maxVisibleCharacters <= _mTextMeshPro.textInfo.pageInfo[CurrentPage - 1].lastCharacterIndex)
            {
                IsWriting = true;
                _mTextMeshPro.maxVisibleCharacters += 1;
            }
            else
            {
                IsWriting = false;
                if (Input.GetMouseButtonDown(0))
                {
                    CurrentPage++;
                    if (CurrentPage == _mTextMeshPro.textInfo.pageCount + 1)
                    {

                        index++;
                        if (index > dialogue.Length - 1)
                        {
                            _mTextMeshPro.text = "";
                            speaker.text = "";
                            dialogueBox.GetComponent<Animator>().Play("hideDialogueBox");
                            inDialogue = false;
                            trigger = false;
                            StopCoroutine(DisplayDialogue());
                            done = true;
                            break;
                        }
                        speaker.text = dialogue[index].speaker;
                        _mTextMeshPro.text = dialogue[index].text.Replace("\\n", "\n");
                        CurrentPage = 1;
                    }
                    _mTextMeshPro.pageToDisplay = CurrentPage;
                    _mTextMeshPro.ForceMeshUpdate();
                    lastChar = _mTextMeshPro.textInfo.pageInfo[CurrentPage - 1].lastCharacterIndex; // Get # of Visible Character in text object
                    firstChar = _mTextMeshPro.textInfo.pageInfo[CurrentPage - 1].firstCharacterIndex;
                    _mTextMeshPro.maxVisibleCharacters = firstChar + 1;
                }
            }

            yield return new WaitForSeconds(0.01f);
        }
    }


    private void Update()
    {
        if (trigger && !inDialogue && !done)
        {
            trigger = false;
            dialogueBox.GetComponent<Animator>().Play("showDialogueBox");
            StartCoroutine(DisplayDialogue());
        }
    }

}
