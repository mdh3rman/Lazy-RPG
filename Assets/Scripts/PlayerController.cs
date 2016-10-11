using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Reflection;

public class PlayerController : MonoBehaviour {

    
    public Text EnemiesKilledUIText;
    public Text HPText;
    public Text MPText;
    public Text STRText;
    public Text DEFText;
    public Text MOVText;

    private Rigidbody2D playerRigidBody2D;
    private float forwardMovementSpeed = 5.0f;

    private static int enemiesKilled;
    private static Animator animator;
    private static bool isAttacking = false;
    private static PlayerStats stats;

    private Vital _hp;
    private Vital _mp;
    private StatModifiable _str;
    private StatModifiable _def;
    private StatModifiable _mov;

    public Vital HP {
        get { return _hp; }
        set { _hp = value; }
    }
    public Vital MP {
        get { return _mp; }
        set { _mp = value; }
    }
    public StatModifiable STR {
        get { return _str; }
        set { _str = value; }
    }
    public StatModifiable DEF {
        get { return _def; }
        set { _def = value; }
    }
    public StatModifiable MOV {
        get { return _mov; }
        set { _mov = value; }
    }

    void Start () {
        animator = GetComponent<Animator>();
        playerRigidBody2D = GetComponent<Rigidbody2D>();
        InitStats();
        enemiesKilled = 0;
        ShowCount();
	}

    private void ShowCount()
    {
        EnemiesKilledUIText.text = Constant.KillCount + enemiesKilled;
    }

    void FixedUpdate()
    {
        bool forceAttack = Input.GetButton("Fire1");

        if (!isAttacking)
            Move(MOV.StatValue/forwardMovementSpeed);
        else
            Move(0f);

      
        ShowCount();
    }

   void OnCollisionEnter2D (Collision2D col)
    {
        if(col.collider.name.StartsWith("en"))
        {
            isAttacking = true;
            Move(0f);
            animator.SetBool("Attacking", isAttacking);
        }
    }

    void Move(float speed)
    {
        Vector2 newVelocity = playerRigidBody2D.velocity;
        newVelocity.x = speed;
        playerRigidBody2D.velocity = newVelocity;
    }

    public static void EnemyIsDead()
    {
        isAttacking = false;
        enemiesKilled++;
        animator.SetBool("Attacking", isAttacking);
    }

    public void InitStats()
    {
        stats = new PlayerStats();
        HP = stats.GetStat<Vital>(StatType.Health);
        MP = stats.GetStat<Vital>(StatType.Mana);
        STR = stats.GetStat<StatModifiable>(StatType.Strength);
        DEF = stats.GetStat<StatModifiable>(StatType.Defense);
        MOV = stats.GetStat<StatModifiable>(StatType.Movement);



        HP.OnCurrentValueChange += OnStatValueChange;
        DisplayStatValues();
    }

    void OnStatValueChange(object sender, EventArgs args)
    {
        Vital vital = (Vital)sender;
        if(vital != null)
        {
            vital.StatCurrentValue = vital.StatValue;
        }
    }

    void DisplayStatValues()
    {
        Text displayText;
        string toDisplay = "NaN";
        ForEachEnum<StatType>((statType) => {
            Stat stat = stats.GetStat((StatType)statType);
            if (stat != null)
            {
                Vital vital = stat as Vital;

                if (vital != null)
                {
                    Debug.Log(string.Format("Stat {0}'s value is {1}/{2}",
                        vital.StatName, vital.StatCurrentValue, vital.StatValue));
                    toDisplay = vital.StatCurrentValue + "/" + vital.StatValue;
                }
                else
                {
                    Debug.Log(string.Format("Stat {0}'s value is {1}",
                        stat.StatName, stat.StatValue));
                    toDisplay = stat.StatValue.ToString();
                }
                displayText = GameObject.Find(stat.StatName + "_Value").GetComponent<Text>();
                displayText.text = toDisplay;
            }
            
        });
    }

    void ForEachEnum<T>(Action<T> action)
    {
        if (action != null)
        {
            var statTypes = Enum.GetValues(typeof(T));
            foreach (var statType in statTypes)
            {
                action((T)statType);
            }
        }
    }

    public void ChangeStats(Button button)
    {
        float value = 0f;

        value = 10.0f;

        if (button.name.Contains("Decrease"))
        {
            value = -(value);
        }

        PropertyInfo pinfo = typeof(PlayerController).GetProperty(button.name.Substring(0, button.name.IndexOf('_')));
        object obj = pinfo.GetValue(this, null);

        StatModifiable statToChange = (StatModifiable)obj;
        statToChange.AddModifier(new StatModifier(StatType.Strength, StatModifier.Types.BaseValueAdd, value));
        statToChange.UpdateModifiers();

        DisplayStatValues();

    }
}
