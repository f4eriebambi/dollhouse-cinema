namespace DollhouseCinema.Models;

// sample model for testing
// will replace with api data later
public static class SampleData
{
    public static List<SampleFilm> LobbyFilms { get; } = new()
    {
        new SampleFilm("The Virgin Suicides", 1999, "drama", "the story revolves around a group of guys who become obsessed with the girls of a conservative family."),
        new SampleFilm("Heathers", 1988, "comedy · crime", "veronica is part of the most popular clique at her high school. soon she starts killing the cool kids with the help of her new boyfriend j.d."),
        new SampleFilm("The Craft", 1996, "horror", "a new student befriends three teenage girls from her high school who practise witchcraft against those who irk them."),
        new SampleFilm("Ginger Snaps", 2000, "horror", "brigitte and ginger are blood sisters who share a common passion for death. when ginger is bitten by a dog, everything changes.")
    };
}