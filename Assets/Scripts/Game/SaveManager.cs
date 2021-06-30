using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public struct LoadData
    {
        public int Score { get; set; }
    };

    public static void Save(int score)
    {
        string dataPath = Application.dataPath + "/Files/Highscore.txt";
        FileStream highscore = File.OpenWrite(dataPath);
        BinaryWriter binaryWrite = new BinaryWriter(highscore);
        binaryWrite.Write(score);
        binaryWrite.Close();
        highscore.Close();
    }
    public static void Load(ref int score)
    {
        string dataPath = Application.dataPath + "/Files/Highscore.txt";
        FileStream highscore = File.OpenRead(dataPath);
        BinaryReader binaryReader = new BinaryReader(highscore);
        LoadData data = new LoadData();
        data.Score = binaryReader.ReadInt32();
        binaryReader.Close();
        score = data.Score;
    }
}
