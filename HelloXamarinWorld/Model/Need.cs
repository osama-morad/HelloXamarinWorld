using System;
using System.Collections.Generic;
using System.Text;

namespace HelloXamarinWorld.Model
    // Needs
{
    // Needs
    public class Need
    {
        public string Id { get; set; } // Id (Primary key) (length: 36)
        public string NeedType { get; set; } // NeedType (length: 50)
    }

    #region POCO classes

    // ****************************************************************************************************
    // This is not a commercial licence, therefore only a few tables/views/stored procedures are generated.
    // ****************************************************************************************************

    // InNeed
    public class InNeed
    {
        public string Id { get; set; } // Id (Primary key) (length: 36)
        public string NickName { get; set; } // NickName (length: 100)
        public decimal Latitude { get; set; } // Latitude
        public decimal Longitude { get; set; } // Longitude
        public string CreatorId { get; set; } // CreatorId (length: 36)
        public int Visits { get; set; } // Visits

        public InNeed()
        {
            Visits = 0;
        }
    }

    // InNeedSocialStatus
    public class InNeedSocialStatu
    {
        public string InNeedId { get; set; } // InNeedId (Primary key) (length: 36)
        public string SocialStatusId { get; set; } // SocialStatusId (Primary key) (length: 36)
        public int? NumberOfPersons { get; set; } // NumberOfPersons
    }

    // RequiredNeeds
    public class RequiredNeed
    {
        public string InNeedId { get; set; } // InNeedId (Primary key) (length: 36)
        public string NeededId { get; set; } // NeededId (Primary key) (length: 36)

        /// <summary>
        /// How many times that need fulfilled by someone
        /// </summary>
        public int Responses { get; set; } // Responses

        public RequiredNeed()
        {
            Responses = 0;
        }
    }

    // SocialStatus
    public class SocialStatu
    {
        public string Id { get; set; } // Id (Primary key) (length: 36)
        public string SocialStatus { get; set; } // SocialStatus (length: 100)
    }


    #endregion

}
