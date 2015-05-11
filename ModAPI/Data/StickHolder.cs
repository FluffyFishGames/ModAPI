using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModAPI;

[DoNotSerializePublic]
public class StickHolderX
{
    [SerializeThis]
    public int Sticks;
    
    public Savegame.DataValue SticksCount;
    public LevelSerializer.StoredData StoredData;

    public void Loaded(Savegame savegame)
    {
        SticksCount = new Savegame.DataValue(savegame, Savegame.DataValue.BLUEPRINT, this.Sticks, 0, Constants.MaxValues["StickHolderSticks"]);
    }

    public bool changed
    {
        get
        {
            return SticksCount.changed;
        }
    }

    public void Save()
    {
        Sticks = SticksCount.IntValue;
        if (StoredData != null)
            StoredData.Data = Serialization.UnitySerializer.Serialize(this);
    }
}
