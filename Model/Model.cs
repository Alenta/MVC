using System.ComponentModel;
using System.Dynamic;

public class Movie{
    public string? Title{get;set;}
    public int Year{get;set;}
    public string? Genre{get;set;}

    public Movie(string title, int year, string genre){
        Title = title;
        Year = year;
        Genre = genre;
    }
}

public class Model(){
    List<Movie> Movies = [];
    public void AddMovie(Movie movie){
        Movies.Add(movie);
    }
    public void DeleteMovie(Movie movie){
        Movies.Remove(movie);
    }
    public void UpdateMovie(Movie movieToUpdate, Movie newMovie){
        movieToUpdate.Title = newMovie.Title;
        movieToUpdate.Year = newMovie.Year;
        movieToUpdate.Genre = newMovie.Genre;
    }
    public List<Movie> GetAllMovies(){
        return Movies;
    }
    public Movie FindMovie(string movieTitle){
        foreach (var movie in Movies)
        {
            if(movieTitle == movie.Title) return movie;
        }
        throw new WarningException("Cannot find movie by that title. Are you sure it exists?");
    }
    
}