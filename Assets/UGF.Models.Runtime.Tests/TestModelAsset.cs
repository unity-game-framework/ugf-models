using UnityEngine;

namespace UGF.Models.Runtime.Tests
{
    [CreateAssetMenu(menuName = "Tests/TestModelAsset")]
    public class TestModelAsset : ModelAsset
    {
        protected override IModel OnBuild()
        {
            return new TestModel();
        }
    }

    public class TestModel : IModel
    {
        public int Value { get; set; }
    }
}
