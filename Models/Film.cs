namespace DollhouseCinema.Models;

public class Film
{
    // private fields
    private string title;
    private int year;
    private string genre;
    private string description;
    private string posterUrl;
    private string? imdbRating;
    private int? userRating;
    private string? userNotes;
    private DateTime? watchDate;

    // public properties
    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public int Year
    {
        get { return year; }
        set { year = value; }
    }

    public string Genre
    {
        get { return genre; }
        set { genre = value; }
    }

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    public string PosterUrl
    {
        get { return posterUrl; }
        set { posterUrl = value; }
    }

    // optional properties
    public string? ImdbRating
    {
        get { return imdbRating; }
        set { imdbRating = value; }
    }
    
    public int? UserRating
    {
        get { return userRating; }
        set { userRating = value; }
    }

    public string? UserNotes
    {
        get { return userNotes; }
        set { userNotes = value; }
    }

    public DateTime? WatchDate
    {
        get { return watchDate; }
        set { watchDate = value; }
    }

    // constructor
    public Film(string title, int year, string genre, string description, string posterUrl)
    {
        this.title = title;
        this.year = year;
        this.genre = genre;
        this.description = description;
        this.posterUrl = posterUrl;
        this.imdbRating = null; // starts empty until omdb fetches it
    }
}