using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DemoManager : MonoBehaviour {
    public PhysicsObjectController[] PhysicsObjects;
    public LO_LoadScene sceneLoader;
    public LO_SelectStyle sceneStyle;

    public string nextScene;

    public int caseNumber = 0;
    public static DemoManager Instance;
    public float coolDownTime = 4f;
    private float currTime = 0f;

    public InstructionManager localInstructions;
    public Text caseText;

    [SerializeField] TextAsset endingText;
    [SerializeField] int maxCaseNums;

    private bool coolDown = true;
    // Use this for initialization
    void Start () {
        Instance = this;
        currTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (localInstructions.isInstructing)
        {
            return;
        }

        currTime -= Time.deltaTime;
        coolDown = (currTime <= 0);

        //RESET ALL OBJECTS
		if (Input.GetButtonDown("Fire3"))
        {
            ResetPhysicsObjects(false);
        }

        //Increment Case number for multiple runs
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Case Number" + caseNumber);
            IncrementCase(1);
            ResetPhysicsObjects(false);
        }
        //Reverse Case number
        if (Input.GetButtonDown("Fire2"))
        {
            IncrementCase(-1);
            ResetPhysicsObjects(false);
        }
    }

    private void ResetPhysicsObjects(bool overRide)
    {
        if (!coolDown)
        {
            return;
        }
        foreach (PhysicsObjectController p in PhysicsObjects)
        {
            p.Reset();
        }
        currTime = coolDownTime;
    }

    private void HidePhysicsObjects()
    {
        foreach (PhysicsObjectController p in PhysicsObjects)
        {
            p.gameObject.SetActive(false);
        }
    }

    private void IncrementCase(int add)
    {
        if (caseNumber + add < 1)
        {
            caseNumber = 1;
        }
        else if (caseNumber + add > maxCaseNums)
        {
            HidePhysicsObjects();
            caseText.text = "";
            TutorialOut();
            caseNumber = maxCaseNums;
        }
        else
        caseNumber += add;
        caseText.text = "Running Case: " + caseNumber;

        Debug.Log("Case Number" + caseNumber);
    }

    private void TutorialOut()
    {
        localInstructions.StartLastText();
        localInstructions.isEnding = true;
    }

    public void NextScene()
    {
        sceneStyle.SetStyle("TW3_Style");
        sceneLoader.ChangeToScene(nextScene);
    }
}
