
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


    // Implements application logic using the SoccerEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class SoccerModelService : LinqToEntitiesDomainService<SoccerEntities>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Category' query.
        public IQueryable<Category> GetCategory()
        {
            return this.ObjectContext.Category;
        }

        public void InsertCategory(Category category)
        {
            if ((category.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(category, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Category.AddObject(category);
            }
        }

        public void UpdateCategory(Category currentCategory)
        {
            this.ObjectContext.Category.AttachAsModified(currentCategory, this.ChangeSet.GetOriginal(currentCategory));
        }

        public void DeleteCategory(Category category)
        {
            if ((category.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Category.Attach(category);
            }
            this.ObjectContext.Category.DeleteObject(category);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Game' query.
        public IQueryable<Game> GetGame()
        {
            return this.ObjectContext.Game;
        }

        public void InsertGame(Game game)
        {
            if ((game.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(game, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Game.AddObject(game);
            }
        }

        public void UpdateGame(Game currentGame)
        {
            this.ObjectContext.Game.AttachAsModified(currentGame, this.ChangeSet.GetOriginal(currentGame));
        }

        public void DeleteGame(Game game)
        {
            if ((game.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Game.Attach(game);
            }
            this.ObjectContext.Game.DeleteObject(game);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'GameDay' query.
        public IQueryable<GameDay> GetGameDay()
        {
            return this.ObjectContext.GameDay;
        }

        public void InsertGameDay(GameDay gameDay)
        {
            if ((gameDay.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(gameDay, EntityState.Added);
            }
            else
            {
                this.ObjectContext.GameDay.AddObject(gameDay);
            }
        }

        public void UpdateGameDay(GameDay currentGameDay)
        {
            this.ObjectContext.GameDay.AttachAsModified(currentGameDay, this.ChangeSet.GetOriginal(currentGameDay));
        }

        public void DeleteGameDay(GameDay gameDay)
        {
            if ((gameDay.EntityState == EntityState.Detached))
            {
                this.ObjectContext.GameDay.Attach(gameDay);
            }
            this.ObjectContext.GameDay.DeleteObject(gameDay);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'GamePayments' query.
        public IQueryable<GamePayments> GetGamePayments()
        {
            return this.ObjectContext.GamePayments;
        }

        public void InsertGamePayments(GamePayments gamePayments)
        {
            if ((gamePayments.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(gamePayments, EntityState.Added);
            }
            else
            {
                this.ObjectContext.GamePayments.AddObject(gamePayments);
            }
        }

        public void UpdateGamePayments(GamePayments currentGamePayments)
        {
            this.ObjectContext.GamePayments.AttachAsModified(currentGamePayments, this.ChangeSet.GetOriginal(currentGamePayments));
        }

        public void DeleteGamePayments(GamePayments gamePayments)
        {
            if ((gamePayments.EntityState == EntityState.Detached))
            {
                this.ObjectContext.GamePayments.Attach(gamePayments);
            }
            this.ObjectContext.GamePayments.DeleteObject(gamePayments);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Player' query.
        public IQueryable<Player> GetPlayer()
        {
            return this.ObjectContext.Player;
        }

        public void InsertPlayer(Player player)
        {
            if ((player.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(player, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Player.AddObject(player);
            }
        }

        public void UpdatePlayer(Player currentPlayer)
        {
            this.ObjectContext.Player.AttachAsModified(currentPlayer, this.ChangeSet.GetOriginal(currentPlayer));
        }

        public void DeletePlayer(Player player)
        {
            if ((player.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Player.Attach(player);
            }
            this.ObjectContext.Player.DeleteObject(player);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'PlayerStatics' query.
        public IQueryable<PlayerStatics> GetPlayerStatics()
        {
            return this.ObjectContext.PlayerStatics;
        }

        public void InsertPlayerStatics(PlayerStatics playerStatics)
        {
            if ((playerStatics.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(playerStatics, EntityState.Added);
            }
            else
            {
                this.ObjectContext.PlayerStatics.AddObject(playerStatics);
            }
        }

        public void UpdatePlayerStatics(PlayerStatics currentPlayerStatics)
        {
            this.ObjectContext.PlayerStatics.AttachAsModified(currentPlayerStatics, this.ChangeSet.GetOriginal(currentPlayerStatics));
        }

        public void DeletePlayerStatics(PlayerStatics playerStatics)
        {
            if ((playerStatics.EntityState == EntityState.Detached))
            {
                this.ObjectContext.PlayerStatics.Attach(playerStatics);
            }
            this.ObjectContext.PlayerStatics.DeleteObject(playerStatics);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'RegistrationPayments' query.
        public IQueryable<RegistrationPayments> GetRegistrationPayments()
        {
            return this.ObjectContext.RegistrationPayments;
        }

        public void InsertRegistrationPayments(RegistrationPayments registrationPayments)
        {
            if ((registrationPayments.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(registrationPayments, EntityState.Added);
            }
            else
            {
                this.ObjectContext.RegistrationPayments.AddObject(registrationPayments);
            }
        }

        public void UpdateRegistrationPayments(RegistrationPayments currentRegistrationPayments)
        {
            this.ObjectContext.RegistrationPayments.AttachAsModified(currentRegistrationPayments, this.ChangeSet.GetOriginal(currentRegistrationPayments));
        }

        public void DeleteRegistrationPayments(RegistrationPayments registrationPayments)
        {
            if ((registrationPayments.EntityState == EntityState.Detached))
            {
                this.ObjectContext.RegistrationPayments.Attach(registrationPayments);
            }
            this.ObjectContext.RegistrationPayments.DeleteObject(registrationPayments);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Team' query.
        public IQueryable<Team> GetTeam()
        {
            return this.ObjectContext.Team;
        }

        public void InsertTeam(Team team)
        {
            if ((team.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(team, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Team.AddObject(team);
            }
        }

        public void UpdateTeam(Team currentTeam)
        {
            this.ObjectContext.Team.AttachAsModified(currentTeam, this.ChangeSet.GetOriginal(currentTeam));
        }

        public void DeleteTeam(Team team)
        {
            if ((team.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Team.Attach(team);
            }
            this.ObjectContext.Team.DeleteObject(team);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Tournament' query.
        public IQueryable<Tournament> GetTournament()
        {
            return this.ObjectContext.Tournament;
        }

        public void InsertTournament(Tournament tournament)
        {
            if ((tournament.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tournament, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Tournament.AddObject(tournament);
            }
        }

        public void UpdateTournament(Tournament currentTournament)
        {
            this.ObjectContext.Tournament.AttachAsModified(currentTournament, this.ChangeSet.GetOriginal(currentTournament));
        }

        public void DeleteTournament(Tournament tournament)
        {
            if ((tournament.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Tournament.Attach(tournament);
            }
            this.ObjectContext.Tournament.DeleteObject(tournament);
        }
    }
}


