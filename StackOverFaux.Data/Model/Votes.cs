using Massive.PostgreSQL;

namespace StackOverFaux.Data.Model
{
    public class Vote : DynamicModel
    {
        public Vote() : base("SoFConnStr")
        {
            PrimaryKeyField = "voteid";
            TableName = "votes";
        }
    }
    public class VoteType : DynamicModel
    {
        public VoteType() : base("SoFConnStr")
        {
            PrimaryKeyField = "votetypeid";
            TableName = "votetypes";
        }
    }
    /*
    public class Vote
    {
        [Key]
        public int VoteId { get; set; }
        public int BountyAmount { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual Post Post { get; set; }
        public virtual VoteType VoteType { get; set; }
        public virtual User User {get;set;}

    }


    public class VoteType
    {
        [Key]
        public int VoteTypeId { get; set; }
        public string Name { get; set; }
    }*/
}
