using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnCase : MonoBehaviour {
    [SerializeField] GameObject toSet;
    [SerializeField] int[] caseTrigger;
    [SerializeField] int[] caseTerminate;
	// Update is called once per frame
	void LateUpdate() {
        for (int i =0; i < caseTrigger.Length; i++)
        {
            if (caseTrigger[i] == DemoManager.Instance.caseNumber)
            {
                toSet.SetActive(true);
            }
            if (caseTerminate[i] == DemoManager.Instance.caseNumber)
            {
                toSet.SetActive(false);
            }
        }
    }
}
