namespace RPG2App;

public class Entity
{
    public string ?Name { get; protected set; }
    public int MaxHealth { get; protected set; }
    public int Health { get; protected set; }
    public int Strength { get; protected set; }

    public Entity() {}

    public Entity(string name, int maxHP, int strength)
    {
        this.Name = name;
        this.MaxHealth = maxHP;
        this.Health = maxHP;
        this.Strength = strength;
    }

    public void ChangeHealth(int DeltaHP)
    {
        this.Health += DeltaHP;
        if (this.Health <= 0) this.Die();
    }

    public virtual int DealDamage()
    {
        return this.Strength;
    }

    public virtual void Die() {}
}