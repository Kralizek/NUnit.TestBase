using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace TestBase
{
    [TestFixture]
    public abstract class TestBase
    {
        protected IFixture Fixture;

        [SetUp]
        public void InitializeBase()
        {
            Fixture = new Fixture();
            CustomizeFixture(Fixture);
        }

        protected virtual void CustomizeFixture(IFixture fixture)
        {
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [TestFixtureSetUp]
        protected virtual void SetUpFixture() { }

        [TestFixtureTearDown]
        protected virtual void TearDownFixture() { }
    }

    public abstract class TestBase<T> : TestBase
    {
        protected abstract T CreateSystemUnderTest();
    }
}
