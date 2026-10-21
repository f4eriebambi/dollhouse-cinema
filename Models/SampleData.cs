namespace DollhouseCinema.Models;

// curated collections and tmdb film ids app uses
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
    
    public static Dictionary<string, List<int>> CollectionFilmIds { get; } = new()
    {
        { "weird girl movies", new List<int> { 9871, 18892 } }, 
        { "comfort <333", new List<int> { 10198, 14191, 11211, 17379, 804 } }, 
        { "im just a monster in love", new List<int> { 791177, 993784, 399055 } },
        { "gothic.", new List<int> { 426063, 201085, 310131 } }
    };
    
    public static string GetCollectionImage(string collectionTitle)
    {
        return collectionTitle switch
        {
            "comfort <333" => "/images/collections/comfort.jpg",
            "gothic." => "/images/collections/gothic.jpg",
            "im just a monster in love" => "/images/collections/monsterinlove.jpg",
            "weird girl movies" => "/images/collections/weirdgirlmovies.jpg",
            _ => "/images/placeholder.jpg"
        };
    }
}