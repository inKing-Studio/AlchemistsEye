using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Stats
{
    List<PlayedLevel> levels;

    Stats(List<PlayedLevel> levels)
    {
        this.levels = levels;
    }

    public int GetCount(Func<PlayedLevel, bool> selector)
    {
        return levels.Count(selector);
    }

    public void Save(string path)
    {
        using (var bw = new BinaryWriter(new FileStream(path, FileMode.OpenOrCreate)))
        {
            foreach (var level in levels)
            {
                bw.Write(level.Stars);
                bw.Write((short)level.Difficulty);
                bw.Write((short)level.Mode);
            }
        }
    }

    public static Stats Load(string path)
    {
        var list = new List<PlayedLevel>();
        using (var bw = new BinaryReader(new FileStream(path, FileMode.OpenOrCreate)))
        {
            byte[] bytes = new byte[6];
            while (bw.Read(bytes, 0, 6) > 0)
            {
                var stars =  BitConverter.ToInt16(bytes, 0);
                var difficulty = (Difficulty)BitConverter.ToInt16(bytes, 2);
                var mode = (Mode)BitConverter.ToInt16(bytes, 4);

                list.Add(new PlayedLevel(stars, difficulty, mode));
            }
        }

        return new Stats(list);
    }

    public int Count => levels.Count;

    public int DailyEasyOneStar => GetCount(level => level.Mode == Mode.Daily && level.Difficulty == Difficulty.Easy && level.Stars == 1);
    public int DailyMediumOneStar => GetCount(level => level.Mode == Mode.Daily && level.Difficulty == Difficulty.Medium && level.Stars == 1);
    public int DailyHardOneStar => GetCount(level => level.Mode == Mode.Daily && level.Difficulty == Difficulty.Hard && level.Stars == 1);

    public int DailyEasyTwoStar => GetCount(level => level.Mode == Mode.Daily && level.Difficulty == Difficulty.Easy && level.Stars == 2);
    public int DailyMediumTwoStar => GetCount(level => level.Mode == Mode.Daily && level.Difficulty == Difficulty.Medium && level.Stars == 2);
    public int DailyHardTwoStar => GetCount(level => level.Mode == Mode.Daily && level.Difficulty == Difficulty.Hard && level.Stars == 2);

    public int DailyEasyThreeStar => GetCount(level => level.Mode == Mode.Daily && level.Difficulty == Difficulty.Easy && level.Stars == 3);
    public int DailyMediumThreeStar => GetCount(level => level.Mode == Mode.Daily && level.Difficulty == Difficulty.Medium && level.Stars == 3);
    public int DailyHardThreeStar => GetCount(level => level.Mode == Mode.Daily && level.Difficulty == Difficulty.Hard && level.Stars == 3);

    public int CountdownEasyOneStar => GetCount(level => level.Mode == Mode.Countdown && level.Difficulty == Difficulty.Easy && level.Stars == 1);
    public int CountdownMediumOneStar => GetCount(level => level.Mode == Mode.Countdown && level.Difficulty == Difficulty.Medium && level.Stars == 1);
    public int CountdownHardOneStar => GetCount(level => level.Mode == Mode.Countdown && level.Difficulty == Difficulty.Hard && level.Stars == 1);

    public int CountdownEasyTwoStar => GetCount(level => level.Mode == Mode.Countdown && level.Difficulty == Difficulty.Easy && level.Stars == 2);
    public int CountdownMediumTwoStar => GetCount(level => level.Mode == Mode.Countdown && level.Difficulty == Difficulty.Medium && level.Stars == 2);
    public int CountdownHardTwoStar => GetCount(level => level.Mode == Mode.Countdown && level.Difficulty == Difficulty.Hard && level.Stars == 2);

    public int CountdownEasyThreeStar => GetCount(level => level.Mode == Mode.Countdown && level.Difficulty == Difficulty.Easy && level.Stars == 3);
    public int CountdownMediumThreeStar => GetCount(level => level.Mode == Mode.Countdown && level.Difficulty == Difficulty.Medium && level.Stars == 3);
    public int CountdownHardThreeStar => GetCount(level => level.Mode == Mode.Countdown && level.Difficulty == Difficulty.Hard && level.Stars == 3);
}