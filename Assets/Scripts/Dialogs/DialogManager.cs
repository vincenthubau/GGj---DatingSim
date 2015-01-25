using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System;

/// <summary>
/// DEVELOPER: CIHAN
/// Manager class of Dialog.
/// It reads XML files (Scenarios) and create Dialog objects
/// It is called automatically when the game starts
/// </summary>
public class DialogManager
{
    //MEMBERS
    /// <summary>
    /// This dictionary keeps Dialogs respect to the scenario names
    /// KEY: Character Name
    /// VALUE: Dialog List
    /// </summary>
    private static Dictionary<string, List<Dialog>> m_dicScenarios = new Dictionary<string, List<Dialog>>();

    //METHODS

    /// <summary>
    /// Reads scenario file paths from XML file and sends them to the loadScenarios()
    /// </summary>
    /// <returns>Path of the scenarios</returns>
    private static List<string> loadFilePaths()
    {
        List<string> paths = new List<string>();

        //Read XML file and load nodes
        try
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("paths.xml");
            XmlNodeList nodes = doc.SelectNodes("path");

            //Create path List<string>
            foreach (XmlNode node in nodes)
            {
                paths.Add(node.InnerText);
            }

            return paths;
        }
        catch (System.Xml.XmlException)
        {
            Debug.LogError("PATHS.XML COULD NOT FOUND!");

            return null;
        }
    }

    /// <summary>
    /// Reads XML files and generates Dialog arrays
    /// It is called automaticly when the game starts
    /// </summary>
    /// <param name="fileName">File name/path of the scenario (XML file)</param>
    public static void loadScenarios()
    {
        //TODO READ XML FILE AND INIT DIALOG DICTIONARY

        XmlDocument doc = new XmlDocument();

        //Get Scenario file paths
        foreach (string file in Directory.GetFiles("Assets\\Scenarios", "*.xml"))
        {
            //Debug.Log("FILE: " + file);

            List<Dialog> dialogList = new List<Dialog>();

            doc.Load(file); // Load file

            //Get character/scenario name
            string scenarioName = doc.SelectSingleNode("scenario").Attributes.GetNamedItem("name").Value;

			//Debug.Log(scenarioName);

            XmlNodeList dialogNodes = doc.SelectSingleNode("scenario").SelectNodes("dialog");  //Selects all <dialog> nodes

            //Get information in <dialog> nodes
            foreach (XmlNode dialogNode in dialogNodes)
            {
                //Get dialog id
                int dialogId = Convert.ToInt32(dialogNode.Attributes.GetNamedItem("id").Value);
                string dialogCharName = dialogNode.Attributes.GetNamedItem("charName").Value;
                string dialogPlace = dialogNode.Attributes.GetNamedItem("place").Value;

                //Get text
                string dialogText = dialogNode.SelectSingleNode("text").InnerText;

                //Get options
                List<Option> optionsList = new List<Option>();
                foreach (XmlNode optionNode in dialogNode.SelectSingleNode("options").SelectNodes("option"))
                {
                    Option newOption = new Option();

                    //Get optionid
                    newOption.Id = Convert.ToInt32(optionNode.Attributes.GetNamedItem("id").Value);

                    //Get affection value
                    newOption.AffectionValue = Convert.ToSingle(optionNode.Attributes.GetNamedItem("affection").Value);

                    //Get link to the Dialog
                    newOption.Link = Convert.ToInt32(optionNode.Attributes.GetNamedItem("link").Value);

                    //Get item checker
                    newOption.ItemCheck = Convert.ToInt32(optionNode.Attributes.GetNamedItem("itemCheck").Value);

                    //Get isEnd attribute
                    newOption.IsEnd = Convert.ToBoolean(optionNode.Attributes.GetNamedItem("isEnd").Value);

                    //Get text
                    newOption.Text = optionNode.InnerText;

                    //Add Option object to the list
                    optionsList.Add(newOption);
                }

                //Create a Dialog objcect and init it
                Dialog newDialog = new Dialog(dialogId, dialogCharName, dialogPlace, dialogText, optionsList);

                //Add new Dialog into the Dialog list
                dialogList.Add(newDialog);

            }//End of dialogNode in dialogNodes

            //Add Dialog list into the dictionary
            m_dicScenarios.Add(scenarioName, dialogList);


        }//End of foreach files in the path
    }

    /// <summary>
    /// It is used for getting new dialog
    /// </summary>
    /// <param name="characterName">Name of the character</param>
    /// <param name="dialogId">ID of the next dialog which is sent by the character</param>
    /// <returns></returns>
    public static Dialog getNextDialog(string characterName, int dialogId)
    {
        return m_dicScenarios[characterName][dialogId];
    }
}
