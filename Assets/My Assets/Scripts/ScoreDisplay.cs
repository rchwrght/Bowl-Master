using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreDisplay : MonoBehaviour {

    public Text[] frameScores;
    public Text[] bowlScores;
    
    

    public void FillRolls(List<int> rolls)
    {
        string scoreString = FormatRolls(rolls);
        for (int i = 0; i < scoreString.Length; i++) {
            bowlScores[i].text = scoreString[i].ToString();
        }
    }

    public void FillFrames(List<int> frames) {
        for (int i = 0; i < frames.Count; i++) {
            frameScores[i].text = frames[i].ToString();
        }
    }

    public static string FormatRolls(List<int> rolls) {
        string output = "";
        for (int i = 0; i < rolls.Count; i++) {
            int roll = output.Length + 1;                                  //Score Box number

            if (rolls[i] == 0) {                                           //0 is always a -
                output += "-";
            } else if (roll > 20 && rolls[i] + rolls[i - 1] == 10) {
                output += "/";
            } else if (roll % 2 == 0 && rolls[i] + rolls[i - 1] == 10) {   //SPARE Catch
                output += "/";
            } else if (roll >= 19 && rolls[i] == 10) {                     //STRIKE in last frame
                output += "X";
            } else if (rolls[i] == 10) {                                   //STRIKE in frame 1-9
                output += "X ";
            } else {                                                       //Normal bowl 1 - 9
                output += rolls[i].ToString();
            }
        }
        return output;
    }
}
