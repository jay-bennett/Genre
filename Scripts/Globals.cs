using UnityEngine;
using System.Collections;

public enum Difficulty {
    Easy,
    Medium,
    Hard,
    VeryHard
}

public class Globals : MonoBehaviour {

    public static Difficulty difficulty = Difficulty.Medium;
    public static bool invaderCredits = false;
    public static int currentLevel = 0;

}
