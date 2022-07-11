public class PlayedLevel
{
    short stars;
    Difficulty difficulty;
    Mode mode;

    public PlayedLevel(short stars, Difficulty difficulty, Mode mode)
    {
        this.stars = stars;
        this.difficulty = difficulty;
        this.mode = mode;
    }

    public short Stars => stars;
    public Difficulty Difficulty => difficulty;
    public Mode Mode => mode;
}

public enum Mode
{
    Daily,
    Countdown
}

public enum Difficulty
{
    Easy,
    Medium,
    Hard
}