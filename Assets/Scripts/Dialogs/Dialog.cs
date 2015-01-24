using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// DEVELOPER: CIHAN
/// Dialog class for handling dialog operations in the game
/// </summary>

public struct Option
{
    public bool IsEnd { get; set; }

    public int Id { get; set; }
    public int Link { get; set; }
    public int ItemCheck { get; set; }

    public float AffectionValue { get; set; }

    public string Text { get; set; }
    
}

public class Dialog
{
    //MEMBERS
    private Dictionary<int, Option> m_dicOptions = new Dictionary<int,Option>();

    public int Id { get; private set; }
    public string Place { get; set; }
    public string CharacterName { get; set; }
    public string Text { get; private set; }
    

    //CONSTRACTOR
    public Dialog(int id, string characterName, string place, string text, List<Option>options)
    {
        this.Id = id;
        this.CharacterName = characterName;
        this.Place = place;
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

    /// <summary>
    /// Uses for getting all Option objcts as a list
    /// </summary>
    /// <returns>List of Option objects</returns>
    public List<Option> getOptions()
    {
        return new List<Option>(m_dicOptions.Values);
    }
}
