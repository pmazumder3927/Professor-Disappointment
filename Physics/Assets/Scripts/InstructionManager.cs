using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InstructionManager : MonoBehaviour {
    public TextAsset[] Lines;
    public GameObject Mascot;
    public Text instructionText;
    public bool isInstructing = true;
    public bool isEnding = false;

    TextImporter textImport;
    // Use this for initialization
    [SerializeField]
    bool isPlaying = false;

    int textCounter = 0;

	void Start () {
        textImport = new TextImporter(Lines[textCounter]);
	}
	
	// Update is called once per frame
	void Update () {
        if (isPlaying)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (textImport.isDone())
                {
                    ToggleInstructions(false);
                    if (isEnding)
                    {
                        DemoManager.Instance.NextScene();
                    }

                    GetComponent<AudioSource>().Stop();
                }
                else GetComponent<AudioSource>().Play();
                Debug.Log("Line Playing");
                StartCoroutine(AnimateText(textImport.GetNextLine()));
            }
        }
	}

    IEnumerator AnimateText(string word)
    {
        isPlaying = false;
        for (int i = 0; i < (word.Length + 1); i++)
        {
            instructionText.text = word.Substring(0, i);
            yield return new WaitForSeconds(.03f);
        }
        isPlaying = true;
    }

    public void HideMascot()
    {
        Mascot.SetActive(false);
    }

    public void ShowMascot()
    {
        Mascot.SetActive(true);
    }

    public void ToggleInstructions(bool show)
    {
        if (!show) HideMascot();
        else ShowMascot();
        isInstructing = show;
    }

    private void ChangeLines(TextAsset t)
    {
        textImport = new TextImporter(t);
        StartCoroutine(AnimateText(textImport.GetNextLine()));
        ToggleInstructions(true);
    }

    public void StartNextText(int number)
    {
        textCounter = number;
        if (textCounter >= Lines.Length) isEnding = true;
        ChangeLines(Lines[textCounter]);
    }

    public void StartLastText()
    {
        isEnding = true;
        textCounter = Lines.Length-1;
        ChangeLines(Lines[textCounter]);
    }
}
