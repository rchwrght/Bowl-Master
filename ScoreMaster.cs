using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster {

    //Returns a Cumulative list of scores much like an actual Score Card would do
    public static List<int> ScoreCumulative(List<int> rolls) {
        List<int> cumulativeScores = new List<int>();
        int runningTotal = 0;
        foreach (int frameScore in ScoreFrames(rolls)) {
            runningTotal += frameScore;
            cumulativeScores.Add(runningTotal);
        }
        

        return cumulativeScores;
    }
    
    //This method is just to call individual frame scores not a cumulative score card or score for each individual roll
    public static List<int> ScoreFrames(List<int> rolls) {
        List<int> frameList = new List<int>();
        int frameScore = 0;
        //
        for(int i = 1; i < rolls.Count; i += 2 ) {
			if (rolls [i] < 10) {
				frameScore = rolls [i] + rolls [i - 1];
				frameList.Add (frameScore);
			}
        }
        //
        return frameList;
    }

}
