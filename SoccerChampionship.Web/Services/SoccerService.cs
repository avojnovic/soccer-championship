
namespace SoccerChampionship.Web.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using SoccerChampionship.Web;


    // Implements application logic using the SoccerEntities2 context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class SoccerService : LinqToEntitiesDomainService<SoccerEntities2>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Categories' query.
        public IQueryable<Category> GetCategories()
        {
            return this.ObjectContext.Categories;                   
        }

        public void InsertCategory(Category category)
        {
            if ((category.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(category, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Categories.AddObject(category);
            }
        }

        public void UpdateCategory(Category currentCategory)
        {
            this.ObjectContext.Categories.AttachAsModified(currentCategory, this.ChangeSet.GetOriginal(currentCategory));
        }

        public void DeleteCategory(Category category)
        {
            if ((category.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Categories.Attach(category);
            }
            this.ObjectContext.Categories.DeleteObject(category);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Games' query.
        public IQueryable<Game> GetGames()
        {
            return this.ObjectContext.Games;
        }

        public void InsertGame(Game game)
        {
            if ((game.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(game, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Games.AddObject(game);
            }
        }

        public void UpdateGame(Game currentGame)
        {
            this.ObjectContext.Games.AttachAsModified(currentGame, this.ChangeSet.GetOriginal(currentGame));
        }

        public void DeleteGame(Game game)
        {
            if ((game.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Games.Attach(game);
            }
            this.ObjectContext.Games.DeleteObject(game);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'GameDays' query.
        public IQueryable<GameDay> GetGameDays()
        {
            return this.ObjectContext.GameDays;
        }

        public void InsertGameDay(GameDay gameDay)
        {
            if ((gameDay.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(gameDay, EntityState.Added);
            }
            else
            {
                this.ObjectContext.GameDays.AddObject(gameDay);
            }
        }

        public void UpdateGameDay(GameDay currentGameDay)
        {
            this.ObjectContext.GameDays.AttachAsModified(currentGameDay, this.ChangeSet.GetOriginal(currentGameDay));
        }

        public void DeleteGameDay(GameDay gameDay)
        {
            if ((gameDay.EntityState == EntityState.Detached))
            {
                this.ObjectContext.GameDays.Attach(gameDay);
            }
            this.ObjectContext.GameDays.DeleteObject(gameDay);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'GamePayments' query.
        public IQueryable<GamePayment> GetGamePayments()
        {
            return this.ObjectContext.GamePayments;
        }

        public void InsertGamePayment(GamePayment gamePayment)
        {
            if ((gamePayment.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(gamePayment, EntityState.Added);
            }
            else
            {
                this.ObjectContext.GamePayments.AddObject(gamePayment);
            }
        }

        public void UpdateGamePayment(GamePayment currentGamePayment)
        {
            this.ObjectContext.GamePayments.AttachAsModified(currentGamePayment, this.ChangeSet.GetOriginal(currentGamePayment));
        }

        public void DeleteGamePayment(GamePayment gamePayment)
        {
            if ((gamePayment.EntityState == EntityState.Detached))
            {
                this.ObjectContext.GamePayments.Attach(gamePayment);
            }
            this.ObjectContext.GamePayments.DeleteObject(gamePayment);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Players' query.
        public IQueryable<Player> GetPlayers()
        {
            return this.ObjectContext.Players;
        }

        public void InsertPlayer(Player player)
        {
            if ((player.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(player, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Players.AddObject(player);
            }
        }

        public void UpdatePlayer(Player currentPlayer)
        {
            this.ObjectContext.Players.AttachAsModified(currentPlayer, this.ChangeSet.GetOriginal(currentPlayer));
        }

        public void DeletePlayer(Player player)
        {
            if ((player.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Players.Attach(player);
            }
            this.ObjectContext.Players.DeleteObject(player);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'PlayerStatics' query.
        public IQueryable<PlayerStatic> GetPlayerStatics()
        {
            return this.ObjectContext.PlayerStatics;
        }

        public void InsertPlayerStatic(PlayerStatic playerStatic)
        {
            if ((playerStatic.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(playerStatic, EntityState.Added);
            }
            else
            {
                this.ObjectContext.PlayerStatics.AddObject(playerStatic);
            }
        }

        public void UpdatePlayerStatic(PlayerStatic currentPlayerStatic)
        {
            this.ObjectContext.PlayerStatics.AttachAsModified(currentPlayerStatic, this.ChangeSet.GetOriginal(currentPlayerStatic));
        }

        public void DeletePlayerStatic(PlayerStatic playerStatic)
        {
            if ((playerStatic.EntityState == EntityState.Detached))
            {
                this.ObjectContext.PlayerStatics.Attach(playerStatic);
            }
            this.ObjectContext.PlayerStatics.DeleteObject(playerStatic);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'RegistrationPayments' query.
        public IQueryable<RegistrationPayment> GetRegistrationPayments()
        {
            return this.ObjectContext.RegistrationPayments;
        }

        public void InsertRegistrationPayment(RegistrationPayment registrationPayment)
        {
            if ((registrationPayment.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(registrationPayment, EntityState.Added);
            }
            else
            {
                this.ObjectContext.RegistrationPayments.AddObject(registrationPayment);
            }
        }

        public void UpdateRegistrationPayment(RegistrationPayment currentRegistrationPayment)
        {
            this.ObjectContext.RegistrationPayments.AttachAsModified(currentRegistrationPayment, this.ChangeSet.GetOriginal(currentRegistrationPayment));
        }

        public void DeleteRegistrationPayment(RegistrationPayment registrationPayment)
        {
            if ((registrationPayment.EntityState == EntityState.Detached))
            {
                this.ObjectContext.RegistrationPayments.Attach(registrationPayment);
            }
            this.ObjectContext.RegistrationPayments.DeleteObject(registrationPayment);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Teams' query.
        public IQueryable<Team> GetTeams()
        {
            return this.ObjectContext.Teams;
        }

        public void InsertTeam(Team team)
        {
            if ((team.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(team, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Teams.AddObject(team);
            }
        }

        public void UpdateTeam(Team currentTeam)
        {
            this.ObjectContext.Teams.AttachAsModified(currentTeam, this.ChangeSet.GetOriginal(currentTeam));
        }

        public void DeleteTeam(Team team)
        {
            if ((team.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Teams.Attach(team);
            }
            this.ObjectContext.Teams.DeleteObject(team);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Tournaments' query.
        public IQueryable<Tournament> GetTournaments()
        {
            return this.ObjectContext.Tournaments;
        }

        public void InsertTournament(Tournament tournament)
        {
            if ((tournament.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tournament, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Tournaments.AddObject(tournament);
            }
        }

        public void UpdateTournament(Tournament currentTournament)
        {
            this.ObjectContext.Tournaments.AttachAsModified(currentTournament, this.ChangeSet.GetOriginal(currentTournament));
        }

        public void DeleteTournament(Tournament tournament)
        {
            if ((tournament.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Tournaments.Attach(tournament);
            }
            this.ObjectContext.Tournaments.DeleteObject(tournament);
        }
    }
}


