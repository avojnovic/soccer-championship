
namespace SoccerChampionship.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies CategoryMetadata as the class
    // that carries additional metadata for the Category class.
    [MetadataTypeAttribute(typeof(Category.CategoryMetadata))]
    public partial class Category
    {

        // This class allows you to attach custom attributes to properties
        // of the Category class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class CategoryMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private CategoryMetadata()
            {
            }

            public int Id { get; set; }

            public string Name { get; set; }

            public EntityCollection<Team> Teams { get; set; }

            public EntityCollection<Tournament> Tournaments { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies GameMetadata as the class
    // that carries additional metadata for the Game class.
    [MetadataTypeAttribute(typeof(Game.GameMetadata))]
    public partial class Game
    {

        // This class allows you to attach custom attributes to properties
        // of the Game class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class GameMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private GameMetadata()
            {
            }

            public GameDay GameDay { get; set; }

            public int GameDayID { get; set; }

            public EntityCollection<GamePayment> GamePayments { get; set; }

            public int ID { get; set; }

            public DateTime StartTime { get; set; }

            public Team Team { get; set; }

            public Team Team1 { get; set; }

            public int Team1ID { get; set; }

            public int Team2ID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies GameDayMetadata as the class
    // that carries additional metadata for the GameDay class.
    [MetadataTypeAttribute(typeof(GameDay.GameDayMetadata))]
    public partial class GameDay
    {

        // This class allows you to attach custom attributes to properties
        // of the GameDay class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class GameDayMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private GameDayMetadata()
            {
            }

            public decimal GameAmount { get; set; }

            public DateTime GameDate { get; set; }

            public EntityCollection<Game> Games { get; set; }

            public int ID { get; set; }

            public EntityCollection<PlayerStatic> PlayerStatics { get; set; }

            public Tournament Tournament { get; set; }

            public int TournamentID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies GamePaymentMetadata as the class
    // that carries additional metadata for the GamePayment class.
    [MetadataTypeAttribute(typeof(GamePayment.GamePaymentMetadata))]
    public partial class GamePayment
    {

        // This class allows you to attach custom attributes to properties
        // of the GamePayment class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class GamePaymentMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private GamePaymentMetadata()
            {
            }

            public Game Game { get; set; }

            public int GameID { get; set; }

            public int ID { get; set; }

            public DateTime PaidDate { get; set; }

            public Team Team { get; set; }

            public int TeamID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies PlayerStaticMetadata as the class
    // that carries additional metadata for the PlayerStatic class.
    [MetadataTypeAttribute(typeof(PlayerStatic.PlayerStaticMetadata))]
    public partial class PlayerStatic
    {

        // This class allows you to attach custom attributes to properties
        // of the PlayerStatic class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class PlayerStaticMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private PlayerStaticMetadata()
            {
            }

            public GameDay GameDay { get; set; }

            public int GameDayID { get; set; }

            public int Goals { get; set; }

            public int ID { get; set; }

            public Player Player { get; set; }

            public int PlayerID { get; set; }

            public int RedCard { get; set; }

            public int YellowCards { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies RegistrationPaymentMetadata as the class
    // that carries additional metadata for the RegistrationPayment class.
    [MetadataTypeAttribute(typeof(RegistrationPayment.RegistrationPaymentMetadata))]
    public partial class RegistrationPayment
    {

        // This class allows you to attach custom attributes to properties
        // of the RegistrationPayment class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class RegistrationPaymentMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private RegistrationPaymentMetadata()
            {
            }

            public int ID { get; set; }

            public DateTime PaidDate { get; set; }

            public Team Team { get; set; }

            public int TeamID { get; set; }

            public Tournament Tournament { get; set; }

            public int TournamentID { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies TeamMetadata as the class
    // that carries additional metadata for the Team class.
    [MetadataTypeAttribute(typeof(Team.TeamMetadata))]
    public partial class Team
    {

        // This class allows you to attach custom attributes to properties
        // of the Team class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class TeamMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private TeamMetadata()
            {
            }

            public Category Category { get; set; }

            public int CategoryID { get; set; }

            public EntityCollection<GamePayment> GamePayments { get; set; }

            public EntityCollection<Game> Games { get; set; }

            public EntityCollection<Game> Games1 { get; set; }

            public int ID { get; set; }

            public string Name { get; set; }

            public EntityCollection<Player> Players { get; set; }

            public EntityCollection<RegistrationPayment> RegistrationPayments { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies TournamentMetadata as the class
    // that carries additional metadata for the Tournament class.
    [MetadataTypeAttribute(typeof(Tournament.TournamentMetadata))]
    public partial class Tournament
    {

        // This class allows you to attach custom attributes to properties
        // of the Tournament class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class TournamentMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private TournamentMetadata()
            {
            }

            public Category Category { get; set; }

            public int CategoryID { get; set; }

            public EntityCollection<GameDay> GameDays { get; set; }

            public int ID { get; set; }

            [Required]
            [StringLength(20)]
            public string Name { get; set; }
            
            [Required]
            public decimal RegistrationAmount { get; set; }

            public EntityCollection<RegistrationPayment> RegistrationPayments { get; set; }

            public DateTime StartDate { get; set; }
        }
    }
}
