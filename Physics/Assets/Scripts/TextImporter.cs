using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextImporter {
    TextAsset text;
    string[] lines;

    int lineNo = -1;

    public TextImporter(TextAsset t)
    {
        text = t;
        lines = t.text.Split('\n') ;
    }

    public string GetNextLine()
    {
        AddLine(1);
        return lines[lineNo];
    }

    public string GetPreviousLine(bool increment)
    {
        if (increment) AddLine(-1);
        return lines[increment ? lineNo : lineNo -1];
    }

    private void AddLine(int amt)
    {
        if (amt + lineNo > lines.Length-1)
        {
            lineNo = lines.Length-1;
        }
        else lineNo += amt;
    }

    public bool isDone()
    {
        return lineNo == lines.Length-1;
    }
}
