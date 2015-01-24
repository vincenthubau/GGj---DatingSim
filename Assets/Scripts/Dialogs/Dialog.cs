using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// DEVELOPER: CIHAN
/// Dialog class for handling dialog operations in the game
/// </summary>

public struct Option
{
    public string Text { get; set; }
    public int Link { get; set; }
    public int Id { get; set; }
}

public class Dialog
{
    //MEMBERS
    private Dictionary<int, Option> m_dicOptions = new Dictionary<int,Option>();

    public string Text { get; private set; }
    public int Id { get; private set; }

    //CONSTRACTOR
    public Dialog(int id, string text, List<Option>options)
    {
        this.Id = id;
        this.Text = text;

        //Assign Options
        foreach(Option ops in options)
        {
            m_dicOptions.Add(ops.Id, ops);
        }
    }

    /// <summary>
    /// Uses for getting next dialog's ID
    /// It takes id of the selected option and returns ID of next Dialog
    /// </summary>
    /// <param name="optionId">ID of selected Option</param>
    /// <returns>ID of next Dialog (Link)</returns>
    public int getNextDialogId(int optionId)
    {
        return m_dicOptions[optionId].Link;
    }
}
