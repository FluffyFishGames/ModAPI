using ModAPI;

[DoNotSerializePublic]
public class LogHolderX
{
    [SerializeThis]
    public int Logs;

    public Savegame.DataValue LogsCount;
    public LevelSerializer.StoredData StoredData;

    public void Loaded(Savegame savegame)
    {
        LogsCount = new Savegame.DataValue(savegame, Savegame.DataValue.BLUEPRINT, this.Logs, 0, Constants.MaxValues["LogHolderLogs"]);
    }

    public bool changed
    {
        get
        {
            return LogsCount.changed;
        }
    }

    public void Save()
    {
        Logs = LogsCount.IntValue;
        if (StoredData != null)
            StoredData.Data = Serialization.UnitySerializer.Serialize(this);
    }
}