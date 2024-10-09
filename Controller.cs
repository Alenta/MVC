using System.Runtime.Serialization;

namespace MVC;
public class Controller
{
    bool exit = false;
    bool subtaskDone = false;
    private Model _model;
    private View _view;

    public Controller(Model model, View view)
    {
        _model = model;
        _view = view;
    }

    public void Run(){
        exit = false;
        subtaskDone = false;
        while(!exit)
        {
            Console.WriteLine("Waiting for user input. Enter 'Help' for available commands");
            string? input = Console.ReadLine();
            if(input == "View all"){_view.ViewMultiple(_model.GetAllMovies());}
            else if(input == "Add")
            {
                _model.AddMovie(CreateMovie());
                Console.WriteLine("Successfully added movie!");
            }
            else if(input == "Update"){
                subtaskDone = false;
                while(!subtaskDone){
                    Console.WriteLine("Trying to update movie.");
                    Console.WriteLine("Enter movie title to update:");
                    string? _title = Console.ReadLine();
                    Movie movieToUpdate = _model.FindMovie(_title!);
                    if(movieToUpdate == null) Console.WriteLine("Could not find movie by that title. Are you sure it has been added?");
                    else{
                        Movie updatedMovie = CreateMovie();
                        _model.UpdateMovie(movieToUpdate, updatedMovie);
                        subtaskDone = true;
                        Console.WriteLine("Successfully updated movie!");
                    }
                }
            }
            else if(input == "Delete"){
                    Console.WriteLine("Trying to delete movie.");
                    Console.WriteLine("Enter movie title to delete:");
                    string? _title = Console.ReadLine();
                    Movie movieToDelete = _model.FindMovie(_title!);
                    if(movieToDelete == null) Console.WriteLine("Could not find movie by that title. Are you sure it has been added?");
                    else{
                        _model.DeleteMovie(movieToDelete);
                        Console.WriteLine("Successfully deleted movie!");
                    }
            }
            else if(input == "Exit" || input == "End"){Console.WriteLine("Closing application. Enter anything to exit..."); Console.ReadLine(); exit = true;}
            else if(input == "Help") {
                Console.WriteLine("View all - Displays all movies in the model");
                Console.WriteLine("Add - Add movie to model");
                Console.WriteLine("Update - Update movie in model");
                Console.WriteLine("Delete - Delete movie in model");
                Console.WriteLine("Exit - Exit the application");
                Console.WriteLine("Help - Display available commands");
            }
            else Console.WriteLine("Please enter a valid command. Enter 'Help' to view available commands");
        }
    }

    public Movie CreateMovie(){
        bool task = false;
        Movie _newMovie = new Movie("",0,"");
        while(!task)
        {
            Console.WriteLine("Trying to add new movie to list.");
            Console.WriteLine("What is the name of the movie?");
            string? _title = Console.ReadLine();
            if(_title == "") Console.WriteLine("Please enter a valid name");
            else{
                Console.WriteLine("What year was the movie released?");
                string? _year = Console.ReadLine();
                if(!int.TryParse(_year, out int parsedNumber))
                {
                    Console.WriteLine("All numbers must be a valid value. Doubles with numbers only.");
                }
                else 
                { 
                    Console.WriteLine("Which genre is the movie?");
                    string? _genre = Console.ReadLine();
                    if(_genre == "") Console.WriteLine("Please enter a valid genre");
                    else { 
                        _newMovie = new Movie(_title!,parsedNumber,_genre!);
                        return _newMovie;
                    }
                }  
            }                   
        }
        return _newMovie;
    }
}