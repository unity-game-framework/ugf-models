using System.Collections.Generic;

namespace UGF.Models.Runtime.Domain.Systems
{
    public class DomainSystemModel : IDomainSystemModel
    {
        public List<string> ModelIds { get; set; } = new List<string>();

        IList<string> IDomainSystemModel.ModelIds { get { return ModelIds; } }
    }
}
