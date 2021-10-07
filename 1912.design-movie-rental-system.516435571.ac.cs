  public class MovieRentingSystem
        {

            Dictionary<int, SortedSet<(int price, int shop)>> movies;
            Dictionary<(int, int), int> movieShopMapToPrice;
            Dictionary<int, HashSet<int>> rented;
            SortedSet<(int price, int shop, int movie)> cheapestRentedMovies;

            public MovieRentingSystem(int n, int[][] entries)
            {
                movies = new Dictionary<int, SortedSet<(int price, int shop)>>();
                movieShopMapToPrice = new Dictionary<(int, int), int>();

                rented = new Dictionary<int, HashSet<int>>();
                cheapestRentedMovies = new SortedSet<(int price, int shop, int movie)>();

                foreach(var entry in entries)
                {
                    var shop = entry[0];
                    var movie = entry[1];
                    var price = entry[2];

                    if (!movies.ContainsKey(movie))
                    {
                        movies.Add(movie, new SortedSet<(int price, int shop)>());
                    }
                    movies[movie].Add((price, shop));

                    movieShopMapToPrice.Add((movie, shop), price);
                }
            }
            public IList<int> Search(int movie)
            {
                IList<int> result = new List<int>();
                if (!movies.ContainsKey(movie))
                {
                    return Array.Empty<int>();
                }

                var current = movies[movie];
                return current.Take(5).Select(x => x.shop).ToList();
            }

            public void Rent(int shop, int movie)
            {
                var price = movieShopMapToPrice[(movie, shop)];
                movies[movie].Remove((price, shop));

                if(rented.ContainsKey(movie) == false)
                {
                    rented.Add(movie, new HashSet<int>());
                }
                rented[movie].Add(shop);

                cheapestRentedMovies.Add((price, shop, movie));
            }

            public void Drop(int shop, int movie)
            {
                var price = movieShopMapToPrice[(movie, shop)];
                movies[movie].Add((price, shop));

                rented[movie].Remove(shop);
                cheapestRentedMovies.Remove((price, shop, movie));
            }

            public IList<IList<int>> Report()
            {
                return cheapestRentedMovies.Take(5).Select(x => new List<int>() { x.shop, x.movie } as IList<int>).ToList();
            }
        }
