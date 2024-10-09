namespace MVC;

public class View(){
    public void ViewMovie(Movie movie){
        Console.WriteLine("Title: " + movie.Title);
        Console.WriteLine("Genre: " + movie.Genre);
        Console.WriteLine("Year: " + movie.Year);
    }

    public void ViewMultiple(List<Movie> movies){
        foreach (var item in movies)
        {
            ViewMovie(item);
        }
    }

}