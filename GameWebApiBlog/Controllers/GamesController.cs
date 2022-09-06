using GameWebApiBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GameWebApiBlog.Controllers
{
public class GamesController : ApiController
{
    private static IList<Game> list = new List<Game>()
{
    new Game(){Id = 1234,Name="Mortal Kombat"},
    new Game(){Id = 1235,Name="Defender of Crown"},
    new Game(){Id = 1236,Name="Shadow of The Beast"},
    new Game(){Id = 1237,Name="Dune II"},
    new Game(){Id = 1238,Name="The Settlers"}
};

    // GET api/Games
    [AcceptVerbs("GET")]
    public IEnumerable<Game> AllGames()
    {
        return list;
    }

    [AcceptVerbs("GET", "POST")]
    public Game RetriveGame(int id)
    {
        return list.First(e => e.Id == id);
    }

    // POST api/Games
    [HttpPost]
    public void AddGame(Game Game)
    {
        int maxId = list.Max(e => e.Id);
        Game.Id = maxId + 1;
        list.Add(Game);
    }
    // PUT api/Games/12345
    [HttpPut]
    public void UpdateGame(int id, Game Game)
    {
        int index = list.ToList().FindIndex(e => e.Id == id);
        list[index] = Game;
    }
    // DELETE api/Games/12345
    [HttpDelete]
    public void DestroyGame(int id)
    {
        Game Game = RetriveGame(id);
        list.Remove(Game);
    }
}
}
