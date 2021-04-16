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
            foreach (var modifier in PAMods)
            {
                mod += modifier.Value;
            }
            return physicalAttack + mod > 0 ? physicalAttack + mod : 1;
        }
        set { physicalAttack = value; }
    }
    public int MagicAttack
    {
        get
        {
            int mod = 0;
            foreach (var modifier in MAMods)
            {
                mod += modifier.Value;
            }
            return magicAttack + mod > 0 ? magicAttack + mod : 1;
        }
        set { magicAttack = value; }
    }
    public int PhysicalDefense
    {
        get
        {
            int mod = 0;
            foreach (var modifier in PDMods)
            {
                mod += modifier.Value;
            }
            return physicalDefense + mod > 0 ? physicalDefense + mod : 1;
        }
        set { physicalDefense = value; }
    }
    public int MagicDefense
    {
        get
        {
            int mod = 0;
            foreach (var modifier in MDMods)
            {
                mod += modifier.Value;
            }
            return magicDefense + mod > 0 ? magicDefense + mod : 1;
        }
        set { magicDefense = value; }
    }
    public int Speed
    {
        get
        {
            int mod = 0;
            foreach (var modifier in SpeedMods)
            {
                mod += modifier.Value;
            }
            return speed + mod > 0 ? speed + mod : 1;
        }
        set { speed = value; }
    }
    public int Accuracy
    {
        get
        {
            int mod = 0;
            foreach (var modifier in AccuracyMods)
            {
                mod += modifier.Value;
            }
            return accuracy + mod > 0 ? accuracy + mod : 1;
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
    public Queue<StatsMod> PAMods = new Queue<StatsMod>();
    public Queue<StatsMod> PDMods = new Queue<StatsMod>();
    public Queue<StatsMod> MAMods = new Queue<StatsMod>();
    public Queue<StatsMod> MDMods = new Queue<StatsMod>();
    public Queue<StatsMod> SpeedMods = new Queue<StatsMod>();
    public Queue<StatsMod> AccuracyMods = new Queue<StatsMod>();

    //Effects over time
    public Queue<Poison> poisonQueue = new Queue<Poison>();     //poison
    public Queue<DoT> DOTQueue = new Queue<DoT>();        //damage over time
    public Queue<HoT> HOTQueue = new Queue<HoT>();        //heal over time

    //current XP
    public int CritXpValue;

    //Skills
    [SerializeField] public List<MonoBehaviour> skills;



    public void TakeDamage(int value, Type? type = null)
    {
        //Managing elemental weaknesses
        bool strong = false;
        bool weak = false;

        if(type == Type.Earth)
        {
            if(critType == Type.Wind)
            {
                value = (int)(value * 0.75);
                strong = true;
            }
            else if(critType == Type.Lightning)
            {
                value = (int)(value * 1.5);
                weak = true;
            }
        }
        else if(type == Type.Lightning)
        {
            if(critType == Type.Earth)
            {
                value = (int)(value * 0.75);
                strong = true;
            }
            else if(critType == Type.Wind)
            {
                value = (int)(value * 1.5);
                weak = true;
            }
        }
        else if(type == Type.Wind)
        {
            if(critType == Type.Lightning)
            {
                value = (int)(value * 0.75);
                strong = true;
            }
            else if(critType == Type.Earth)
            {
                value = (int)(value * 1.5);
                weak = true;
            }
        }
        else if(type == Type.Fire)
        {
            if(critType == Type.Water)
            {
                value = (int)(value * 0.75);
                strong = true;
            }
            else if(critType == Type.Nature)
            {
                value = (int)(value * 1.5);
                weak = true;
            }
        }
        else if(type == Type.Water)
        {
            if(critType == Type.Nature)
            {
                value = (int)(value * 0.75);
                strong = true;
            }
            else if(critType == Type.Fire)
            {
                value = (int)(value * 1.5);
                weak = true;
            }
        }
        else if(type == Type.Nature)
        {
            if(critType == Type.Fire)
            {
                value = (int)(value * 0.75);
                strong = true;
            }
            else if(critType == Type.Water)
            {
                value = (int)(value * 1.5);
                weak = true;
            }
        }


        Debug.Log(value + "  " + weak + "  " + strong);
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
        value = Health + value > MaxHealth ? MaxHealth - Health : value;
        Health = Health + value;
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

    public void InflictPoison(int value, int turns = 3)
    {
        poisonQueue.Enqueue(new Poison(value, turns));
    }
    public void InflictDoT(int value, Type element,int turns = 3)
    {
        DOTQueue.Enqueue(new DoT(value, element, turns));
    }
    public void InflictHoT(int value, int turns = 3)
    {
        HOTQueue.Enqueue(new HoT(value, turns));
    }

    public void ProcessPoison()
    {
        foreach(Poison p in poisonQueue)
        {
            TakeDamage(p.Value + Random.Range(-2, 2));
            p.Turns--;
            if(p.Turns <= 0)
            {
                poisonQueue.Dequeue();
            }
        }
    }
    public void ProcessDoT()
    {
        foreach(DoT dot in DOTQueue)
        {
            TakeDamage(dot.Value + Random.Range(-3, 3), dot.Element);
            dot.Turns--;
            if(dot.Turns <= 0)
            {
                DOTQueue.Dequeue();
            }
        }
    }
    public void ProcessHoT()
    {
        foreach (HoT hot in HOTQueue)
        {
            Heal(hot.Value);
            hot.Turns--;
            if (hot.Turns <= 0)
            {
                HOTQueue.Dequeue();
            }
        }
    }

    public void advanceTurn()
    {
        foreach(StatsMod mod in PAMods)
        {
            mod.Turns--;
            if(mod.Turns <= 0)
            {
                PAMods.Dequeue();
            }
        }
        foreach(StatsMod mod in MAMods)
        {
            mod.Turns--;
            if(mod.Turns <= 0)
            {
                MAMods.Dequeue();
            }
        }
        foreach(StatsMod mod in PDMods)
        {
            mod.Turns--;
            if(mod.Turns <= 0)
            {
                PDMods.Dequeue();
            }
        }
        foreach(StatsMod mod in MDMods)
        {
            mod.Turns--;
            if(mod.Turns <= 0)
            {
                MDMods.Dequeue();
            }
        }
        foreach(StatsMod mod in AccuracyMods)
        {
            mod.Turns--;
            if(mod.Turns <= 0)
            {
                AccuracyMods.Dequeue();
            }
        }
        foreach(StatsMod mod in SpeedMods)
        {
            mod.Turns--;
            if(mod.Turns <= 0)
            {
                SpeedMods.Dequeue();
            }
        }

        ProcessPoison();
        ProcessDoT();
        ProcessHoT();
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
        public int Value { get; set; }
        public int Turns { get; set; }
        public Mod Type { get; set; }
        public StatsMod(int value, Mod type, int turns = 5)
        {
            this.Value = value;
            this.Type = type;
            this.Turns = turns;
        }
    }
    public class Poison
    {
        public int Value { get; set; }
        public int Turns { get; set; }

        public Poison(int val, int turns)
        {
            Value = val;
            Turns = turns;
        }
    }
    public class DoT
    {
        public int Value { get; set; }
        public int Turns { get; set; }
        public Type Element { get; set; }

        public DoT(int val, Type element, int turns)
        {
            Value = val;
            Turns = turns;
            Element = element;
        }
    }
    public class HoT
    {
        public int Value { get; set; }
        public int Turns { get; set; }

        public HoT(int val, int turns)
        {
            Value = val;
            Turns = turns;
        }
    }
}



