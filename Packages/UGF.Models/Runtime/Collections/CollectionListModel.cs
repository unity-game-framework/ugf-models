using System;
using System.Collections;
using System.Collections.Generic;

namespace UGF.Models.Runtime.Collections
{
    public class CollectionListModel : ICollectionModel
    {
        public List<Guid> Items { get; set; } = new List<Guid>();

        ICollection ICollectionModel.Items { get { return Items; } }
    }
}
