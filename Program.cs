namespace MVC;

class Program
{
    static void Main(string[] args)
    {
        Model model = new Model();
        View view = new View();
        Movie movie1 = new Movie("A real movie", 1999, "Horror");
        Movie movie2 = new Movie("A fake movie", 2025, "Action");
        Movie movie3 = new Movie("A Third Movie", 2020, "Musical");
        Controller ctrl = new Controller(model, view);
        model.AddMovie(movie1);
        model.AddMovie(movie2);
        model.AddMovie(movie3);
        ctrl.Run();
        
    }
}
