using System;
using System.Collections.Generic;

namespace UGF.Models.Runtime.Domain
{
    public class DomainModel : IDomainModel
    {
        public Dictionary<Guid, IModel> Models { get; set; } = new Dictionary<Guid, IModel>();

        IDictionary<Guid, IModel> IDomainModel.Models { get { return Models; } }
    }
}
