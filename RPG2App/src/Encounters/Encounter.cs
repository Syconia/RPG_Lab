namespace RPG2App;

public class Encounter
{
    public static List<Encounter> Encounters = new List<Encounter>();
    public enum EncounterType{Combat, Item, Empty}
    public string ?Name { get; protected set; }
    public string ?FlavourText { get; protected set; }

    public EncounterType Type { get; protected set; }

    protected Random random;

    public Encounter()
    {
        this.random = new Random();
    }

    public virtual void ResolveEncounter() {}

    public static void AddEncounter(Encounter encounter)
    {
        Encounters.Add(encounter);
    }

    public static void RemoveEncounter(Encounter encounter)
    {
        Encounters.Remove(encounter);
    }

    public static Encounter GetRandomEncounter()
    {
        int index = new Random().Next(0, Encounters.Count);
        return Encounters[index];
    }

}