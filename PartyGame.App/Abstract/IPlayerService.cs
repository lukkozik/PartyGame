using PartyGame.Domain.Entity;
using System.Collections.Generic;

namespace PartyGame.App.Abstract
{
    interface IPlayerService
    {
        List<Player> Players { get; set; }
        List<Player> CreatePlayers();
        void AddNewPlayerView(int numberOfPlayers);
        void AddNewPlayer(int playerId);
    }
}
