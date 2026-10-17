namespace DollhouseCinema.Models;

// sample model for testing
// will replace with api data later
public static class SampleData
{
    public static List<SampleCollection> CuratedCollections { get; } = new()
    {
        new SampleCollection("weird girl movies", "being a weird girl is cool" ),
        new SampleCollection("comfort <333", "feels like a hug" ),
        new SampleCollection( "im just a monster in love", "who doesn't like monster romances" ),
        new SampleCollection( "gothic.", "spooky beauties" )
    };
    public static List<string> CollectionColours { get; } = new()
    {
        "colour-pink",
        "colour-sage",
        "colour-lace",
        "colour-noir",
        "colour-midnight",
        "colour-cherry",
        "colour-lilac",
        "colour-rosewood"
    };
    
    public static List<int> LobbyFilmIds { get; } = new()
    {
        1443,  // the virgin suicides
        2640,  // heathers
        9100,  // the craft
        9871, // ginger snaps
        19994  // jennifer's body
    };
    
    public static List<int> ExploreDefaultIds { get; } = new()
    {
        1443, 
        2640,  
        9100,  
        9871, 
        19994,
        447277,
        10625,
        791177,
        1933,
        438631,
        65086,
        1423191,
        11211,
        695721,
        354912,
        1020006,
        32293,
        201085,
        10315,
        414906,
        13971,
        496243,
        44214,
        426063,
        96936
    };
}