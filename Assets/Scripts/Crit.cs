using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//crit types
public enum Type { Earth, Lightning, Wind, Fire, Water, Nature }

//crit's stats rating
//weak -----> stat +0 / +1 each level
//average --> stat +1 / +2 each level
//strong ---> stat +2 / +3 each level
//max ------> stat +2 / +3 / +4 each level with low chance for +2
//elite ----> stat +3 / +4 each level with high chance for +4
public enum UpRate { Weak, Average, Strong, Max, Elite }

//possible stat modifications (buff / debuff)
public enum Mod { PA, PD, MA, MD, Speed, Accuracy };

public class Crit : MonoBehaviour
{
    public string critName;
    public string critDescription;
    //sprite array for crit evolutions'textures
    public Sprite[] images = new Sprite[4];
    //sprite array for crit evolutions'icons
    public Sprite[] frames = new Sprite[4];

    public Sprite ActiveSprite;
    public Sprite ActiveFrame;

    public bool Alive;

    //crit type
    [SerializeField] private Type critType;
    public Type CritType { get { return critType; } set { critType = value; } }

    [SerializeField] private int level;
    [SerializeField] private int xp;
    public int Level { get { return level; } set { level = value; } }
    public int Xp { get { return xp; } set { xp = value; } }


    public int MaxHealth;
    [SerializeField] private int health;
    [SerializeField] private int physicalAttack;
    [SerializeField] private int magicAttack;
    [SerializeField] private int physicalDefense;
    [SerializeField] private int magicDefense;
    [SerializeField] private int speed;
    [SerializeField] private int accuracy;

    public int Health { get { return health; } set { health = value; } }

    //for all the following stats setters set the base crit stat
    //getters calculate the stats final value after applying
    //all modifications (buff / debuff)
    public int PhysicalAttack
    {
        get
        {
            int mod = 0;
            foreach (var modififer in PAMods)
            {
                mod += modififer.value;
            }
            return physicalAttack + mod;
        }
        set { physicalAttack = value; }
    }
    public int MagicAttack
    {
        get
        {
            int mod = 0;
            foreach (var modififer in MAMods)
            {
                mod += modififer.value;
            }
            return magicAttack + mod;
        }
        set { magicAttack = value; }
    }
    public int PhysicalDefense
    {
        get
        {
            int mod = 0;
            foreach (var modififer in PDMods)
            {
                mod += modififer.value;
            }
            return physicalDefense + mod;
        }
        set { physicalDefense = value; }
    }
    public int MagicDefense
    {
        get
        {
            int mod = 0;
            foreach (var modififer in MDMods)
            {
                mod += modififer.value;
            }
            return magicDefense + mod;
        }
        set { magicDefense = value; }
    }
    public int Speed
    {
        get
        {
            int mod = 0;
            foreach (var modififer in SpeedMods)
            {
                mod += modififer.value;
            }
            return speed + mod;
        }
        set { speed = value; }
    }
    public int Accuracy
    {
        get
        {
            int mod = 0;
            foreach (var modififer in AccuracyMods)
            {
                mod += modififer.value;
            }
            return accuracy + mod;
        }
        set { accuracy = value; }
    }

    //if confused != 0 the it's value shows the remaining number of
    //turns till recovery
    public int Confused;

    //if asleep != 0 the it's value shows the remaining number of
    //turns till recovery
    public int Asleep;

    [SerializeField] private UpRate HealthUpRate;
    [SerializeField] private UpRate PAUpRate;
    [SerializeField] private UpRate MAUpRate;
    [SerializeField] private UpRate PDUpRate;
    [SerializeField] private UpRate MDUpRate;
    [SerializeField] private UpRate SpeedUpRate;

    //crit controller specifier (player-controlled or AI-controlled)
    public ICritController controller;

    //Queues to store all stat modifications
    //as they are not permanent they'll be temporarily stored during battle
    Queue<StatsMod> PAMods = new Queue<StatsMod>();
    Queue<StatsMod> PDMods = new Queue<StatsMod>();
    Queue<StatsMod> MAMods = new Queue<StatsMod>();
    Queue<StatsMod> MDMods = new Queue<StatsMod>();
    Queue<StatsMod> SpeedMods = new Queue<StatsMod>();
    Queue<StatsMod> AccuracyMods = new Queue<StatsMod>();

    //current XP
    public int CritXpValue;

    //Skills
    [SerializeField] public List<MonoBehaviour> skills;

    public void TakeDamage(int value)
    {
        Health = (Health - value >= 0) ? Health - value : 0;
        if (Asleep != 0)
        {
            Asleep = 0;
        }
        if (Health == 0)
        {
            Alive = false;
        }
        //TODO animate 
    }
    public void Heal(int value)
    {
        Health = (Health + value) % (Health + 1);
        //TODO animate 
    }

    public void DecreasePA(int value)
    {
        PAMods.Enqueue(new StatsMod(-value, Mod.PA));
        //TODO aanimate
    }
    public void DecreasePD(int value)
    {
        PDMods.Enqueue(new StatsMod(-value, Mod.PD));
        //TODO aanimate
    }
    public void DecreaseMA(int value)
    {
        MAMods.Enqueue(new StatsMod(-value, Mod.MA));
        //TODO aanimate
    }
    public void DecreaseMD(int value)
    {
        MDMods.Enqueue(new StatsMod(-value, Mod.MD));
        //TODO aanimate
    }
    public void DecreaseSpeed(int value)
    {
        SpeedMods.Enqueue(new StatsMod(-value, Mod.Speed));
        //TODO animate
    }
    public void DecreaseAccuracy(int value)
    {
        AccuracyMods.Enqueue(new StatsMod(-value, Mod.Accuracy));
        //TODO animate
    }

    public void InflictConfuse(int turns)
    {
        Confused += turns;
        //TODO animate
    }
    public void InflictSleep(int turns)
    {
        Asleep += turns;
        //TODO animate
    }

    public void IncreasePA(int value)
    {
        PAMods.Enqueue(new StatsMod(value, Mod.PA));
        //TODO aanimate
    }
    public void IncreasePD(int value)
    {
        PDMods.Enqueue(new StatsMod(value, Mod.PD));
        //TODO aanimate
    }
    public void IncreaseMA(int value)
    {
        MAMods.Enqueue(new StatsMod(value, Mod.MA));
        //TODO aanimate
    }
    public void IncreaseMD(int value)
    {
        MDMods.Enqueue(new StatsMod(value, Mod.MD));
        //TODO aanimate
    }
    public void IncreaseSpeed(int value)
    {
        SpeedMods.Enqueue(new StatsMod(value, Mod.Speed));
        //TODO animate
    }
    public void IncreaseAccuracy(int value)
    {
        AccuracyMods.Enqueue(new StatsMod(value, Mod.Accuracy));
        //TODO animate
    }

    //executed when a skill misses
    public void miss()
    {
        //TODO animate
    }

    public void GainXP(int value)
    {
        Xp += value;
        //TODO 
    }

    //stat modification class that stores modification values 
    //and the remaining turns before they go down
    public class StatsMod
    {
        public int value { get; set; }
        public int turns { get; set; }
        public Mod type { get; set; }
        public StatsMod(int value, Mod type, int turns = 5)
        {
            this.value = value;
            this.type = type;
            this.turns = turns;
        }
    }
}
