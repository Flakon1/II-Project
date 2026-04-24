using System;

public class BeachProperties
{
    
    private string name;
    private string location;
    private string type; 
    private int cleanliness; 
    private int safeness; 

    private bool sunbeds;
    private bool umbrellas;
    private bool showers;
    private bool toilets;

    private string parking; 

    private bool algae;
    private bool jellyfish;
    private bool seaShells;

    private string wind; 
    private string weather; 

    private int crowdedness; 
    private bool lifeguards;

    public BeachProperties(
        string name,
        string location,
        string type,
        int cleanliness,
        int safeness,
        bool sunbeds,
        bool umbrellas,
        bool showers,
        bool toilets,
        string parking,
        bool algae,
        bool jellyfish,
        bool seaShells,
        string wind,
        string weather,
        int crowdedness,
        bool lifeguards
    )
    {
        this.name = name;
        this.location = location;
        this.type = type;
        this.cleanliness = cleanliness;
        this.safeness = safeness;
        this.sunbeds = sunbeds;
        this.umbrellas = umbrellas;
        this.showers = showers;
        this.toilets = toilets;
        this.parking = parking;
        this.algae = algae;
        this.jellyfish = jellyfish;
        this.seaShells = seaShells;
        this.wind = wind;
        this.weather = weather;
        this.crowdedness = crowdedness;
        this.lifeguards = lifeguards;
    }

    public string GetName() { return name; }
    public void SetName(string value) { name = value; }

    public string GetLocation() { return location; }
    public void SetLocation(string value) { location = value; }

    public string GetType() { return type; }
    public void SetType(string value) { type = value; }

    public int GetCleanliness() { return cleanliness; }
    public void SetCleanliness(int value) { cleanliness = value; }

    public int GetSafeness() { return safeness; }
    public void SetSafeness(int value) { safeness = value; }

    public bool GetSunbeds() { return sunbeds; }
    public void SetSunbeds(bool value) { sunbeds = value; }

    public bool GetUmbrellas() { return umbrellas; }
    public void SetUmbrellas(bool value) { umbrellas = value; }

    public bool GetShowers() { return showers; }
    public void SetShowers(bool value) { showers = value; }

    public bool GetToilets() { return toilets; }
    public void SetToilets(bool value) { toilets = value; }

    public string GetParking() { return parking; }
    public void SetParking(string value) { parking = value; }

    public bool GetAlgae() { return algae; }
    public void SetAlgae(bool value) { algae = value; }

    public bool GetJellyfish() { return jellyfish; }
    public void SetJellyfish(bool value) { jellyfish = value; }

    public bool GetSeaShells() { return seaShells; }
    public void SetSeaShells(bool value) { seaShells = value; }

    public string GetWind() { return wind; }
    public void SetWind(string value) { wind = value; }

    public string GetWeather() { return weather; }
    public void SetWeather(string value) { weather = value; }

    public int GetCrowdedness() { return crowdedness; }
    public void SetCrowdedness(int value) { crowdedness = value; }

    public bool GetLifeguards() { return lifeguards; }
    public void SetLifeguards(bool value) { lifeguards = value; }

}