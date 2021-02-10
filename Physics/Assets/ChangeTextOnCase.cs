using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InstructionManager))]
public class ChangeTextOnCase : MonoBehaviour {
    public List<int> ChangeNumbers;
    InstructionManager im;
	// Use this for initialization
	void Start () {
        im = GetComponent<InstructionManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (im.isInstructing)
        {
            return;
        }
        foreach (int i in ChangeNumbers)
        {
            if (DemoManager.Instance.caseNumber == i)
            {
                im.StartNextText(i);
                ChangeNumbers.Remove(i);
            }
        }
	}
}
