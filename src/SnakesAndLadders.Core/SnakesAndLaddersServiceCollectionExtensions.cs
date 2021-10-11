using Microsoft.Extensions.DependencyInjection;

namespace SnakesAndLadders.Core
{
    public static class SnakesAndLaddersServiceCollectionExtensions
    {

        public static void AddGame(this IServiceCollection services)
        {
            services.AddSingleton<IPlayerPositionStorage, PlayerPositionStorage>();
            
            services.AddSingleton<IRule, DefaultWinRule>();
            services.AddSingleton<IRule, DefaultLimitMoventRule>();
            services.AddSingleton<IGame, Game>();
            services.AddSingleton<IRollDice, RollD6>();
            services.AddSingleton<IAuditGame,OutputService>();
            services.AddSingleton<IRuleManager, RuleManager>();
           

        }
    }
}
