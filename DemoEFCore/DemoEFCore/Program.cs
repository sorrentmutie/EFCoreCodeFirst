using DemoEFCore.Movies;
using Microsoft.EntityFrameworkCore;
using System.Data;

using var database = new MoviesDbContext();

//database.Genres.Add(new Genre { Name = "Erotico" });
//await database.SaveChangesAsync();

//var genres = await database.Genres.ToListAsync();
//foreach (var genre in genres)
//{
//    Console.WriteLine(genre.Name);
//}

//var movie = new Movie
//{
//    Title = "Via col Vento",
//    Description = "bla bal bla",
//    ReleaseDate = DateTime.Now.AddYears(-90),
//    IsReleased = true,
//    Genres = new List<Genre> {
//        new Genre { Name = "Sentimentale" } },
//    Comments = new List<Comment> { 
//            new Comment { Vote = 9, Text = "Commovente" },
//            new Comment { Vote = 2, Text = "Noioso"}}
//};
//database.Movies.Add(movie);
//await database.SaveChangesAsync();

//var genre = await database.Genres.FindAsync(1);
//if(genre != null)
//{
//    Console.WriteLine(genre.Name);
//}

//var genre2 = await database.Genres.Where
//    (gen => gen.Name!.StartsWith("Ero")).ToListAsync();
//if(genre2 != null)
//{
//    foreach (var g in genre2)
//    {
//        Console.WriteLine( g.Id );
//    }
//}

//var genre3 = await database.Genres.FirstOrDefaultAsync(
//    g => g.Name == "Erotico");
//if(genre3 != null)
//{
//    Console.WriteLine(genre3.Id);
//    genre3.Name = $"Soft {genre3.Name}";
//}


//var genre4 = await database.Genres.FindAsync(6);
//if(genre4 != null)
//{
//    database.Entry(genre4).State = EntityState.Deleted;
//}

//var movie = await database.Movies
//    .Include( m=> m.Comments)
//    .Include( m => m.Genres)
//    .FirstOrDefaultAsync(x => x.Id == 1);

//if(movie != null)
//{
//    movie.Comments.Add(new Comment { Text = "Interessante", Vote = 6 });

//    foreach(var genre in movie.Genres)
//    {
//        if(genre.Id == 7)
//        {
//            genre.Name = "Super Soft Erotico";
//        }
//    }
//   // movie.Genres.Add(new Genre { Name = "Soft Erotico" });

//var movie = new Movie
//{
//    Title = "Blade Runner",
//    Description = "Bla bla",
//    ReleaseDate = DateTime.Now.AddYears(-40),
//    IsReleased = true
//};
//database.Movies.Add(movie);
//await database.SaveChangesAsync();
//var idMovie = movie.Id;

//var actor = new Actor { Name = "Harrison Ford" };
//database.Actors.Add(actor);
//await database.SaveChangesAsync();

//var movieActor = new MovieActor
//{
//    MovieId = idMovie,
//    Character = "x",
//    Order = 1,
//    ActorId = 1
//};
//database.MoviesActors.Add(movieActor);
//await database.SaveChangesAsync();

var movie = await database.Movies.SingleOrDefaultAsync
    ( x => x.Id == 1 );
if(movie != null)
{
    var actor = new Actor() { Name = "Rutger TurnHauerer" };
    database.Actors.Add( actor );
    await database.SaveChangesAsync();

    var movieActor =
        new MovieActor
        {
            MovieId = movie.Id,
            ActorId = actor.Id,
            Character = "Cattivo",
            Order = 2
        };

    database.MoviesActors.Add( movieActor );
    await database.SaveChangesAsync();
}




