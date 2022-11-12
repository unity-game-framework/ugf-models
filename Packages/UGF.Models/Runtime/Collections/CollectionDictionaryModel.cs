using System;
using System.Collections;
using System.Collections.Generic;

namespace UGF.Models.Runtime.Collections
{
    public class CollectionDictionaryModel : ICollectionModel
    {
        public Dictionary<Guid, Guid> Items { get; set; } = new Dictionary<Guid, Guid>();

        ICollection ICollectionModel.Items { get { return Items; } }
    }
}
