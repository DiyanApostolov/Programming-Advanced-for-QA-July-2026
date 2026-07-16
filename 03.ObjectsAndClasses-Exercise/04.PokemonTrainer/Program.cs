namespace _04.PokemonTrainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string input = Console.ReadLine();

            while (input != "Tournament")
            {
                //"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"

                string[] data = input.Split(" ");

                string trainerName = data[0];
                string pokemonName = data[1];
                string pokemonElement = data[2];
                int pokemonHealth = int.Parse(data[3]);

                // създавам си нов покемон
                Pokemon newPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                // търся дали вече има такъв третьор в списъка
                if (trainers.Any(t => t.Name == trainerName))
                {
                    // изваждам си съществуващия треньор от псисъка
                    Trainer existingTrainer = trainers.FirstOrDefault(t => t.Name == trainerName);

                    // добавям покемона към треньора
                    existingTrainer.Pokemons.Add(newPokemon);
                }
                else
                {
                    // създавам си нов треньор
                    Trainer newTrainer = new Trainer(trainerName);

                    // добавям покемона към треньора
                    newTrainer.Pokemons.Add(newPokemon);

                    // добавям новия треньор в списъка
                    trainers.Add(newTrainer);
                }

                input = Console.ReadLine();
            }

            string element = Console.ReadLine();

            while (element != "End")
            {
                // обикаляме всички треньори
                foreach (Trainer currentTrainer in trainers)
                {
                    // проверяваме дали конкретния треньор има покемно с дадения елемент
                    if (currentTrainer.Pokemons.Any(p => p.Element == element))
                    {
                        // получава една значка
                        currentTrainer.NumberOfBadges++;
                    }
                    else
                    {
                        // обикаляме всичките му покемони и вадим 10 Health
                        foreach (Pokemon pokemon in currentTrainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }

                        // премахваме всички покемони с енергия <= 0
                        currentTrainer.Pokemons.RemoveAll(p => p.Health <= 0);
                    }
                }

                element = Console.ReadLine();
            }

            // сортираме треньорите в низходящ ред по броя на значките
            foreach (Trainer trainer in trainers.OrderByDescending(t => t.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }
    }
}
